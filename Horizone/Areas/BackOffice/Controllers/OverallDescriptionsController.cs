using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class OverallDescriptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/OverallDescriptions
        public ActionResult Index()
        {
            return View(db.OverallDescriptions.ToList());
        }

        // GET: BackOffice/OverallDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallDescription overallDescription = db.OverallDescriptions.Find(id);
            if (overallDescription == null)
            {
                return HttpNotFound();
            }
            return View(overallDescription);
        }

        // GET: BackOffice/OverallDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/OverallDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Collection,Siglum,Joint,OtherSiglum,ExpeditionCode,MainFindSpot,SpecificFindSpot,GeneralState,Description,Remark,LeafNumber")] OverallDescription overallDescription)
        {
            if (ModelState.IsValid)
            {
                db.OverallDescriptions.Add(overallDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(overallDescription);
        }

        // GET: BackOffice/OverallDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallDescription overallDescription = db.OverallDescriptions.Find(id);
            if (overallDescription == null)
            {
                return HttpNotFound();
            }
            return View(overallDescription);
        }

        // POST: BackOffice/OverallDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Collection,Siglum,Joint,OtherSiglum,ExpeditionCode,MainFindSpot,SpecificFindSpot,GeneralState,Description,Remark,LeafNumber")] OverallDescription overallDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(overallDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(overallDescription);
        }

        // GET: BackOffice/OverallDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallDescription overallDescription = db.OverallDescriptions.Find(id);
            if (overallDescription == null)
            {
                return HttpNotFound();
            }
            return View(overallDescription);
        }

        // POST: BackOffice/OverallDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OverallDescription overallDescription = db.OverallDescriptions.Find(id);
            db.OverallDescriptions.Remove(overallDescription);
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
