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
    public class TochStoriesController : BaseController
    {
        
        // GET: BackOffice/TochStories
        public ActionResult Index()
        {
            var tochStorys = db.TochStorys.Include(t => t.Language).Include(t => t.NamePlace).Include(t => t.ProperNoun).Include(t => t.SourceStory).Include(t => t.ThemeStory);
            return View(tochStorys.ToList());
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
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            ViewBag.NamePlaceId = new SelectList(db.NamePlaces, "Id", "PlaceEn");
            ViewBag.SourceStoryId = new SelectList(db.ProperNouns, "Id", "Name");
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source");
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn");
            return View();
        }

        // POST: BackOffice/TochStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SourceStoryId,ProperNounId,ThemeStoryId,NamePlaceId,PlasticRepresentation,MainFindSpot,Content,English,Francaise,Chinese,Description,Visible,LanguageId")] TochStory tochStory)
        {
            if (ModelState.IsValid)
            {
                db.TochStorys.Add(tochStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", tochStory.LanguageId);
            ViewBag.NamePlaceId = new SelectList(db.NamePlaces, "Id", "PlaceEn", tochStory.NamePlaceId);
            ViewBag.SourceStoryId = new SelectList(db.ProperNouns, "Id", "Name", tochStory.SourceStoryId);
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source", tochStory.SourceStoryId);
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn", tochStory.ThemeStoryId);
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
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", tochStory.LanguageId);
            ViewBag.NamePlaceId = new SelectList(db.NamePlaces, "Id", "PlaceEn", tochStory.NamePlaceId);
            ViewBag.SourceStoryId = new SelectList(db.ProperNouns, "Id", "Name", tochStory.SourceStoryId);
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source", tochStory.SourceStoryId);
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn", tochStory.ThemeStoryId);
            return View(tochStory);
        }

        // POST: BackOffice/TochStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SourceStoryId,ProperNounId,ThemeStoryId,NamePlaceId,PlasticRepresentation,MainFindSpot,Content,English,Francaise,Chinese,Description,Visible,LanguageId")] TochStory tochStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tochStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", tochStory.LanguageId);
            ViewBag.NamePlaceId = new SelectList(db.NamePlaces, "Id", "PlaceEn", tochStory.NamePlaceId);
            ViewBag.SourceStoryId = new SelectList(db.ProperNouns, "Id", "Name", tochStory.SourceStoryId);
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source", tochStory.SourceStoryId);
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn", tochStory.ThemeStoryId);
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

    }
}
