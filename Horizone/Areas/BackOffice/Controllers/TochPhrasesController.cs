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
    public class TochPhrasesController : BaseController
    {

        // GET: BackOffice/TochPhrases
        public ActionResult Index()
        {
            var tochPhrases = db.TochPhrases.Include(t => t.TochLanguage);
            return View(tochPhrases.ToList());
        }

        
        // GET: BackOffice/TochPhrases/Create
        public ActionResult Create()
        {
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");
            return View();
        }

        // POST: BackOffice/TochPhrases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Phrase,English,Francaise,Chinese,TochLanguageId,DerivedFrom,RelatedLexemes,Description,Visible")] TochPhrase tochPhrase)
        {
            if (ModelState.IsValid)
            {
                db.TochPhrases.Add(tochPhrase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", tochPhrase.TochLanguageId);
            return View(tochPhrase);
        }

        // GET: BackOffice/TochPhrases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochPhrase tochPhrase = db.TochPhrases.Find(id);
            if (tochPhrase == null)
            {
                return HttpNotFound();
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", tochPhrase.TochLanguageId);
            return View(tochPhrase);
        }

        // POST: BackOffice/TochPhrases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Phrase,English,Francaise,Chinese,TochLanguageId,DerivedFrom,RelatedLexemes,Description,Visible")] TochPhrase tochPhrase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tochPhrase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", tochPhrase.TochLanguageId);
            return View(tochPhrase);
        }

        // GET: BackOffice/TochPhrases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochPhrase tochPhrase = db.TochPhrases.Find(id);
            if (tochPhrase == null)
            {
                return HttpNotFound();
            }
            return View(tochPhrase);
        }

        // POST: BackOffice/TochPhrases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TochPhrase tochPhrase = db.TochPhrases.Find(id);
            db.TochPhrases.Remove(tochPhrase);
            db.SaveChanges();
            return RedirectToAction("Index");
        }      
    }
}
