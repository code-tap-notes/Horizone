using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;
using Horizone.Controllers;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class WordClassesController : BaseController
    {
      
        // GET: BackOffice/WordClasses
        public ActionResult Index()
        {
            return View(db.WordClasses.ToList());
        }

        // GET: BackOffice/WordClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordClass wordClass = db.WordClasses.Find(id);
            if (wordClass == null)
            {
                return HttpNotFound();
            }
            return View(wordClass);
        }

        // GET: BackOffice/WordClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/WordClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Class,ClassEn,ClassFr,ClassZh")] WordClass wordClass)
        {
            if (ModelState.IsValid)
            {
                db.WordClasses.Add(wordClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wordClass);
        }

        // GET: BackOffice/WordClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordClass wordClass = db.WordClasses.Find(id);
            if (wordClass == null)
            {
                return HttpNotFound();
            }
            return View(wordClass);
        }

        // POST: BackOffice/WordClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Class,ClassEn,ClassFr,ClassZh")] WordClass wordClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wordClass);
        }

        // GET: BackOffice/WordClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordClass wordClass = db.WordClasses.Find(id);
            if (wordClass == null)
            {
                return HttpNotFound();
            }
            return View(wordClass);
        }

        // POST: BackOffice/WordClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WordClass wordClass = db.WordClasses.Find(id);
            db.WordClasses.Remove(wordClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
