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

        public ActionResult ViewGuide(string Type)
        {
            // Create and populate a Datatable
            DataTable table = GetTable(Type);
            // Return the view and pass it the model
            GuideViewModel model = new GuideViewModel(table, Type);
            return View(model);
        }

        public ActionResult GetEntry(int ID, string Type, string viewName)
        {
            Database.Connect();
            Dictionary<string, object> dict = Database.SelectRow("SELECT * FROM Guide" + Type + " WHERE ID = " + ID,  null);
            Database.CloseConnection();
            GuideEditModel model = new GuideEditModel(dict, Type);
            return View(viewName, model);
        }

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
                row["Edit"] = new HtmlString("<a href=GetEntry?Id=" + row["ID"] + "&Type=" + Type + "&viewName=Edit>edit</a>"); ;
                row["Delete"] = new HtmlString("<a href=GetEntry?Id=" + row["ID"] + "&Type=" + Type + "&viewName=Delete>delete</a>"); ;
            }

            return table;
        }
    }
}