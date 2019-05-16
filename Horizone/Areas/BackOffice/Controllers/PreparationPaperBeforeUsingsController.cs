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
    public class PreparationPaperBeforeUsingsController : BaseController
    {

        // GET: BackOffice/PreparationPaperBeforeUsings
        public ActionResult Index()
        {
            return View(db.PreparationPaperBeforeUsings.ToList());
        }

         

        // GET: BackOffice/PreparationPaperBeforeUsings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/PreparationPaperBeforeUsings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PreparationEn,PreparationFr,PreparationZh")] PreparationPaperBeforeUsing preparationPaperBeforeUsing)
        {
            if (ModelState.IsValid)
            {
                db.PreparationPaperBeforeUsings.Add(preparationPaperBeforeUsing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(preparationPaperBeforeUsing);
        }

        // GET: BackOffice/PreparationPaperBeforeUsings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreparationPaperBeforeUsing preparationPaperBeforeUsing = db.PreparationPaperBeforeUsings.Find(id);
            if (preparationPaperBeforeUsing == null)
            {
                return HttpNotFound();
            }
            return View(preparationPaperBeforeUsing);
        }

        // POST: BackOffice/PreparationPaperBeforeUsings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PreparationEn,PreparationFr,PreparationZh")] PreparationPaperBeforeUsing preparationPaperBeforeUsing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preparationPaperBeforeUsing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(preparationPaperBeforeUsing);
        }

        // GET: BackOffice/PreparationPaperBeforeUsings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreparationPaperBeforeUsing preparationPaperBeforeUsing = db.PreparationPaperBeforeUsings.Find(id);
            if (preparationPaperBeforeUsing == null)
            {
                return HttpNotFound();
            }
            return View(preparationPaperBeforeUsing);
        }

        // POST: BackOffice/PreparationPaperBeforeUsings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreparationPaperBeforeUsing preparationPaperBeforeUsing = db.PreparationPaperBeforeUsings.Find(id);
            db.PreparationPaperBeforeUsings.Remove(preparationPaperBeforeUsing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
