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
    public class ThemeStoriesController : BaseController
    {
      
        // GET: BackOffice/ThemeStories
        public ActionResult Index()
        {
            return View(db.ThemeStorys.ToList());
        }

         
        // GET: BackOffice/ThemeStories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ThemeStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ThemeEn,ThemeFr,ThemeZn")] ThemeStory themeStory)
        {
            if (ModelState.IsValid)
            {
                db.ThemeStorys.Add(themeStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(themeStory);
        }

        // GET: BackOffice/ThemeStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThemeStory themeStory = db.ThemeStorys.Find(id);
            if (themeStory == null)
            {
                return HttpNotFound();
            }
            return View(themeStory);
        }

        // POST: BackOffice/ThemeStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ThemeEn,ThemeFr,ThemeZn")] ThemeStory themeStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(themeStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(themeStory);
        }

        // GET: BackOffice/ThemeStories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThemeStory themeStory = db.ThemeStorys.Find(id);
            if (themeStory == null)
            {
                return HttpNotFound();
            }
            return View(themeStory);
        }

        // POST: BackOffice/ThemeStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThemeStory themeStory = db.ThemeStorys.Find(id);
            db.ThemeStorys.Remove(themeStory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
