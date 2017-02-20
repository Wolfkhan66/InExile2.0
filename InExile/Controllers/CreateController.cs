using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InExile.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Location()
        {
            return View();
        }

        public ActionResult NPC()
        {
            return View();
        }

        public ActionResult Item()
        {
            return View();
        }
    }
}