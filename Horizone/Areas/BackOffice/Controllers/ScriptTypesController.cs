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
    public class ScriptTypesController : BaseController
    {

        // GET: BackOffice/ScriptTypes
        public ActionResult Index()
        {
            return View(db.ScriptTypes.ToList());
        }

         

        // GET: BackOffice/ScriptTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ScriptTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameType")] ScriptType scriptType)
        {
            if (ModelState.IsValid)
            {
                db.ScriptTypes.Add(scriptType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scriptType);
        }

        // GET: BackOffice/ScriptTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptType scriptType = db.ScriptTypes.Find(id);
            if (scriptType == null)
            {
                return HttpNotFound();
            }
            return View(scriptType);
        }

        // POST: BackOffice/ScriptTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameType")] ScriptType scriptType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scriptType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scriptType);
        }

        // GET: BackOffice/ScriptTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptType scriptType = db.ScriptTypes.Find(id);
            if (scriptType == null)
            {
                return HttpNotFound();
            }
            return View(scriptType);
        }

        // POST: BackOffice/ScriptTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScriptType scriptType = db.ScriptTypes.Find(id);
            db.ScriptTypes.Remove(scriptType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
