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
    public class PartnerAndRelationsController : BaseController
    {

        // GET: BackOffice/PartnerAndRelations
        public ActionResult Index()
        {
            return View(db.PartnerAndRelations.ToList());
        }
        public ActionResult Partner()
        {
            var partnerAndRelations = db.PartnerAndRelations;

            foreach (var item in db.PartnerAndRelations)
                if (item.Partner) partnerAndRelations.Add(item);
            return View(partnerAndRelations.OrderBy(x => x.Order).ToList());
        }
        public ActionResult Relation()
        {
            var partnerAndRelations = db.PartnerAndRelations;

            foreach (var item in db.PartnerAndRelations)
                if (item.Relation) partnerAndRelations.Add(item);
            return View(partnerAndRelations.OrderBy(x => x.Order).ToList());
        }
        // GET: BackOffice/PartnerAndRelations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerAndRelation partnerAndRelation = db.PartnerAndRelations.Find(id);
            if (partnerAndRelation == null)
            {
                return HttpNotFound();
            }
            return View(partnerAndRelation);
        }

        // GET: BackOffice/PartnerAndRelations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/PartnerAndRelations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Link,Partner,Relation,Order,Visible")] PartnerAndRelation partnerAndRelation)
        {
            if (ModelState.IsValid)
            {
                db.PartnerAndRelations.Add(partnerAndRelation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partnerAndRelation);
        }

        // GET: BackOffice/PartnerAndRelations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerAndRelation partnerAndRelation = db.PartnerAndRelations.Include("ImagePartners").SingleOrDefault(x => x.Id == id);
            if (partnerAndRelation == null)
            {
                return HttpNotFound();
            }
            return View(partnerAndRelation);
        }

        // POST: BackOffice/PartnerAndRelations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Link,Partner,Relation,Order,Visible")] PartnerAndRelation partnerAndRelation)
        {
            db.Entry(partnerAndRelation).State = EntityState.Modified;
            db.PartnerAndRelations.Include("ImagePartners").SingleOrDefault(x => x.Id == partnerAndRelation.Id);
            if (ModelState.IsValid)
               
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partnerAndRelation);
        }

        // GET: BackOffice/PartnerAndRelations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerAndRelation partnerAndRelation = db.PartnerAndRelations.Find(id);
            if (partnerAndRelation == null)
            {
                return HttpNotFound();
            }
            return View(partnerAndRelation);
        }

        // POST: BackOffice/PartnerAndRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartnerAndRelation partnerAndRelation = db.PartnerAndRelations.Find(id);
            db.PartnerAndRelations.Remove(partnerAndRelation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImagePartner();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.PartnerAndRelationId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImagePartners.Add(tp);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         db.SaveChanges();
                return RedirectToAction("edit", "PartnerAndRelations", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "PartnerAndRelations", new { id = id });
        }
        public ActionResult DeletePicture(int id, int idPartnerAndRelations)
        {
            ImagePartner image = db.ImagePartners.Find(id);
            db.ImagePartners.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "PartnerAndRelations", new { id = idPartnerAndRelations });
        }
    }
}
