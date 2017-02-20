using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
        public ActionResult Items()
        {
            return View();
        }
        public ActionResult Locations()
        {
            return View();
        }
    }
}