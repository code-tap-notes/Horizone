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
    public class FiberDistributionsController : BaseController
    {

        // GET: BackOffice/FiberDistributions
        public ActionResult Index()
        {
            return View(db.FiberDistributions.ToList());
        }

        // GET: BackOffice/FiberDistributions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiberDistribution fiberDistribution = db.FiberDistributions.Find(id);
            if (fiberDistribution == null)
            {
                return HttpNotFound();
            }
            return View(fiberDistribution);
        }

        // GET: BackOffice/FiberDistributions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/FiberDistributions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DistributionEn,DistributionFr,DistributionZh")] FiberDistribution fiberDistribution)
        {
            if (ModelState.IsValid)
            {
                db.FiberDistributions.Add(fiberDistribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiberDistribution);
        }

        // GET: BackOffice/FiberDistributions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiberDistribution fiberDistribution = db.FiberDistributions.Find(id);
            if (fiberDistribution == null)
            {
                return HttpNotFound();
            }
            return View(fiberDistribution);
        }

        // POST: BackOffice/FiberDistributions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DistributionEn,DistributionFr,DistributionZh")] FiberDistribution fiberDistribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiberDistribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiberDistribution);
        }

        // GET: BackOffice/FiberDistributions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiberDistribution fiberDistribution = db.FiberDistributions.Find(id);
            if (fiberDistribution == null)
            {
                return HttpNotFound();
            }
            return View(fiberDistribution);
        }

        // POST: BackOffice/FiberDistributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FiberDistribution fiberDistribution = db.FiberDistributions.Find(id);
            db.FiberDistributions.Remove(fiberDistribution);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
