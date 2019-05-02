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
    public class ChainLinesVisibilitiesController : BaseController
    {

        // GET: BackOffice/ChainLinesVisibilities
        public ActionResult Index()
        {
            return View(db.ChainLinesVisibilitys.ToList());
        }

        // GET: BackOffice/ChainLinesVisibilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChainLinesVisibility chainLinesVisibility = db.ChainLinesVisibilitys.Find(id);
            if (chainLinesVisibility == null)
            {
                return HttpNotFound();
            }
            return View(chainLinesVisibility);
        }

        // GET: BackOffice/ChainLinesVisibilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ChainLinesVisibilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ChainLinesVisibilityEn,ChainLinesVisibilityFr,ChainLinesVisibilityZh")] ChainLinesVisibility chainLinesVisibility)
        {
            if (ModelState.IsValid)
            {
                db.ChainLinesVisibilitys.Add(chainLinesVisibility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chainLinesVisibility);
        }

        // GET: BackOffice/ChainLinesVisibilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChainLinesVisibility chainLinesVisibility = db.ChainLinesVisibilitys.Find(id);
            if (chainLinesVisibility == null)
            {
                return HttpNotFound();
            }
            return View(chainLinesVisibility);
        }

        // POST: BackOffice/ChainLinesVisibilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ChainLinesVisibilityEn,ChainLinesVisibilityFr,ChainLinesVisibilityZh")] ChainLinesVisibility chainLinesVisibility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chainLinesVisibility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chainLinesVisibility);
        }

        // GET: BackOffice/ChainLinesVisibilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChainLinesVisibility chainLinesVisibility = db.ChainLinesVisibilitys.Find(id);
            if (chainLinesVisibility == null)
            {
                return HttpNotFound();
            }
            return View(chainLinesVisibility);
        }

        // POST: BackOffice/ChainLinesVisibilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChainLinesVisibility chainLinesVisibility = db.ChainLinesVisibilitys.Find(id);
            db.ChainLinesVisibilitys.Remove(chainLinesVisibility);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
