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
        public ActionResult NPCs()
        {
            // Create and populate a Datatable
            DataTable table = GetTable("npc");
            // Return the NPC view and pass it the table
            return View(table);
        }

        public ActionResult Items()
        {
            // Create and populate a Datatable
            DataTable table = GetTable("item");
            // Return the Items view and pass it the table
            return View(table);
        }
        public ActionResult Locations()
        {
            // Create and populate a Datatable
            DataTable table = GetTable("location");
            // Return the Locations view and pass it the table
            return View(table);
        }

        public DataTable GetTable(string type)
        {
            // Create a fresh DataTable
            DataTable table = new DataTable();

            Database.Connect();
            switch (type)
            {
                case "npc":
                    table = Database.Select("SELECT * FROM GuideNPCs", null);
                    break;
                case "item":
                    table = Database.Select("SELECT * FROM GuideItems", null);
                    break;
                case "location":
                    table = Database.Select("SELECT * FROM GuideLocations", null);
                    break;
            }
            Database.CloseConnection();
            return table;
        }
    }
}