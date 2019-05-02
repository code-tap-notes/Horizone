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
    public class DryingsController : BaseController
    {

        // GET: BackOffice/Dryings
        public ActionResult Index()
        {
            return View(db.Dryings.ToList());
        }

        // GET: BackOffice/Dryings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drying drying = db.Dryings.Find(id);
            if (drying == null)
            {
                return HttpNotFound();
            }
            return View(drying);
        }

        // GET: BackOffice/Dryings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Dryings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DryingEn,DryingFr,DryingZh")] Drying drying)
        {
            if (ModelState.IsValid)
            {
                db.Dryings.Add(drying);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drying);
        }

        // GET: BackOffice/Dryings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drying drying = db.Dryings.Find(id);
            if (drying == null)
            {
                return HttpNotFound();
            }
            return View(drying);
        }

        // POST: BackOffice/Dryings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DryingEn,DryingFr,DryingZh")] Drying drying)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drying).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drying);
        }

        // GET: BackOffice/Dryings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drying drying = db.Dryings.Find(id);
            if (drying == null)
            {
                return HttpNotFound();
            }
            return View(drying);
        }

        // POST: BackOffice/Dryings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drying drying = db.Dryings.Find(id);
            db.Dryings.Remove(drying);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
