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
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/Activities
        public ActionResult Index()
        {
            var activitys = db.Activitys.Include(a => a.Language).Include(a => a.Topic);
            return View(activitys.ToList());
        }

        // GET: BackOffice/Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activitys.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: BackOffice/Activities/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn");
            return View();
        }

        // POST: BackOffice/Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateofActivity,Place,NameActivity,Description,UlrActivity,Picture,TopicId,LanguageId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activitys.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", activity.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn", activity.TopicId);
            return View(activity);
        }

        // GET: BackOffice/Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activitys.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", activity.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn", activity.TopicId);
            return View(activity);
        }

        // POST: BackOffice/Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateofActivity,Place,NameActivity,Description,UlrActivity,Picture,TopicId,LanguageId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", activity.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn", activity.TopicId);
            return View(activity);
        }

        // GET: BackOffice/Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activitys.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: BackOffice/Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activitys.Find(id);
            db.Activitys.Remove(activity);
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
