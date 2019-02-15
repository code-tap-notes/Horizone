using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class LayoutManuscriptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/LayoutManuscripts
        public ActionResult Index()
        {
            return View(db.LayoutManuscripts.ToList());
        }

        // GET: BackOffice/LayoutManuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayoutManuscript layoutManuscript = db.LayoutManuscripts.Find(id);
            if (layoutManuscript == null)
            {
                return HttpNotFound();
            }
            return View(layoutManuscript);
        }

        // GET: BackOffice/LayoutManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/LayoutManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SizeHeight,Completeness,SizeWidth,NumberOfLine,LineDistance,Format,Ruling,RulingColor,RulingDetail,StringholeHeight,StringholeWidth,DistanceStringholeRight,DistanceStringholeLeft,InterruptedLine")] LayoutManuscript layoutManuscript)
        {
            if (ModelState.IsValid)
            {
                db.LayoutManuscripts.Add(layoutManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(layoutManuscript);
        }

        // GET: BackOffice/LayoutManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayoutManuscript layoutManuscript = db.LayoutManuscripts.Find(id);
            if (layoutManuscript == null)
            {
                return HttpNotFound();
            }
            return View(layoutManuscript);
        }

        // POST: BackOffice/LayoutManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SizeHeight,Completeness,SizeWidth,NumberOfLine,LineDistance,Format,Ruling,RulingColor,RulingDetail,StringholeHeight,StringholeWidth,DistanceStringholeRight,DistanceStringholeLeft,InterruptedLine")] LayoutManuscript layoutManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(layoutManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(layoutManuscript);
        }

        // GET: BackOffice/LayoutManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LayoutManuscript layoutManuscript = db.LayoutManuscripts.Find(id);
            if (layoutManuscript == null)
            {
                return HttpNotFound();
            }
            return View(layoutManuscript);
        }

        // POST: BackOffice/LayoutManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LayoutManuscript layoutManuscript = db.LayoutManuscripts.Find(id);
            db.LayoutManuscripts.Remove(layoutManuscript);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
