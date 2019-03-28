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
    public class VisualAidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/VisualAids
        public ActionResult Index()
        {
            var visualAids = db.VisualAids.Include(v => v.Language);
            return View(visualAids.ToList());
        }

        // GET: BackOffice/VisualAids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisualAid visualAid = db.VisualAids.Find(id);
            if (visualAid == null)
            {
                return HttpNotFound();
            }
            return View(visualAid);
        }

        // GET: BackOffice/VisualAids/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            return View();
        }

        // POST: BackOffice/VisualAids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Aids,Description,Photography,Map,LanguageId")] VisualAid visualAid)
        {
            if (ModelState.IsValid)
            {
                db.VisualAids.Add(visualAid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", visualAid.LanguageId);
            return View(visualAid);
        }

        // GET: BackOffice/VisualAids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisualAid visualAid = db.VisualAids.Find(id);
            if (visualAid == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", visualAid.LanguageId);
            return View(visualAid);
        }

        // POST: BackOffice/VisualAids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aids,Description,Photography,Map,LanguageId")] VisualAid visualAid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visualAid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", visualAid.LanguageId);
            return View(visualAid);
        }

        // GET: BackOffice/VisualAids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisualAid visualAid = db.VisualAids.Find(id);
            if (visualAid == null)
            {
                return HttpNotFound();
            }
            return View(visualAid);
        }

        // POST: BackOffice/VisualAids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisualAid visualAid = db.VisualAids.Find(id);
            db.VisualAids.Remove(visualAid);
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
