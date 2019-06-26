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
    public class RulingDetailsController : BaseController
    {

        // GET: BackOffice/RulingDetails
        public ActionResult Index()
        {
            return View(db.RulingDetails.ToList());
        }

        

        // GET: BackOffice/RulingDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/RulingDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RulingDetailEn,RulingDetailFr,RulingDetailZh")] RulingDetail rulingDetail)
        {
            if (ModelState.IsValid)
            {
                db.RulingDetails.Add(rulingDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rulingDetail);
        }

        // GET: BackOffice/RulingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RulingDetail rulingDetail = db.RulingDetails.Find(id);
            if (rulingDetail == null)
            {
                return HttpNotFound();
            }
            return View(rulingDetail);
        }

        // POST: BackOffice/RulingDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RulingDetailEn,RulingDetailFr,RulingDetailZh")] RulingDetail rulingDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rulingDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rulingDetail);
        }

        // GET: BackOffice/RulingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RulingDetail rulingDetail = db.RulingDetails.Find(id);
            if (rulingDetail == null)
            {
                return HttpNotFound();
            }
            return View(rulingDetail);
        }

        // POST: BackOffice/RulingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RulingDetail rulingDetail = db.RulingDetails.Find(id);
            db.RulingDetails.Remove(rulingDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
