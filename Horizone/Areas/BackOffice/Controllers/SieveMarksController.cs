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
    public class SieveMarksController : BaseController
    {

        // GET: BackOffice/SieveMarks
        public ActionResult Index()
        {
            return View(db.SieveMarks.ToList());
        }

        // GET: BackOffice/SieveMarks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SieveMark sieveMark = db.SieveMarks.Find(id);
            if (sieveMark == null)
            {
                return HttpNotFound();
            }
            return View(sieveMark);
        }

        // GET: BackOffice/SieveMarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/SieveMarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SieveMarkEn,SieveMarkFr,SieveMarkZh")] SieveMark sieveMark)
        {
            if (ModelState.IsValid)
            {
                db.SieveMarks.Add(sieveMark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sieveMark);
        }

        // GET: BackOffice/SieveMarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SieveMark sieveMark = db.SieveMarks.Find(id);
            if (sieveMark == null)
            {
                return HttpNotFound();
            }
            return View(sieveMark);
        }

        // POST: BackOffice/SieveMarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SieveMarkEn,SieveMarkFr,SieveMarkZh")] SieveMark sieveMark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sieveMark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sieveMark);
        }

        // GET: BackOffice/SieveMarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SieveMark sieveMark = db.SieveMarks.Find(id);
            if (sieveMark == null)
            {
                return HttpNotFound();
            }
            return View(sieveMark);
        }

        // POST: BackOffice/SieveMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SieveMark sieveMark = db.SieveMarks.Find(id);
            db.SieveMarks.Remove(sieveMark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
