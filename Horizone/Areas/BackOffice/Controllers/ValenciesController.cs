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
    public class ValenciesController : BaseController
    {

        // GET: BackOffice/Valencies
        public ActionResult Index()
        {
            return View(db.Valencies.ToList());
        }

        // GET: BackOffice/Valencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Valencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AbbreviationValency,ValencyEn,ValencyFr,ValencyZh")] Valency valency)
        {
            if (ModelState.IsValid)
            {
                db.Valencies.Add(valency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valency);
        }

        // GET: BackOffice/Valencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valency valency = db.Valencies.Find(id);
            if (valency == null)
            {
                return HttpNotFound();
            }
            return View(valency);
        }

        // POST: BackOffice/Valencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AbbreviationValency,ValencyEn,ValencyFr,ValencyZh")] Valency valency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valency);
        }

        // GET: BackOffice/Valencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valency valency = db.Valencies.Find(id);
            if (valency == null)
            {
                return HttpNotFound();
            }
            return View(valency);
        }

        // POST: BackOffice/Valencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valency valency = db.Valencies.Find(id);
            db.Valencies.Remove(valency);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
