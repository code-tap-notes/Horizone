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
    public class AnalyseMaterialsController : BaseController
    {      
        // GET: BackOffice/AnalyseMaterials
        public ActionResult Index()
        {
            return View(db.AnalyseMaterials.Include("ImageUVs").Include("ImageAnalyses").ToList());
        }
        // GET: BackOffice/AnalyseMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMaterial analyseMaterial = db.AnalyseMaterials.Find(id);
            if (analyseMaterial == null)
            {
                return HttpNotFound();
            }
            return View(analyseMaterial);
        }
        // GET: BackOffice/AnalyseMaterials/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: BackOffice/AnalyseMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Index,Description,Order")] AnalyseMaterial analyseMaterial)
        {
            if (ModelState.IsValid)
            {
                db.AnalyseMaterials.Add(analyseMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(analyseMaterial);
        }

        // GET: BackOffice/AnalyseMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMaterial analyseMaterial = db.AnalyseMaterials.Find(id);
            if (analyseMaterial == null)
            {
                return HttpNotFound();
            }
            return View(analyseMaterial);
        }

        // POST: BackOffice/AnalyseMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Index,Description,Order")] AnalyseMaterial analyseMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analyseMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(analyseMaterial);
        }
        // GET: BackOffice/AnalyseMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMaterial analyseMaterial = db.AnalyseMaterials.Find(id);
            if (analyseMaterial == null)
            {
                return HttpNotFound();
            }
            return View(analyseMaterial);
        }
        // POST: BackOffice/AnalyseMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnalyseMaterial analyseMaterial = db.AnalyseMaterials.Find(id);
            db.AnalyseMaterials.Remove(analyseMaterial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageAnalyse();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.AnalyseMaterialId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageAnalyses.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "AnalyseMaterials", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "AnalyseMaterials", new { id = id });
        }
        public ActionResult DeletePicture(int id, int idAnalyseMaterial)
        {
            ImageAnalyse image = db.ImageAnalyses.Find(id);
            db.ImageAnalyses.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "AnalyseMaterials", new { id = idAnalyseMaterial });
        }
        [HttpPost]
        public ActionResult AddPictureUV(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageUV();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.AnalyseMaterialId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageUVs.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "AnalyseMaterials", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "AnalyseMaterials", new { id = id });
        }
        public ActionResult DeletePictureUV(int id, int idAnalyseMaterial)
        {
            ImageUV image = db.ImageUVs.Find(id);
            db.ImageUVs.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "AnalyseMaterials", new { id = idAnalyseMaterial });
        }
    }
}
