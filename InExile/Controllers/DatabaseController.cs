using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Web.Hosting;

namespace InExile
{
    public class DatabaseController
    {
        private SQLiteConnection MasterDatabase = new SQLiteConnection();
        public bool Connect()
        {
            try
            {
                if (!Directory.Exists(HostingEnvironment.ApplicationPhysicalPath + ConfigurationManager.AppSettings["DatabasePath"]))
                {
                    Directory.CreateDirectory(HostingEnvironment.ApplicationPhysicalPath + ConfigurationManager.AppSettings["DatabasePath"]);
                }

                if (!File.Exists(HostingEnvironment.ApplicationPhysicalPath + ConfigurationManager.AppSettings["DatabasePath"] + ConfigurationManager.AppSettings["Database"]))
               {
                    SQLiteConnection.CreateFile(HostingEnvironment.ApplicationPhysicalPath + ConfigurationManager.AppSettings["DatabasePath"] + ConfigurationManager.AppSettings["Database"]);
                }

                this.MasterDatabase = new SQLiteConnection("Data Source=" + HostingEnvironment.ApplicationPhysicalPath +  ConfigurationManager.AppSettings["DatabasePath"] + ConfigurationManager.AppSettings["Database"] + ";Version=3;");
                this.MasterDatabase.Open();

                RunSQL("CREATE TABLE IF NOT EXISTS 'GuideNPCs' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' TEXT, 'Appearance' TEXT, 'Location' TEXT, 'Additional' TEXT )", null);
                RunSQL("CREATE TABLE IF NOT EXISTS 'GuideLocations' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' TEXT, 'Description' TEXT, 'Additional' TEXT)", null);
                RunSQL("CREATE TABLE IF NOT EXISTS 'GuideItems' ('ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' TEXT, 'Description' TEXT, 'Additional' TEXT)", null);
                return true;
            }
            catch (Exception e)
            {
                // TO DO - Write to log file
                return false;
            }
        }

        // run an Update, Insert, Delete or Execute query
        public void RunSQL(string SQLString, SQLiteParameter[] Values)
        {
            try
            {
                SQLiteCommand SqlCommand = CreateSqlCommand(SQLString, Values);
                SQLiteDataReader reader = SqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                // TO DO - Write to log file
            }
        }

        // Run a SELECT query, return as a DataTable
        public DataTable Select(string SQLString, SQLiteParameter[] Values)
        {
            try
            {
                SQLiteCommand SqlCommand = CreateSqlCommand(SQLString, Values);
                SQLiteDataReader reader = SqlCommand.ExecuteReader();
                DataTable QueryResults = new DataTable();
                QueryResults.Load(reader);
                return QueryResults;
            }
            catch (Exception e)
            {
                // TO DO - Write to log file
                return null;
            }
        }

        // Create and return an SQLiteCommand
        private SQLiteCommand CreateSqlCommand(string SQLString, SQLiteParameter[] Values)
        {
            SQLiteCommand SqlCommand = MasterDatabase.CreateCommand();
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = SQLString;
            if (Values != null)
            {
                SqlCommand.Parameters.AddRange(Values);
            }
            return SqlCommand;
        }

        public void CloseConnection()
        {
            MasterDatabase.Close();
        }
    }
}
