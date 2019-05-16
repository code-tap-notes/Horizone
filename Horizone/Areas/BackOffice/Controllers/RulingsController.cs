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
    public class RulingsController : BaseController
    {
       
        // GET: BackOffice/Rulings
        public ActionResult Index()
        {
            return View(db.Rulings.ToList());
        }

        
        // GET: BackOffice/Rulings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Rulings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RulingEn,RulingFr,RulingZh")] Ruling ruling)
        {
            if (ModelState.IsValid)
            {
                db.Rulings.Add(ruling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ruling);
        }

        // GET: BackOffice/Rulings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruling ruling = db.Rulings.Find(id);
            if (ruling == null)
            {
                return HttpNotFound();
            }
            return View(ruling);
        }

        // POST: BackOffice/Rulings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RulingEn,RulingFr,RulingZh")] Ruling ruling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ruling);
        }

        // GET: BackOffice/Rulings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruling ruling = db.Rulings.Find(id);
            if (ruling == null)
            {
                return HttpNotFound();
            }
            return View(ruling);
        }

        // POST: BackOffice/Rulings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ruling ruling = db.Rulings.Find(id);
            db.Rulings.Remove(ruling);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
