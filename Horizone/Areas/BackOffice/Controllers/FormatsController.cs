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
    public class FormatsController : BaseController
    {

        // GET: BackOffice/Formats
        public ActionResult Index()
        {
            return View(db.Formats.ToList());
        }

        // GET: BackOffice/Formats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Format format = db.Formats.Find(id);
            if (format == null)
            {
                return HttpNotFound();
            }
            return View(format);
        }

        // GET: BackOffice/Formats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Formats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormatEn,FormatFr,FormatZh")] Format format)
        {
            if (ModelState.IsValid)
            {
                db.Formats.Add(format);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(format);
        }

        // GET: BackOffice/Formats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Format format = db.Formats.Find(id);
            if (format == null)
            {
                return HttpNotFound();
            }
            return View(format);
        }

        // POST: BackOffice/Formats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormatEn,FormatFr,FormatZh")] Format format)
        {
            if (ModelState.IsValid)
            {
                db.Entry(format).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(format);
        }

        // GET: BackOffice/Formats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Format format = db.Formats.Find(id);
            if (format == null)
            {
                return HttpNotFound();
            }
            return View(format);
        }

        // POST: BackOffice/Formats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Format format = db.Formats.Find(id);
            db.Formats.Remove(format);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
