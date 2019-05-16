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
    public class RemarkAddsController : BaseController
    {
        

        // GET: BackOffice/RemarkAdds
        public ActionResult Index()
        {
            return View(db.RemarkAdds.ToList());
        }

        

        // GET: BackOffice/RemarkAdds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/RemarkAdds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RemarkEn,RemarkFr,RemarkZh")] RemarkAdd remarkAdd)
        {
            if (ModelState.IsValid)
            {
                db.RemarkAdds.Add(remarkAdd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(remarkAdd);
        }

        // GET: BackOffice/RemarkAdds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemarkAdd remarkAdd = db.RemarkAdds.Find(id);
            if (remarkAdd == null)
            {
                return HttpNotFound();
            }
            return View(remarkAdd);
        }

        // POST: BackOffice/RemarkAdds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RemarkEn,RemarkFr,RemarkZh")] RemarkAdd remarkAdd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(remarkAdd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(remarkAdd);
        }

        // GET: BackOffice/RemarkAdds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RemarkAdd remarkAdd = db.RemarkAdds.Find(id);
            if (remarkAdd == null)
            {
                return HttpNotFound();
            }
            return View(remarkAdd);
        }

        // POST: BackOffice/RemarkAdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RemarkAdd remarkAdd = db.RemarkAdds.Find(id);
            db.RemarkAdds.Remove(remarkAdd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
