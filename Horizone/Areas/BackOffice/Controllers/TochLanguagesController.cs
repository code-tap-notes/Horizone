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
    public class TochLanguagesController : BaseController
    {       
        // GET: BackOffice/TochLanguages
        public ActionResult Index()
        {
            return View(db.TochLanguages.ToList());
        }

        
        // GET: BackOffice/TochLanguages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TochLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Language")] TochLanguage tochLanguage)
        {
            if (ModelState.IsValid)
            {
                db.TochLanguages.Add(tochLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tochLanguage);
        }

        // GET: BackOffice/TochLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochLanguage tochLanguage = db.TochLanguages.Find(id);
            if (tochLanguage == null)
            {
                return HttpNotFound();
            }
            return View(tochLanguage);
        }

        // POST: BackOffice/TochLanguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Language")] TochLanguage tochLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tochLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tochLanguage);
        }

        // GET: BackOffice/TochLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochLanguage tochLanguage = db.TochLanguages.Find(id);
            if (tochLanguage == null)
            {
                return HttpNotFound();
            }
            return View(tochLanguage);
        }

        // POST: BackOffice/TochLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TochLanguage tochLanguage = db.TochLanguages.Find(id);
            db.TochLanguages.Remove(tochLanguage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
