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
    public class DictionaryTochariansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/DictionaryTocharians
        public ActionResult Index()
        {
            return View(db.DictionaryTocharians.ToList());
        }

        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Find(id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }

        // GET: BackOffice/DictionaryTocharians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/DictionaryTocharians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word,English,Francaise,Sanskrit,Chinois,Vietnam,Description")] DictionaryTocharian dictionaryTocharian)
        {
            if (ModelState.IsValid)
            {
                db.DictionaryTocharians.Add(dictionaryTocharian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dictionaryTocharian);
        }

        // GET: BackOffice/DictionaryTocharians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Find(id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }

        // POST: BackOffice/DictionaryTocharians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word,English,Francaise,Sanskrit,Chinois,Vietnam,Description")] DictionaryTocharian dictionaryTocharian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dictionaryTocharian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dictionaryTocharian);
        }

        // GET: BackOffice/DictionaryTocharians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Find(id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }

        // POST: BackOffice/DictionaryTocharians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Find(id);
            db.DictionaryTocharians.Remove(dictionaryTocharian);
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
