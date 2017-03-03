using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Web.Mvc;

namespace InExile.Controllers
{
    public class UpdateController : Controller
    {
        DatabaseController Database = new DatabaseController();

        public ActionResult Create(string Type)
        {
            return View((object)Type);
        }

        public ActionResult Edit (string Type, int ID, string name, string appearance, string location, string additional, string description)
        {
            Database.Connect();

            switch (Type)
            {
                case "NPCs":
                    Database.RunSQL("UPDATE Guide" + Type + " SET Name ='" + name + "',Appearance='" + appearance + "',Location='" + location + "',Additional='" + additional + "' WHERE ID =" + ID, null);
                    break;
                case "Locations":
                    Database.RunSQL("UPDATE Guide" + Type + " SET Name ='" + name + "',Description='" + description + "',Additional='" + additional + "' WHERE ID =" + ID, null);
                    break;
                case "Items":
                    Database.RunSQL("UPDATE Guide" + Type + " SET Name ='" + name + "',Description='" + description + "',Additional='" + additional + "' WHERE ID =" + ID, null);
                    break;
            }

            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult Delete(string Type, int ID)
        {
            Database.Connect();
            Database.RunSQL("DELETE FROM Guide" + Type + " WHERE ID =" + ID, null);
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult Location(string name, string description, string additional)
        {
            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Description, Additional) VALUES(@name, @description, @additional)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("description", description),
                    new SQLiteParameter("additional", additional)});
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult NPC(string name, string appearance, string location, string additional)
        {
            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Appearance, Location, Additional) VALUES(@name, @appearance, @location, @additional)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("appearance", appearance),
                    new SQLiteParameter("location", location), new SQLiteParameter("additional", additional) });
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult Item(string name, string description, string additional)
        {
            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Description, Additional) VALUES(@name, @description, @additional)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("description", description),
                    new SQLiteParameter("additional", additional) });
            Database.CloseConnection();
            return View("Success");
        }
    }
}
