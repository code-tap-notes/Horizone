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
    public class GenderManuscriptsController : BaseController
    {

        // GET: BackOffice/GenderManuscripts
        public ActionResult Index()
        {
            return View(db.GenderManuscripts.ToList());
        }

        // GET: BackOffice/GenderManuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderManuscript genderManuscript = db.GenderManuscripts.Find(id);
            if (genderManuscript == null)
            {
                return HttpNotFound();
            }
            return View(genderManuscript);
        }

        // GET: BackOffice/GenderManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/GenderManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameGenderEn,NameGenderFr,NameGenderZh")] GenderManuscript genderManuscript)
        {
            if (ModelState.IsValid)
            {
                db.GenderManuscripts.Add(genderManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genderManuscript);
        }

        // GET: BackOffice/GenderManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderManuscript genderManuscript = db.GenderManuscripts.Find(id);
            if (genderManuscript == null)
            {
                return HttpNotFound();
            }
            return View(genderManuscript);
        }

        // POST: BackOffice/GenderManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameGenderEn,NameGenderFr,NameGenderZh")] GenderManuscript genderManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genderManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genderManuscript);
        }

        // GET: BackOffice/GenderManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderManuscript genderManuscript = db.GenderManuscripts.Find(id);
            if (genderManuscript == null)
            {
                return HttpNotFound();
            }
            return View(genderManuscript);
        }

        // POST: BackOffice/GenderManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenderManuscript genderManuscript = db.GenderManuscripts.Find(id);
            db.GenderManuscripts.Remove(genderManuscript);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
