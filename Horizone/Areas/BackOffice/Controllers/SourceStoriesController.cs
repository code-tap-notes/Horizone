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
    public class SourceStoriesController : BaseController
    {      
        // GET: BackOffice/SourceStories
        public ActionResult Index()
        {
            return View(db.SourceStorys.ToList());
        }
        // GET: BackOffice/SourceStories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceStory sourceStory = db.SourceStorys.Find(id);
            if (sourceStory == null)
            {
                return HttpNotFound();
            }
            return View(sourceStory);
        }

        // GET: BackOffice/SourceStories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/SourceStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Source")] SourceStory sourceStory)
        {
            if (ModelState.IsValid)
            {
                db.SourceStorys.Add(sourceStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sourceStory);
        }
        // GET: BackOffice/SourceStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceStory sourceStory = db.SourceStorys.Find(id);
            if (sourceStory == null)
            {
                return HttpNotFound();
            }
            return View(sourceStory);
        }
        // POST: BackOffice/SourceStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Source")] SourceStory sourceStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sourceStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sourceStory);
        }
        // GET: BackOffice/SourceStories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceStory sourceStory = db.SourceStorys.Find(id);
            if (sourceStory == null)
            {
                return HttpNotFound();
            }
            return View(sourceStory);
        }
        // POST: BackOffice/SourceStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SourceStory sourceStory = db.SourceStorys.Find(id);
            db.SourceStorys.Remove(sourceStory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
