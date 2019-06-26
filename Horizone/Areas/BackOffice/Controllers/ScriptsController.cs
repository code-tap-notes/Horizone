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
    public class ScriptsController : BaseController
    {

        // GET: BackOffice/Scripts
        public ActionResult Index()
        {
            var scripts = db.Scripts.Include(s => s.ScriptType);
            return View(scripts.ToList());
        }
        public ActionResult Brahmi()
        {
            var scripts = db.Scripts.Include(s => s.ScriptType).Where(s => s.ScriptType.Id == 1);
            return View(scripts.ToList());
        }
        public ActionResult Kharosthi()
        {
            var scripts = db.Scripts.Include(s => s.ScriptType).Where(s => s.ScriptType.Id == 2);
            return View(scripts.ToList());
        }
        public ActionResult Ductus()
        {
            var scripts = db.Scripts.Include(s => s.ScriptType).Where(s=>s.ScriptType.Id == 3);
            return View(scripts.ToList());
        }

        // GET: BackOffice/Scripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // GET: BackOffice/Scripts/Create
        public ActionResult Create()
        {
            ViewBag.ScriptTypeId = new SelectList(db.ScriptTypes, "Id", "NameType");
            return View();
        }

        // POST: BackOffice/Scripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScriptEn,ScriptFr,ScriptZh,ScriptTypeId")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Scripts.Add(script);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScriptTypeId = new SelectList(db.ScriptTypes, "Id", "NameType", script.ScriptTypeId);
            return View(script);
        }

        // GET: BackOffice/Scripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScriptTypeId = new SelectList(db.ScriptTypes, "Id", "NameType", script.ScriptTypeId);
            return View(script);
        }

        // POST: BackOffice/Scripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ScriptEn,ScriptFr,ScriptZh,ScriptTypeId")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Entry(script).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScriptTypeId = new SelectList(db.ScriptTypes, "Id", "NameType", script.ScriptTypeId);
            return View(script);
        }

        // GET: BackOffice/Scripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Script script = db.Scripts.Find(id);
            if (script == null)
            {
                return HttpNotFound();
            }
            return View(script);
        }

        // POST: BackOffice/Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Script script = db.Scripts.Find(id);
            db.Scripts.Remove(script);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
