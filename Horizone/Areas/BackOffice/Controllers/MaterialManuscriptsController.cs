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
    public class MaterialManuscriptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/MaterialManuscripts
        public ActionResult Index()
        {
            return View(db.MaterialManuscripts.ToList());
        }

        // GET: BackOffice/MaterialManuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialManuscript materialManuscript = db.MaterialManuscripts.Find(id);
            if (materialManuscript == null)
            {
                return HttpNotFound();
            }
            return View(materialManuscript);
        }

        // GET: BackOffice/MaterialManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/MaterialManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,PaperColor,PaperThickness,WritingTool")] MaterialManuscript materialManuscript)
        {
            if (ModelState.IsValid)
            {
                db.MaterialManuscripts.Add(materialManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialManuscript);
        }

        // GET: BackOffice/MaterialManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialManuscript materialManuscript = db.MaterialManuscripts.Find(id);
            if (materialManuscript == null)
            {
                return HttpNotFound();
            }
            return View(materialManuscript);
        }

        // POST: BackOffice/MaterialManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,PaperColor,PaperThickness,WritingTool")] MaterialManuscript materialManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialManuscript);
        }

        // GET: BackOffice/MaterialManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialManuscript materialManuscript = db.MaterialManuscripts.Find(id);
            if (materialManuscript == null)
            {
                return HttpNotFound();
            }
            return View(materialManuscript);
        }

        // POST: BackOffice/MaterialManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialManuscript materialManuscript = db.MaterialManuscripts.Find(id);
            db.MaterialManuscripts.Remove(materialManuscript);
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
