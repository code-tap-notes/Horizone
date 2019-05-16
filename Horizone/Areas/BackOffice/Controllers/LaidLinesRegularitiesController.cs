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
    public class LaidLinesRegularitiesController : BaseController
    {

        // GET: BackOffice/LaidLinesRegularities
        public ActionResult Index()
        {
            return View(db.LaidLinesRegularitys.ToList());
        }

        

        // GET: BackOffice/LaidLinesRegularities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/LaidLinesRegularities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LaidLinesRegularityEn,LaidLinesRegularityFr,LaidLinesRegularityZh")] LaidLinesRegularity laidLinesRegularity)
        {
            if (ModelState.IsValid)
            {
                db.LaidLinesRegularitys.Add(laidLinesRegularity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laidLinesRegularity);
        }

        // GET: BackOffice/LaidLinesRegularities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaidLinesRegularity laidLinesRegularity = db.LaidLinesRegularitys.Find(id);
            if (laidLinesRegularity == null)
            {
                return HttpNotFound();
            }
            return View(laidLinesRegularity);
        }

        // POST: BackOffice/LaidLinesRegularities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LaidLinesRegularityEn,LaidLinesRegularityFr,LaidLinesRegularityZh")] LaidLinesRegularity laidLinesRegularity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laidLinesRegularity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laidLinesRegularity);
        }

        // GET: BackOffice/LaidLinesRegularities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LaidLinesRegularity laidLinesRegularity = db.LaidLinesRegularitys.Find(id);
            if (laidLinesRegularity == null)
            {
                return HttpNotFound();
            }
            return View(laidLinesRegularity);
        }

        // POST: BackOffice/LaidLinesRegularities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LaidLinesRegularity laidLinesRegularity = db.LaidLinesRegularitys.Find(id);
            db.LaidLinesRegularitys.Remove(laidLinesRegularity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
