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
    public class TextLanguagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/TextLanguages
        public ActionResult Index()
        {
            return View(db.TextLanguages.ToList());
        }

        // GET: BackOffice/TextLanguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextLanguage textLanguage = db.TextLanguages.Find(id);
            if (textLanguage == null)
            {
                return HttpNotFound();
            }
            return View(textLanguage);
        }

        // GET: BackOffice/TextLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TextLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Language,LanguageStage,LanguageDetails")] TextLanguage textLanguage)
        {
            if (ModelState.IsValid)
            {
                db.TextLanguages.Add(textLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(textLanguage);
        }

        // GET: BackOffice/TextLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextLanguage textLanguage = db.TextLanguages.Find(id);
            if (textLanguage == null)
            {
                return HttpNotFound();
            }
            return View(textLanguage);
        }

        // POST: BackOffice/TextLanguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Language,LanguageStage,LanguageDetails")] TextLanguage textLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textLanguage);
        }

        // GET: BackOffice/TextLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextLanguage textLanguage = db.TextLanguages.Find(id);
            if (textLanguage == null)
            {
                return HttpNotFound();
            }
            return View(textLanguage);
        }

        // POST: BackOffice/TextLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextLanguage textLanguage = db.TextLanguages.Find(id);
            db.TextLanguages.Remove(textLanguage);
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
