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
    public class PaperColorsController : BaseController
    {
       

        // GET: BackOffice/PaperColors
        public ActionResult Index()
        {
            return View(db.PaperColors.ToList());
        }

         

        // GET: BackOffice/PaperColors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/PaperColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PaperColorEn,PaperColorFr,PaperColorZh")] PaperColor paperColor)
        {
            if (ModelState.IsValid)
            {
                db.PaperColors.Add(paperColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paperColor);
        }

        // GET: BackOffice/PaperColors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperColor paperColor = db.PaperColors.Find(id);
            if (paperColor == null)
            {
                return HttpNotFound();
            }
            return View(paperColor);
        }

        // POST: BackOffice/PaperColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PaperColorEn,PaperColorFr,PaperColorZh")] PaperColor paperColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paperColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paperColor);
        }

        // GET: BackOffice/PaperColors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaperColor paperColor = db.PaperColors.Find(id);
            if (paperColor == null)
            {
                return HttpNotFound();
            }
            return View(paperColor);
        }

        // POST: BackOffice/PaperColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaperColor paperColor = db.PaperColors.Find(id);
            db.PaperColors.Remove(paperColor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
