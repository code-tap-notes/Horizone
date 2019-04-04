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
    public class ScriptsController : BaseController
    {

        // GET: BackOffice/Scripts
        public ActionResult Index()
        {
            return View(db.Scripts.ToList());
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
            return View();
        }

        // POST: BackOffice/Scripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScriptEn,ScriptFr,ScriptZh")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Scripts.Add(script);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(script);
        }

        // POST: BackOffice/Scripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ScriptEn,ScriptFr,ScriptZh")] Script script)
        {
            if (ModelState.IsValid)
            {
                db.Entry(script).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
