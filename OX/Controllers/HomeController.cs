using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OX.Models;

namespace OX.Controllers
{
    public class HomeController : Controller
    {
        private OXDataContext db = new OXDataContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Musicians.ToList());
        }

        public JsonResult GetAllMusicians()
        {
            var musicians = db.Musicians.ToList();
            return Json(musicians, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllNews()
        {
            var news = db.NewsAll.ToList();
            return Json(news, JsonRequestBehavior.AllowGet);
        }
    }
}
