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
    public class DescriptionManuscriptsController : BaseController
    {

        // GET: BackOffice/DescriptionManuscripts
        public ActionResult Index()
        {
            return View(db.DescriptionManuscripts.ToList());
        }
 
        // GET: BackOffice/DescriptionManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/DescriptionManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescriptionEn,DescriptionFr,DescriptionZh")] DescriptionManuscript descriptionManuscript)
        {
            if (ModelState.IsValid)
            {
                db.DescriptionManuscripts.Add(descriptionManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(descriptionManuscript);
        }

        // GET: BackOffice/DescriptionManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionManuscript descriptionManuscript = db.DescriptionManuscripts.Find(id);
            if (descriptionManuscript == null)
            {
                return HttpNotFound();
            }
            return View(descriptionManuscript);
        }

        // POST: BackOffice/DescriptionManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescriptionEn,DescriptionFr,DescriptionZh")] DescriptionManuscript descriptionManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descriptionManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descriptionManuscript);
        }

        // GET: BackOffice/DescriptionManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionManuscript descriptionManuscript = db.DescriptionManuscripts.Find(id);
            if (descriptionManuscript == null)
            {
                return HttpNotFound();
            }
            return View(descriptionManuscript);
        }

        // POST: BackOffice/DescriptionManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DescriptionManuscript descriptionManuscript = db.DescriptionManuscripts.Find(id);
            db.DescriptionManuscripts.Remove(descriptionManuscript);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
