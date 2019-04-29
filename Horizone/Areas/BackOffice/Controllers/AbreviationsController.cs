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
    public class AbreviationsController : BaseController
    {

        // GET: BackOffice/Abreviations
        public ActionResult Index()
        {
            return View(db.Abreviations.ToList());
        }

        // GET: BackOffice/Abreviations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abreviation = db.Abreviations.Find(id);
            if (abreviation == null)
            {
                return HttpNotFound();
            }
            return View(abreviation);
        }

        // GET: BackOffice/Abreviations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Abreviations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symbol,DescriptionEn,DescriptionFr,DescriptionZh")] Abreviation abreviation)
        {
            if (ModelState.IsValid)
            {
                db.Abreviations.Add(abreviation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abreviation);
        }

        // GET: BackOffice/Abreviations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abreviation = db.Abreviations.Find(id);
            if (abreviation == null)
            {
                return HttpNotFound();
            }
            return View(abreviation);
        }

        // POST: BackOffice/Abreviations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symbol,DescriptionEn,DescriptionFr,DescriptionZh")] Abreviation abreviation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abreviation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abreviation);
        }

        // GET: BackOffice/Abreviations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abreviation = db.Abreviations.Find(id);
            if (abreviation == null)
            {
                return HttpNotFound();
            }
            return View(abreviation);
        }

        // POST: BackOffice/Abreviations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abreviation abreviation = db.Abreviations.Find(id);
            db.Abreviations.Remove(abreviation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
