using InExile.Models;
using System.Data;
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

        public DataTable GetTable(string Type)
        {
            // Create a fresh DataTable
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
            return table;
        }
    }
}