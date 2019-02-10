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
    [Authorize(Roles = "Collaborator,Admin")]
    public class InThePressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/InThePresses
        public ActionResult Index()
        {
            return View(db.InthePresses.ToList());
        }

        // GET: BackOffice/InThePresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InThePresse inThePresse = db.InthePresses.Find(id);
            if (inThePresse == null)
            {
                return HttpNotFound();
            }
            return View(inThePresse);
        }

        // GET: BackOffice/InThePresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/InThePresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,LinkThePresse")] InThePresse inThePresse)
        {
            if (ModelState.IsValid)
            {
                db.InthePresses.Add(inThePresse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inThePresse);
        }

        // GET: BackOffice/InThePresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InThePresse inThePresse = db.InthePresses.Find(id);
            if (inThePresse == null)
            {
                return HttpNotFound();
            }
            return View(inThePresse);
        }

        // POST: BackOffice/InThePresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,LinkThePresse")] InThePresse inThePresse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inThePresse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inThePresse);
        }

        // GET: BackOffice/InThePresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InThePresse inThePresse = db.InthePresses.Find(id);
            if (inThePresse == null)
            {
                return HttpNotFound();
            }
            return View(inThePresse);
        }

        // POST: BackOffice/InThePresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InThePresse inThePresse = db.InthePresses.Find(id);
            db.InthePresses.Remove(inThePresse);
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
