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
    public class BibliographiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/Bibliographies
        public ActionResult Index()
        {
            return View(db.Bibliographys.ToList());
        }

        // GET: BackOffice/Bibliographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliography bibliography = db.Bibliographys.Find(id);
            if (bibliography == null)
            {
                return HttpNotFound();
            }
            return View(bibliography);
        }

        // GET: BackOffice/Bibliographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Bibliographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,PublicationDate,Title,Journal,UlrBibliography")] Bibliography bibliography)
        {
            if (ModelState.IsValid)
            {
                db.Bibliographys.Add(bibliography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bibliography);
        }

        // GET: BackOffice/Bibliographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliography bibliography = db.Bibliographys.Find(id);
            if (bibliography == null)
            {
                return HttpNotFound();
            }
            return View(bibliography);
        }

        // POST: BackOffice/Bibliographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,PublicationDate,Title,Journal,UlrBibliography")] Bibliography bibliography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bibliography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bibliography);
        }

        // GET: BackOffice/Bibliographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliography bibliography = db.Bibliographys.Find(id);
            if (bibliography == null)
            {
                return HttpNotFound();
            }
            return View(bibliography);
        }

        // POST: BackOffice/Bibliographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bibliography bibliography = db.Bibliographys.Find(id);
            db.Bibliographys.Remove(bibliography);
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
