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
    public class AlignmentTypesController : BaseController
    {
        

        // GET: BackOffice/AlignmentTypes
        public ActionResult Index()
        {
            return View(db.AlignmentTypes.ToList());
        }

        // GET: BackOffice/AlignmentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlignmentType alignmentType = db.AlignmentTypes.Find(id);
            if (alignmentType == null)
            {
                return HttpNotFound();
            }
            return View(alignmentType);
        }

        // GET: BackOffice/AlignmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/AlignmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlignmentTypeEn,AlignmentTypeFr,AlignmentTypeZh")] AlignmentType alignmentType)
        {
            if (ModelState.IsValid)
            {
                db.AlignmentTypes.Add(alignmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alignmentType);
        }

        // GET: BackOffice/AlignmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlignmentType alignmentType = db.AlignmentTypes.Find(id);
            if (alignmentType == null)
            {
                return HttpNotFound();
            }
            return View(alignmentType);
        }

        // POST: BackOffice/AlignmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlignmentTypeEn,AlignmentTypeFr,AlignmentTypeZh")] AlignmentType alignmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alignmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alignmentType);
        }

        // GET: BackOffice/AlignmentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlignmentType alignmentType = db.AlignmentTypes.Find(id);
            if (alignmentType == null)
            {
                return HttpNotFound();
            }
            return View(alignmentType);
        }

        // POST: BackOffice/AlignmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlignmentType alignmentType = db.AlignmentTypes.Find(id);
            db.AlignmentTypes.Remove(alignmentType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
