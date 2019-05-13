using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Controllers;
using Horizone.Models;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class WordSubClassesController : BaseController
    {

        // GET: BackOffice/WordSubClasses
        public ActionResult Index()
        {
            var wordSubClasses = db.WordSubClasses.Include(w => w.WordClass);
            return View(wordSubClasses.ToList());
        }

        // GET: BackOffice/WordSubClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordSubClass wordSubClass = db.WordSubClasses.Find(id);
            if (wordSubClass == null)
            {
                return HttpNotFound();
            }
            return View(wordSubClass);
        }

        // GET: BackOffice/WordSubClasses/Create
        public ActionResult Create()
        {
            ViewBag.WordClassId = new SelectList(db.WordClasses, "Id", "Class");
            return View();
        }

        // POST: BackOffice/WordSubClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubClass,SubClassEn,SubClassFr,SubClassZh,WordClassId")] WordSubClass wordSubClass)
        {
            if (ModelState.IsValid)
            {
                db.WordSubClasses.Add(wordSubClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WordClassId = new SelectList(db.WordClasses, "Id", "Class", wordSubClass.WordClassId);
            return View(wordSubClass);
        }

        // GET: BackOffice/WordSubClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordSubClass wordSubClass = db.WordSubClasses.Find(id);
            if (wordSubClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.WordClassId = new SelectList(db.WordClasses, "Id", "Class", wordSubClass.WordClassId);
            return View(wordSubClass);
        }

        // POST: BackOffice/WordSubClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubClass,SubClassEn,SubClassFr,SubClassZh,WordClassId")] WordSubClass wordSubClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wordSubClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WordClassId = new SelectList(db.WordClasses, "Id", "Class", wordSubClass.WordClassId);
            return View(wordSubClass);
        }

        // GET: BackOffice/WordSubClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WordSubClass wordSubClass = db.WordSubClasses.Find(id);
            if (wordSubClass == null)
            {
                return HttpNotFound();
            }
            return View(wordSubClass);
        }

        // POST: BackOffice/WordSubClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WordSubClass wordSubClass = db.WordSubClasses.Find(id);
            db.WordSubClasses.Remove(wordSubClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
