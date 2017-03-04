using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Web;
using System.Web.Hosting;
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

        public ActionResult Edit (string Type, int ID, string name, string appearance, string location, string additional, string description, HttpPostedFileBase image)
        {
            string path = "~/Content/Images/" + Type + "/" + image.FileName;
            image.SaveAs(Server.MapPath(path));
            Database.Connect();

            switch (Type)
            {
                case "NPCs":
                    Database.RunSQL("UPDATE Guide" + Type + " SET Name ='" + name + "',Appearance='" + appearance + "',Location='" + location + "',Additional='" + additional + "',Image='"+ path + "' WHERE ID =" + ID, null);
                    break;
                case "Locations":
                    Database.RunSQL("UPDATE Guide" + Type + " SET Name ='" + name + "',Description='" + description + "',Additional='" + additional + "',Image='" + path + "' WHERE ID =" + ID, null);
                    break;
                case "Items":
                    Database.RunSQL("UPDATE Guide" + Type + " SET Name ='" + name + "',Description='" + description + "',Additional='" + additional + "',Image='" + path + "' WHERE ID =" + ID, null);
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

        public ActionResult Locations(string name, string description, string additional, HttpPostedFileBase image)
        {
            string path = "~/Content/Images/Locations/" + image.FileName;
            image.SaveAs(Server.MapPath(path));

            Database.Connect();
            Database.RunSQL("INSERT INTO GuideLocations(Name, Description, Additional, Image) VALUES(@name, @description, @additional, @image)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("description", description),
                    new SQLiteParameter("additional", additional), new SQLiteParameter("image", path)});
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult NPCs(string name, string appearance, string location, string additional , HttpPostedFileBase image)
        {
            string path = "~/Content/Images/NPCs/" + image.FileName;
            image.SaveAs(Server.MapPath(path));

            Database.Connect();
            Database.RunSQL("INSERT INTO GuideNPCs(Name, Appearance, Location, Additional, Image) VALUES(@name, @appearance, @location, @additional, @image)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("appearance", appearance),
                    new SQLiteParameter("location", location), new SQLiteParameter("additional", additional) , new SQLiteParameter("image", path) });
            Database.CloseConnection();
            return View("Success");
        }

        public ActionResult Items(string name, string description, string additional, HttpPostedFileBase image)
        {
            string path = "~/Content/Images/Items/" + image.FileName;
            image.SaveAs(Server.MapPath(path));

            Database.Connect();
            Database.RunSQL("INSERT INTO GuideItems(Name, Description, Additional, Image) VALUES(@name, @description, @additional, @image)",
                new SQLiteParameter[] { new SQLiteParameter("name", name), new SQLiteParameter("description", description),
                    new SQLiteParameter("additional", additional), new SQLiteParameter("image", path) });
            Database.CloseConnection();
            return View("Success");
        }
    }
}
