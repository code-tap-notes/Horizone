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
    public class RestoresController : BaseController
    {

        // GET: BackOffice/Restores
        public ActionResult Index()
        {
            return View(db.Restores.ToList());
        }

        
        // GET: BackOffice/Restores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Restores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RestoreEn,RestoreFr,RestoreZh")] Restore restore)
        {
            if (ModelState.IsValid)
            {
                db.Restores.Add(restore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restore);
        }

        // GET: BackOffice/Restores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restore restore = db.Restores.Find(id);
            if (restore == null)
            {
                return HttpNotFound();
            }
            return View(restore);
        }

        // POST: BackOffice/Restores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RestoreEn,RestoreFr,RestoreZh")] Restore restore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restore);
        }

        // GET: BackOffice/Restores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restore restore = db.Restores.Find(id);
            if (restore == null)
            {
                return HttpNotFound();
            }
            return View(restore);
        }

        // POST: BackOffice/Restores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restore restore = db.Restores.Find(id);
            db.Restores.Remove(restore);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
