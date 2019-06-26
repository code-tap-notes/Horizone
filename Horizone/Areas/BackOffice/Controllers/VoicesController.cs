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
    public class VoicesController : BaseController
    {

        // GET: BackOffice/Voices
        public ActionResult Index()
        {
            return View(db.Voices.ToList());
        }

        // GET: BackOffice/Voices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Voices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AbbreviationVoice,VoiceEn,VoiceFr,VoiceZh")] Voice voice)
        {
            if (ModelState.IsValid)
            {
                db.Voices.Add(voice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voice);
        }

        // GET: BackOffice/Voices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voice voice = db.Voices.Find(id);
            if (voice == null)
            {
                return HttpNotFound();
            }
            return View(voice);
        }

        // POST: BackOffice/Voices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AbbreviationVoice,VoiceEn,VoiceFr,VoiceZh")] Voice voice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voice);
        }

        // GET: BackOffice/Voices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voice voice = db.Voices.Find(id);
            if (voice == null)
            {
                return HttpNotFound();
            }
            return View(voice);
        }

        // POST: BackOffice/Voices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voice voice = db.Voices.Find(id);
            db.Voices.Remove(voice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
