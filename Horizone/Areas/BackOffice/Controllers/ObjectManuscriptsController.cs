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
    [Authorize(Roles = "Colaborator,Admin")]
    public class ObjectManuscriptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/ObjectManuscripts
        public ActionResult Index()
        {
            return View(db.ObjectManuscripts.ToList());
        }

        // GET: BackOffice/ObjectManuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectManuscript objectManuscript = db.ObjectManuscripts.Find(id);
            if (objectManuscript == null)
            {
                return HttpNotFound();
            }
            return View(objectManuscript);
        }

        // GET: BackOffice/ObjectManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ObjectManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Manuscript,LeafNumber,Material,Form,NumberOfLine")] ObjectManuscript objectManuscript)
        {
            if (ModelState.IsValid)
            {
                db.ObjectManuscripts.Add(objectManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objectManuscript);
        }

        // GET: BackOffice/ObjectManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectManuscript objectManuscript = db.ObjectManuscripts.Find(id);
            if (objectManuscript == null)
            {
                return HttpNotFound();
            }
            return View(objectManuscript);
        }

        // POST: BackOffice/ObjectManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Manuscript,LeafNumber,Material,Form,NumberOfLine")] ObjectManuscript objectManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objectManuscript);
        }

        // GET: BackOffice/ObjectManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectManuscript objectManuscript = db.ObjectManuscripts.Find(id);
            if (objectManuscript == null)
            {
                return HttpNotFound();
            }
            return View(objectManuscript);
        }

        // POST: BackOffice/ObjectManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectManuscript objectManuscript = db.ObjectManuscripts.Find(id);
            db.ObjectManuscripts.Remove(objectManuscript);
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
