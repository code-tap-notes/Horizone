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
    public class FiberDirectionsController : BaseController
    {

        // GET: BackOffice/FiberDirections
        public ActionResult Index()
        {
            return View(db.FiberDirections.ToList());
        }

        

        // GET: BackOffice/FiberDirections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/FiberDirections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DirectionEn,DirectionFr,DirectionZh")] FiberDirection fiberDirection)
        {
            if (ModelState.IsValid)
            {
                db.FiberDirections.Add(fiberDirection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiberDirection);
        }

        // GET: BackOffice/FiberDirections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiberDirection fiberDirection = db.FiberDirections.Find(id);
            if (fiberDirection == null)
            {
                return HttpNotFound();
            }
            return View(fiberDirection);
        }

        // POST: BackOffice/FiberDirections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DirectionEn,DirectionFr,DirectionZh")] FiberDirection fiberDirection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiberDirection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiberDirection);
        }

        // GET: BackOffice/FiberDirections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiberDirection fiberDirection = db.FiberDirections.Find(id);
            if (fiberDirection == null)
            {
                return HttpNotFound();
            }
            return View(fiberDirection);
        }

        // POST: BackOffice/FiberDirections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FiberDirection fiberDirection = db.FiberDirections.Find(id);
            db.FiberDirections.Remove(fiberDirection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
