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
    public class ThemeStoriesController : BaseController
    {
      
        // GET: BackOffice/ThemeStories
        public ActionResult Index()
        {
            return View(db.ThemeStorys.OrderBy(x => x.ThemeEn).ToList());
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
        
        public ActionResult SearchTheme(string search)
        {
            IEnumerable<ThemeStory> themeStorys = db.ThemeStorys;

            if (!string.IsNullOrWhiteSpace(search))
            {
                themeStorys = themeStorys.Where(x => x.ThemeEn.Contains(search) || x.ThemeFr.Contains(search) || x.ThemeZn.Contains(search));
            }
            if (themeStorys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            {
                themeStorys.OrderBy(x => x.ThemeEn).ToList();
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                themeStorys.OrderBy(x => x.ThemeFr).ToList();
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                themeStorys.OrderBy(x => x.ThemeZn).ToList();
            }

            return View("SearchTheme", themeStorys);
        }
    }
}
