using System.Data;
using System.Web;
using System.Web.Mvc;

namespace InExile.Controllers
{
    public class GuideController : Controller
    {
        // GET: Guide
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
            
            table.Columns.Add("Name", typeof(string));
        
            // Allow for additional Columns for each type if needed
            switch (type)
            {
                case "npc":
                    table.Columns.Add("Location", typeof(string));
                    break;
                case "item":
                    break;
                case "location":
                    break;
            }

            table.Columns.Add("Edit", typeof(HtmlString));
            table.Columns.Add("Delete", typeof(HtmlString));

            /// Connect to Database and retrieve entries
            /// TO DO /// 
            ///
            switch (type)
            {
                case "npc":
                    break;
                case "item":
                    break;
                case "location":
                    break;
            }

            return table;
        }
    }
}