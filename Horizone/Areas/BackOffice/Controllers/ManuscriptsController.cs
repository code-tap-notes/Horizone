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
    public class ManuscriptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/Manuscripts
        public ActionResult Index()
        {
            var manuscripts = db.Manuscripts.Include(m => m.ObjectManuscript).Include(m => m.Provenience).Include(m => m.TextContent);
            return View(manuscripts.ToList());
        }

        // GET: BackOffice/Manuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Find(id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }

        // GET: BackOffice/Manuscripts/Create
        public ActionResult Create()
        {
            ViewBag.ObjectManuscriptId = new SelectList(db.ObjectManuscripts, "Id", "Manuscript");
            ViewBag.ProvenienceId = new SelectList(db.Proveniences, "Id", "MainFindSpot");
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TitleOfTheWork");
            return View();
        }

        // POST: BackOffice/Manuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Index,Language,Script,Repository,Shelfmark,TranslateEnglish,TranslateFrench,TranslateChinese,Description,Editor,Bibliography,ProvenienceId,TextContentId,ObjectManuscriptId")] Manuscript manuscript)
        {
            if (ModelState.IsValid)
            {
                db.Manuscripts.Add(manuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjectManuscriptId = new SelectList(db.ObjectManuscripts, "Id", "Manuscript", manuscript.ObjectManuscriptId);
            ViewBag.ProvenienceId = new SelectList(db.Proveniences, "Id", "MainFindSpot", manuscript.ProvenienceId);
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TitleOfTheWork", manuscript.TextContentId);
            return View(manuscript);
        }

        // GET: BackOffice/Manuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Find(id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjectManuscriptId = new SelectList(db.ObjectManuscripts, "Id", "Manuscript", manuscript.ObjectManuscriptId);
            ViewBag.ProvenienceId = new SelectList(db.Proveniences, "Id", "MainFindSpot", manuscript.ProvenienceId);
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TitleOfTheWork", manuscript.TextContentId);
            return View(manuscript);
        }

        // POST: BackOffice/Manuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Index,Language,Script,Repository,Shelfmark,TranslateEnglish,TranslateFrench,TranslateChinese,Description,Editor,Bibliography,ProvenienceId,TextContentId,ObjectManuscriptId")] Manuscript manuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjectManuscriptId = new SelectList(db.ObjectManuscripts, "Id", "Manuscript", manuscript.ObjectManuscriptId);
            ViewBag.ProvenienceId = new SelectList(db.Proveniences, "Id", "MainFindSpot", manuscript.ProvenienceId);
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TitleOfTheWork", manuscript.TextContentId);
            return View(manuscript);
        }

        // GET: BackOffice/Manuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Find(id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }

        // POST: BackOffice/Manuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manuscript manuscript = db.Manuscripts.Find(id);
            db.Manuscripts.Remove(manuscript);
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
