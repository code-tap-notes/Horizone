using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Controllers;
using Horizone.Models;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class MapsController : BaseController
    {

        // GET: BackOffice/Maps
        public ActionResult Index()
        {
            return View(db.Maps.ToList());
        }

        // GET: BackOffice/Maps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // GET: BackOffice/Maps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Maps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NamePicture")] Map map)
        {
            if (ModelState.IsValid)
            {
                db.Maps.Add(map);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(map);
        }

        // GET: BackOffice/Maps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Include("ImageMaps").SingleOrDefault(x => x.Id == id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // POST: BackOffice/Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NamePicture")] Map map)
        {
            db.Entry(map).State = EntityState.Modified;
            db.Maps.Include("ImageMaps").SingleOrDefault(x => x.Id == map.Id);

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(map);
        }

        // GET: BackOffice/Maps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = db.Maps.Include("ImageMaps").SingleOrDefault(x => x.Id == id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        // POST: BackOffice/Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Map map = db.Maps.Include("ImageMaps").SingleOrDefault(x => x.Id == id);
            db.Maps.Remove(map);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageMap();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.MapId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageMaps.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "Maps", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "Maps", new { id = id });
        }
        public ActionResult DeletePicture(int id, int idmap)
        {
            ImageMap image = db.ImageMaps.Find(id);
            db.ImageMaps.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "Maps", new { id = idmap });
        }
    }
}
