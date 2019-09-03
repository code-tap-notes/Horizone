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
    public class NamePlacesController : BaseController
    {       
        // GET: BackOffice/NamePlaces
        public ActionResult Index()
        {
            return View(db.NamePlaces.OrderBy(x => x.Place).ToList());
        }

         
        // GET: BackOffice/NamePlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/NamePlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Place,DescriptionEn,DescriptionFr,DescriptionZh")] NamePlace namePlace)
        {
            if (ModelState.IsValid)
            {
                db.NamePlaces.Add(namePlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(namePlace);
        }

        // GET: BackOffice/NamePlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NamePlace namePlace = db.NamePlaces.Find(id);
            if (namePlace == null)
            {
                return HttpNotFound();
            }
            return View(namePlace);
        }

        // POST: BackOffice/NamePlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Place,DescriptionEn,DescriptionFr,DescriptionZh")] NamePlace namePlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(namePlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(namePlace);
        }

        // GET: BackOffice/NamePlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NamePlace namePlace = db.NamePlaces.Find(id);
            if (namePlace == null)
            {
                return HttpNotFound();
            }
            return View(namePlace);
        }
        // POST: BackOffice/NamePlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NamePlace namePlace = db.NamePlaces.Find(id);
            db.NamePlaces.Remove(namePlace);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
