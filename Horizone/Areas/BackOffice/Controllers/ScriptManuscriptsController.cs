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
    public class ScriptManuscriptsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/ScriptManuscripts
        public ActionResult Index()
        {
            return View(db.ScriptManuscripts.ToList());
        }

        // GET: BackOffice/ScriptManuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptManuscript scriptManuscript = db.ScriptManuscripts.Find(id);
            if (scriptManuscript == null)
            {
                return HttpNotFound();
            }
            return View(scriptManuscript);
        }

        // GET: BackOffice/ScriptManuscripts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ScriptManuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlignmentType,ModuleWidth,ModuleHeight,AvCharPerLigne,NibThickness,Script,ScriptAdd")] ScriptManuscript scriptManuscript)
        {
            if (ModelState.IsValid)
            {
                db.ScriptManuscripts.Add(scriptManuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scriptManuscript);
        }

        // GET: BackOffice/ScriptManuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptManuscript scriptManuscript = db.ScriptManuscripts.Find(id);
            if (scriptManuscript == null)
            {
                return HttpNotFound();
            }
            return View(scriptManuscript);
        }

        // POST: BackOffice/ScriptManuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlignmentType,ModuleWidth,ModuleHeight,AvCharPerLigne,NibThickness,Script,ScriptAdd")] ScriptManuscript scriptManuscript)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scriptManuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scriptManuscript);
        }

        // GET: BackOffice/ScriptManuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptManuscript scriptManuscript = db.ScriptManuscripts.Find(id);
            if (scriptManuscript == null)
            {
                return HttpNotFound();
            }
            return View(scriptManuscript);
        }

        // POST: BackOffice/ScriptManuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScriptManuscript scriptManuscript = db.ScriptManuscripts.Find(id);
            db.ScriptManuscripts.Remove(scriptManuscript);
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
