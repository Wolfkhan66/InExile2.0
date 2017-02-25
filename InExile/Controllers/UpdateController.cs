using InExile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InExile.Controllers
{
    public class UpdateController : Controller
    {
            public ActionResult Location(string name, string description, string additional)
            {
                GuideLocation location = new GuideLocation(name, description, additional);
                CreateParameters(location);
                return View("Guide");
            }

            public ActionResult NPC(string name, string appearance, string location, string additional)
            {
                GuideNPC npc = new GuideNPC(name, appearance, location, additional);
                CreateParameters(npc);
                return View("Guide");
            }

            public ActionResult Item(string name, string description, string additional)
            {
                GuideItem item = new GuideItem(name, description, additional);
                CreateParameters(item);
                return View("Guide");
            }

            public void CreateParameters(GuideLocation location)
            {
                // TO DO
                UpdateDatabase();
            }

            public void CreateParameters(GuideItem item)
            {
                // TO DO
                UpdateDatabase();
            }

            public void CreateParameters(GuideNPC npc)
            {
                // TO DO
                UpdateDatabase();
            }

            public void UpdateDatabase()
            {
                // TO DO
            }
        }
    }
