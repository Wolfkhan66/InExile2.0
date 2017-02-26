using System.Web.Mvc;

namespace InExile.Controllers
{
    public class UpdateController : Controller
    {
        DatabaseController Database = new DatabaseController();
        public ActionResult Location(string name, string description, string additional)
        {
            //Database.Connect();
            //Database.RunSQL("", null);
            //Database.CloseConnection();
            return View("Success");
        }

        public ActionResult NPC(string name, string appearance, string location, string additional)
        {
            //Database.Connect();
            //Database.RunSQL("", null);
            //Database.CloseConnection();
            return View("Success");
        }

        public ActionResult Item(string name, string description, string additional)
        {
            //Database.Connect();
            //Database.RunSQL("", null);
            //Database.CloseConnection();
            return View("Success");
        }
    }
}
