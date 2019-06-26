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
    public class SubGenderManuscriptsController : BaseController
    {

        // GET: BackOffice/SubGenderManuscripts
        public ActionResult Index()
        {
            return View(db.SubGenderManuscripts.ToList());
        }

        
        // GET: BackOffice/SubGenderManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/SubGenderManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubGenderEn,NameGenderFr,NameGenderZh")] SubGenderManuscript subGenderManuscript)
        {
            if (ModelState.IsValid)
            {
                db.SubGenderManuscripts.Add(subGenderManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subGenderManuscript);
        }

        // GET: BackOffice/SubGenderManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGenderManuscript subGenderManuscript = db.SubGenderManuscripts.Find(id);
            if (subGenderManuscript == null)
            {
                return HttpNotFound();
            }
            return View(subGenderManuscript);
        }

        // POST: BackOffice/SubGenderManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubGenderEn,NameGenderFr,NameGenderZh")] SubGenderManuscript subGenderManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subGenderManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subGenderManuscript);
        }

        // GET: BackOffice/SubGenderManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubGenderManuscript subGenderManuscript = db.SubGenderManuscripts.Find(id);
            if (subGenderManuscript == null)
            {
                return HttpNotFound();
            }
            return View(subGenderManuscript);
        }

        // POST: BackOffice/SubGenderManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubGenderManuscript subGenderManuscript = db.SubGenderManuscripts.Find(id);
            db.SubGenderManuscripts.Remove(subGenderManuscript);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
