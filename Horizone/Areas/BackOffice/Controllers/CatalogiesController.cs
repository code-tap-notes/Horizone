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
    public class CatalogiesController : BaseController
    {

        // GET: BackOffice/Catalogies
        public ActionResult Index()
        {
            return View(db.Catalogies.ToList());
        }

        
        // GET: BackOffice/Catalogies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Catalogies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Catalogie catalogie)
        {
            if (ModelState.IsValid)
            {
                db.Catalogies.Add(catalogie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalogie);
        }

        // GET: BackOffice/Catalogies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogie catalogie = db.Catalogies.Find(id);
            if (catalogie == null)
            {
                return HttpNotFound();
            }
            return View(catalogie);
        }

        // POST: BackOffice/Catalogies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Catalogie catalogie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalogie);
        }

        // GET: BackOffice/Catalogies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalogie catalogie = db.Catalogies.Find(id);
            if (catalogie == null)
            {
                return HttpNotFound();
            }
            return View(catalogie);
        }

        // POST: BackOffice/Catalogies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalogie catalogie = db.Catalogies.Find(id);
            db.Catalogies.Remove(catalogie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
