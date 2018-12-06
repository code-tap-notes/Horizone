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
    public class TochStoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/TochStories
        public ActionResult Index()
        {
            return View(db.TochStorys.ToList());
        }

        // GET: BackOffice/TochStories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochStory tochStory = db.TochStorys.Find(id);
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
        }

        // GET: BackOffice/TochStories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TochStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContentEnglish,ContentFrancaise,ContentChinese,ContentVietnam,Description")] TochStory tochStory)
        {
            if (ModelState.IsValid)
            {
                db.TochStorys.Add(tochStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tochStory);
        }

        // GET: BackOffice/TochStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochStory tochStory = db.TochStorys.Find(id);
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
        }

        // POST: BackOffice/TochStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContentEnglish,ContentFrancaise,ContentChinese,ContentVietnam,Description")] TochStory tochStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tochStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tochStory);
        }

        // GET: BackOffice/TochStories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochStory tochStory = db.TochStorys.Find(id);
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
        }

        // POST: BackOffice/TochStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TochStory tochStory = db.TochStorys.Find(id);
            db.TochStorys.Remove(tochStory);
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
