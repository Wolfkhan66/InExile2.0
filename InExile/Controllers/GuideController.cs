using InExile.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Web;
using System.Web.Mvc;

namespace InExile.Controllers
{
    public class GuideController : Controller
    {
        DatabaseController Database = new DatabaseController();
        public ActionResult Index()
        {
            return View();
        }

        // Create and populate a Datatable
        // Return the ViewGuide view and pass it a GuideViewModel
        public ActionResult ViewGuide(string Type)
        {
            DataTable table = GetTable(Type);
            GuideViewModel model = new GuideViewModel(table, Type);
            return View(model);
        }

        // Get a single guide entry from the database
        // Return the view of viewName and pass it a GuideEditModel
        public ActionResult GetEntry(int ID, string Type, string viewName)
        {
            Database.Connect();
            Dictionary<string, object> dict = Database.SelectRow("SELECT * FROM Guide" + Type + " WHERE ID = " + ID,  null);
            Database.CloseConnection();
            GuideEditModel model = new GuideEditModel(dict, Type);
            return View(viewName, model);
        }

        // Query the database and return a DataTable
        public DataTable GetTable(string Type)
        {
            DataTable table = new DataTable();

            Database.Connect();
            switch (Type)
            {
                case "NPCs":
                    table = Database.Select("SELECT ID, Name FROM GuideNPCs", null);
                    break;
                case "Items":
                    table = Database.Select("SELECT ID, Name FROM GuideItems", null);
                    break;
                case "Locations":
                    table = Database.Select("SELECT ID, Name FROM GuideLocations", null);
                    break;
            }
            Database.CloseConnection();
            table.Columns.Add("Edit", typeof(HtmlString));
            table.Columns.Add("Delete", typeof(HtmlString));

            foreach (DataRow row in table.Rows)
            {
                // For each row in the table provide it an Edit and Delete HypeLink that passes the entries ID and Type
                row["Edit"] = new HtmlString("<a href=GetEntry?Id=" + row["ID"] + "&Type=" + Type + "&viewName=Edit>edit</a>"); ;
                row["Delete"] = new HtmlString("<a href=GetEntry?Id=" + row["ID"] + "&Type=" + Type + "&viewName=Delete>delete</a>"); ;
            }

            return table;
        }
    }
}