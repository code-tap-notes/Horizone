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
    public class ProveniencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/Proveniences
        public ActionResult Index()
        {
            return View(db.Proveniences.ToList());
        }

        // GET: BackOffice/Proveniences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provenience provenience = db.Proveniences.Find(id);
            if (provenience == null)
            {
                return HttpNotFound();
            }
            return View(provenience);
        }

        // GET: BackOffice/Proveniences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Proveniences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MainFindSpot,SpecificFindSpot,ExpeditionCode,Colection")] Provenience provenience)
        {
            if (ModelState.IsValid)
            {
                db.Proveniences.Add(provenience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provenience);
        }

        // GET: BackOffice/Proveniences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provenience provenience = db.Proveniences.Find(id);
            if (provenience == null)
            {
                return HttpNotFound();
            }
            return View(provenience);
        }

        // POST: BackOffice/Proveniences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MainFindSpot,SpecificFindSpot,ExpeditionCode,Colection")] Provenience provenience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provenience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provenience);
        }

        // GET: BackOffice/Proveniences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provenience provenience = db.Proveniences.Find(id);
            if (provenience == null)
            {
                return HttpNotFound();
            }
            return View(provenience);
        }

        // POST: BackOffice/Proveniences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provenience provenience = db.Proveniences.Find(id);
            db.Proveniences.Remove(provenience);
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
