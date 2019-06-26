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
    public class TenseAndAspectsController : BaseController
    {

        // GET: BackOffice/TenseAndAspects
        public ActionResult Index()
        {
            return View(db.TenseAndAspects.ToList());
        }

        // GET: BackOffice/TenseAndAspects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TenseAndAspects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tense,TenseEn,TenseFr,TenseZh")] TenseAndAspect tenseAndAspect)
        {
            if (ModelState.IsValid)
            {
                db.TenseAndAspects.Add(tenseAndAspect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tenseAndAspect);
        }

        // GET: BackOffice/TenseAndAspects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenseAndAspect tenseAndAspect = db.TenseAndAspects.Find(id);
            if (tenseAndAspect == null)
            {
                return HttpNotFound();
            }
            return View(tenseAndAspect);
        }

        // POST: BackOffice/TenseAndAspects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tense,TenseEn,TenseFr,TenseZh")] TenseAndAspect tenseAndAspect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenseAndAspect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenseAndAspect);
        }

        // GET: BackOffice/TenseAndAspects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TenseAndAspect tenseAndAspect = db.TenseAndAspects.Find(id);
            if (tenseAndAspect == null)
            {
                return HttpNotFound();
            }
            return View(tenseAndAspect);
        }

        // POST: BackOffice/TenseAndAspects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TenseAndAspect tenseAndAspect = db.TenseAndAspects.Find(id);
            db.TenseAndAspects.Remove(tenseAndAspect);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
