using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;
using Horizone.Controllers;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class NumbersController : BaseController
    {
       
        // GET: BackOffice/Numbers
        public ActionResult Index()
        {
            return View(db.Numbers.ToList());
        }

        // GET: BackOffice/Numbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

        // GET: BackOffice/Numbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Numbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WordNumber,WordNumberEn,WordNumberFr,WordNumberZh")] Number number)
        {
            if (ModelState.IsValid)
            {
                db.Numbers.Add(number);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(number);
        }

        // GET: BackOffice/Numbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

        // POST: BackOffice/Numbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WordNumber,WordNumberEn,WordNumberFr,WordNumberZh")] Number number)
        {
            if (ModelState.IsValid)
            {
                db.Entry(number).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(number);
        }

        // GET: BackOffice/Numbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Numbers.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

        // POST: BackOffice/Numbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Number number = db.Numbers.Find(id);
            db.Numbers.Remove(number);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
