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

        public ActionResult Location(string name, string description, string additional)
        {
            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Description, Additional) VALUES(@name, @description, @additional)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("description", description), new SQLiteParameter("additional", additional) });
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult NPC(string name, string appearance, string location, string additional)
        {
            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Appearance, Location, Additional) VALUES(@name, @appearance, @location, @additional)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("appearance", appearance), new SQLiteParameter("location", location), new SQLiteParameter("additional", additional) });
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult Item(string name, string description, string additional)
        {
            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Description, Additional) VALUES(@name, @description, @additional)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("description", description), new SQLiteParameter("additional", additional) });
            Database.CloseConnection();
            return View("Success");
        }
    }
}
