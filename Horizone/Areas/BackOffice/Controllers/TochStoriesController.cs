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
    [Authorize(Roles = "Collaborator,Admin")]
    public class TochStoriesController : BaseController
    {

        // GET: BackOffice/TochStories
        public ActionResult Index()
        {
            var tochStorys = db.TochStorys.Include(t => t.SourceStory).Include(t => t.ThemeStory);
            return View(tochStorys.ToList());
        }

        // GET: BackOffice/TochStories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            TochStory tochStory = db.TochStorys.Include("SourceStory").Include("ThemeStory").Include("NamePlaces").Include("ProperNouns").SingleOrDefault(x => x.Id == id);
            if (tochStory.NamePlaces.Count() == 0)
                tochStory.NamePlaces = db.NamePlaces.Where(x => x.PlaceEn == "NA").ToList();
            if (tochStory.ProperNouns.Count() == 0)
                tochStory.ProperNouns = db.ProperNouns.Where(x => x.Name == "NA").ToList();
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
        }

        // GET: BackOffice/TochStories/Create
        public ActionResult Create()
        {
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source");
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn");
            MultiSelectList PlaceValues = new MultiSelectList(db.NamePlaces, "Id", "PlaceEn");
            ViewBag.NamePlaces = PlaceValues;
            MultiSelectList NounValues = new MultiSelectList(db.ProperNouns, "Id", "Name");
            ViewBag.ProperNouns = NounValues;
            return View();
        }

        // POST: BackOffice/TochStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SourceStoryId,ThemeStoryId,PlasticRepresentation,MainFindSpot,Content,English,Francaise,Chinese,Description,Visible")] TochStory tochStory, int[] NamePlaceId, int[] ProperNounId)
        {
            if (ModelState.IsValid)
            {
                if (NamePlaceId.Count() > 0)
                    tochStory.NamePlaces = db.NamePlaces.Where(x => NamePlaceId.Contains(x.Id)).ToList();
                if (NamePlaceId.Count() == 0)
                    tochStory.NamePlaces = db.NamePlaces.Where(x => x.PlaceEn == "NA").ToList();

                if (ProperNounId.Count() > 0)
                    tochStory.ProperNouns = db.ProperNouns.Where(x => ProperNounId.Contains(x.Id)).ToList();
                if (ProperNounId.Count() == 0)
                    tochStory.ProperNouns = db.ProperNouns.Where(x => x.Name == "NA").ToList();

                db.TochStorys.Add(tochStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                       
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source", tochStory.SourceStoryId);
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn", tochStory.ThemeStoryId);
            MultiSelectList PlaceValues = new MultiSelectList(db.NamePlaces, "Id", "PlaceEn");
            ViewBag.NamePlaces = PlaceValues;
            MultiSelectList NounValues = new MultiSelectList(db.ProperNouns, "Id", "Name");
            ViewBag.ProperNouns = NounValues;
            return View(tochStory);
        }

        // GET: BackOffice/TochStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochStory tochStory = db.TochStorys.Include("NamePlaces").Include("ProperNouns").SingleOrDefault(x => x.Id == id); ;
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source", tochStory.SourceStoryId);
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn", tochStory.ThemeStoryId);
            MultiSelectList PlaceValues = new MultiSelectList(db.NamePlaces, "Id", "PlaceEn");
            ViewBag.NamePlaces = PlaceValues;
            MultiSelectList NounValues = new MultiSelectList(db.ProperNouns, "Id", "Name");
            ViewBag.ProperNouns = NounValues;
            return View(tochStory);
        }

        // POST: BackOffice/TochStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SourceStoryId,ThemeStoryId,PlasticRepresentation,MainFindSpot,Content,English,Francaise,Chinese,Description,Visible")] TochStory tochStory, int[] NamePlaceId, int[] ProperNounId)
        {
            db.Entry(tochStory).State = EntityState.Modified;
            db.TochStorys.Include("NamePlaces").Include("ProperNouns").SingleOrDefault(x => x.Id == tochStory.Id);
            if (ModelState.IsValid)
            {
                if (NamePlaceId != null)
                    tochStory.NamePlaces = db.NamePlaces.Where(x => NamePlaceId.Contains(x.Id)).ToList();
                else
                    tochStory.NamePlaces = db.NamePlaces.Where(x => x.PlaceEn == "NA").ToList();
                if (ProperNounId != null)
                    tochStory.ProperNouns = db.ProperNouns.Where(x => ProperNounId.Contains(x.Id)).ToList();
                else
                    tochStory.ProperNouns = db.ProperNouns.Where(x => x.Name == "NA").ToList();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "Source", tochStory.SourceStoryId);
            ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys, "Id", "ThemeEn", tochStory.ThemeStoryId);
            MultiSelectList PlaceValues = new MultiSelectList(db.NamePlaces, "Id", "PlaceEn");
            ViewBag.NamePlaces = PlaceValues;
            MultiSelectList NounValues = new MultiSelectList(db.ProperNouns, "Id", "Name");
            ViewBag.ProperNouns = NounValues; return View(tochStory);
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
