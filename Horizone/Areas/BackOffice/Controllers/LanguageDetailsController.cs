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
    public class LanguageDetailsController : BaseController
    {
       

        // GET: BackOffice/LanguageDetails
        public ActionResult Index()
        {
            return View(db.LanguageDetails.ToList());
        }

         
        // GET: BackOffice/LanguageDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/LanguageDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LanguageDetailEn,LanguageDetailFr,LanguageDetailZh")] LanguageDetail languageDetail)
        {
            if (ModelState.IsValid)
            {
                db.LanguageDetails.Add(languageDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(languageDetail);
        }

        // GET: BackOffice/LanguageDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageDetail languageDetail = db.LanguageDetails.Find(id);
            if (languageDetail == null)
            {
                return HttpNotFound();
            }
            return View(languageDetail);
        }

        // POST: BackOffice/LanguageDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LanguageDetailEn,LanguageDetailFr,LanguageDetailZh")] LanguageDetail languageDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languageDetail);
        }

        // GET: BackOffice/LanguageDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageDetail languageDetail = db.LanguageDetails.Find(id);
            if (languageDetail == null)
            {
                return HttpNotFound();
            }
            return View(languageDetail);
        }

        // POST: BackOffice/LanguageDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LanguageDetail languageDetail = db.LanguageDetails.Find(id);
            db.LanguageDetails.Remove(languageDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
