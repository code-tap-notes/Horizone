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
           
            TochStory tochStory = db.TochStorys.Include("SourceStory").Include("ThemeStory").SingleOrDefault(x => x.Id == id);
             
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
        }

        // GET: BackOffice/TochStories/Create
        public ActionResult Create()
        {
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "SourceEn");
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeEn), "Id", "ThemeEn");
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeFr), "Id", "ThemeFr");
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeZn), "Id", "ThemeZn");
            }
            return View();
        }

        // POST: BackOffice/TochStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SourceStoryId,ThemeStoryId,PlasticRepresentation,MainFindSpot,Content,English,Francaise,Chinese,Description,Visible")] TochStory tochStory )
        {
            if (ModelState.IsValid)
            {
                
                db.TochStorys.Add(tochStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                       
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "SourceEn", tochStory.SourceStoryId);
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            {

                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeEn), "Id", "ThemeEn", tochStory.ThemeStoryId);
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeFr), "Id", "ThemeFr", tochStory.ThemeStoryId);
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeZn), "Id", "ThemeZn", tochStory.ThemeStoryId);
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
            TochStory tochStory = db.TochStorys.Include("SourceStory").Include("ThemeStory").SingleOrDefault(x => x.Id == id); ;
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "SourceEn", tochStory.SourceStoryId);
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            {

                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeEn), "Id", "ThemeEn", tochStory.ThemeStoryId);
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeFr), "Id", "ThemeFr", tochStory.ThemeStoryId);
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeZn), "Id", "ThemeZn", tochStory.ThemeStoryId);
            }
            return View(tochStory);
        }

        // POST: BackOffice/TochStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SourceStoryId,ThemeStoryId,PlasticRepresentation,MainFindSpot,Content,English,Francaise,Chinese,Description,Visible")] TochStory tochStory)
        {
            db.Entry(tochStory).State = EntityState.Modified;
            db.TochStorys.SingleOrDefault(x => x.Id == tochStory.Id);
            if (ModelState.IsValid)
            {     
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.SourceStoryId = new SelectList(db.SourceStorys, "Id", "SourceEn", tochStory.SourceStoryId);
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            {

                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeEn), "Id", "ThemeEn", tochStory.ThemeStoryId);
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeFr), "Id", "ThemeFr", tochStory.ThemeStoryId);
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                ViewBag.ThemeStoryId = new SelectList(db.ThemeStorys.OrderBy(x => x.ThemeZn), "Id", "ThemeZn", tochStory.ThemeStoryId);
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

        // Search
             
        public ActionResult SearchStory(string search)
        {
            IEnumerable<TochStory> tochStories = db.TochStorys.Include("SourceStory").Include("ThemeStory");

            if (!string.IsNullOrWhiteSpace(search))
            {
                tochStories = tochStories.Where(x => x.English.Contains(search) || x.Francaise.Contains(search)
                || x.Content.Contains(search) || x.SourceStory.SourceEn.Contains(search) || x.Name.Contains(search) || x.Description.Contains(search)
                || x.ThemeStory.ThemeEn.Contains(search) || x.ThemeStory.ThemeFr.Contains(search) || x.ThemeStory.ThemeZn.Contains(search));
            }
            if (tochStories.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchStory", tochStories.OrderBy(x => x.Name).ToList());
        }

    }
}
