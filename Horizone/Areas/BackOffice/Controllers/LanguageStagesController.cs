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
    public class LanguageStagesController : BaseController
    {       

        // GET: BackOffice/LanguageStages
        public ActionResult Index()
        {
            return View(db.LanguageStages.ToList());
        }

         

        // GET: BackOffice/LanguageStages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/LanguageStages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageStageEn,LanguageStageFr,LanguageStageZh")] LanguageStage languageStage)
        {
            if (ModelState.IsValid)
            {
                db.LanguageStages.Add(languageStage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languageStage);
        }

        // GET: BackOffice/LanguageStages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageStage languageStage = db.LanguageStages.Find(id);
            if (languageStage == null)
            {
                return HttpNotFound();
            }
            return View(languageStage);
        }

        // POST: BackOffice/LanguageStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageStageEn,LanguageStageFr,LanguageStageZh")] LanguageStage languageStage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageStage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languageStage);
        }

        // GET: BackOffice/LanguageStages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageStage languageStage = db.LanguageStages.Find(id);
            if (languageStage == null)
            {
                return HttpNotFound();
            }
            return View(languageStage);
        }

        // POST: BackOffice/LanguageStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LanguageStage languageStage = db.LanguageStages.Find(id);
            db.LanguageStages.Remove(languageStage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
