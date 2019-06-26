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
    public class ScriptAddsController : BaseController
    {

        // GET: BackOffice/ScriptAdds
        public ActionResult Index()
        {
            return View(db.ScriptAdds.ToList());
        }

        
        // GET: BackOffice/ScriptAdds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ScriptAdds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ScriptAddEn,ScriptAddFr,ScriptAddZh")] ScriptAdd scriptAdd)
        {
            if (ModelState.IsValid)
            {
                db.ScriptAdds.Add(scriptAdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scriptAdd);
        }

        // GET: BackOffice/ScriptAdds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptAdd scriptAdd = db.ScriptAdds.Find(id);
            if (scriptAdd == null)
            {
                return HttpNotFound();
            }
            return View(scriptAdd);
        }

        // POST: BackOffice/ScriptAdds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ScriptAddEn,ScriptAddFr,ScriptAddZh")] ScriptAdd scriptAdd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scriptAdd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scriptAdd);
        }

        // GET: BackOffice/ScriptAdds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScriptAdd scriptAdd = db.ScriptAdds.Find(id);
            if (scriptAdd == null)
            {
                return HttpNotFound();
            }
            return View(scriptAdd);
        }

        // POST: BackOffice/ScriptAdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScriptAdd scriptAdd = db.ScriptAdds.Find(id);
            db.ScriptAdds.Remove(scriptAdd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
