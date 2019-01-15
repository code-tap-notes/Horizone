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
    [Authorize(Roles = "Colaborator,Admin")]
    public class TranscriptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/Transcriptions
        public ActionResult Index()
        {
            var transcriptions = db.Transcriptions.Include(t => t.Manuscript).Include(t => t.TochPhrase).Include(t => t.TochStory);
            return View(transcriptions.ToList());
        }

        // GET: BackOffice/Transcriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcription transcription = db.Transcriptions.Find(id);
            if (transcription == null)
            {
                return HttpNotFound();
            }
            return View(transcription);
        }

        // GET: BackOffice/Transcriptions/Create
        public ActionResult Create()
        {
            ViewBag.ManuscriptId = new SelectList(db.Manuscripts, "Id", "Index");
            ViewBag.TochPhraseId = new SelectList(db.TochPhrases, "Id", "Index");
            ViewBag.TochStoryId = new SelectList(db.TochStorys, "Id", "Name");
            return View();
        }

        // POST: BackOffice/Transcriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,TochStoryId,TochPhraseId,ManuscriptId")] Transcription transcription)
        {
            if (ModelState.IsValid)
            {
                db.Transcriptions.Add(transcription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManuscriptId = new SelectList(db.Manuscripts, "Id", "Index", transcription.ManuscriptId);
            ViewBag.TochPhraseId = new SelectList(db.TochPhrases, "Id", "Index", transcription.TochPhraseId);
            ViewBag.TochStoryId = new SelectList(db.TochStorys, "Id", "Name", transcription.TochStoryId);
            return View(transcription);
        }

        // GET: BackOffice/Transcriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcription transcription = db.Transcriptions.Find(id);
            if (transcription == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManuscriptId = new SelectList(db.Manuscripts, "Id", "Index", transcription.ManuscriptId);
            ViewBag.TochPhraseId = new SelectList(db.TochPhrases, "Id", "Index", transcription.TochPhraseId);
            ViewBag.TochStoryId = new SelectList(db.TochStorys, "Id", "Name", transcription.TochStoryId);
            return View(transcription);
        }

        // POST: BackOffice/Transcriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,TochStoryId,TochPhraseId,ManuscriptId")] Transcription transcription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transcription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManuscriptId = new SelectList(db.Manuscripts, "Id", "Index", transcription.ManuscriptId);
            ViewBag.TochPhraseId = new SelectList(db.TochPhrases, "Id", "Index", transcription.TochPhraseId);
            ViewBag.TochStoryId = new SelectList(db.TochStorys, "Id", "Name", transcription.TochStoryId);
            return View(transcription);
        }

        // GET: BackOffice/Transcriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transcription transcription = db.Transcriptions.Find(id);
            if (transcription == null)
            {
                return HttpNotFound();
            }
            return View(transcription);
        }

        // POST: BackOffice/Transcriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transcription transcription = db.Transcriptions.Find(id);
            db.Transcriptions.Remove(transcription);
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
