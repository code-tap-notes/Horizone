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
    public class ManufaturingDefectsController : BaseController
    {
        // GET: BackOffice/ManufaturingDefects
        public ActionResult Index()
        {
            return View(db.ManufaturingDefects.ToList());
        }

         
        // GET: BackOffice/ManufaturingDefects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ManufaturingDefects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ManufaturingDefectEn,ManufaturingDefectFr,ManufaturingDefectZh")] ManufaturingDefect manufaturingDefect)
        {
            if (ModelState.IsValid)
            {
                db.ManufaturingDefects.Add(manufaturingDefect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufaturingDefect);
        }

        // GET: BackOffice/ManufaturingDefects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufaturingDefect manufaturingDefect = db.ManufaturingDefects.Find(id);
            if (manufaturingDefect == null)
            {
                return HttpNotFound();
            }
            return View(manufaturingDefect);
        }

        // POST: BackOffice/ManufaturingDefects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ManufaturingDefectEn,ManufaturingDefectFr,ManufaturingDefectZh")] ManufaturingDefect manufaturingDefect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufaturingDefect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufaturingDefect);
        }

        // GET: BackOffice/ManufaturingDefects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufaturingDefect manufaturingDefect = db.ManufaturingDefects.Find(id);
            if (manufaturingDefect == null)
            {
                return HttpNotFound();
            }
            return View(manufaturingDefect);
        }

        // POST: BackOffice/ManufaturingDefects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManufaturingDefect manufaturingDefect = db.ManufaturingDefects.Find(id);
            db.ManufaturingDefects.Remove(manufaturingDefect);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
