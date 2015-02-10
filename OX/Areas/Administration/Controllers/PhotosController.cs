using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OX.Models;
using OX.Helpers;
using System.Globalization;

namespace OX.Areas.Administration.Controllers
{
    public class PhotosController : Controller
    {
        private OXDataContext db = new OXDataContext();

        private List<SelectListItem> Albums
        {
            get
            {
                var items = new List<SelectListItem>();
                db.Albums.ToList().ForEach(p => items.Add(new SelectListItem { Text = p.Title, Value = p.Id.ToString(CultureInfo.InvariantCulture) }));
                return items;
            }
        }

        // GET: Photos
        public ActionResult Index()
        {
            var photoList = db.Photos.ToList();
            var albumList = db.Albums.ToList();
            photoList.ForEach(p => p.Album = albumList.Find(a => a.Id == p.AlbumId));
            return View(photoList);
        }

        // GET: Photos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photos/Create
        public ActionResult Create()
        {
            ViewBag.Albums = Albums;
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Title,Description,Image,AlbumId")] Photo photo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    byte[] fileBytes = DbHelper.ReadBytes(file.InputStream);
                    photo.Image = fileBytes;
                }

                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Albums = Albums;
            }

            return View(photo);
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            foreach (var album in Albums)
            {
                if (album.Value == photo.AlbumId.ToString())
                    album.Selected = true;
            }

            ViewBag.Albums = Albums;
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Title,Description,Image,AlbumId")] Photo photo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    byte[] fileBytes = DbHelper.ReadBytes(file.InputStream);
                    photo.Image = fileBytes;
                }

                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
