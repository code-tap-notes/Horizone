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
    public class CasesController : BaseController
    {
      
        // GET: BackOffice/Cases
        public ActionResult Index()
        {
            return View(db.Cases.ToList());
        }

        // GET: BackOffice/Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = db.Cases.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            return View(cases);
        }

        // GET: BackOffice/Cases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameCase,NameCaseEn,NameCaseFr,NameCaseZh")] Case cases)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(cases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cases);
        }

        // GET: BackOffice/Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = db.Cases.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            return View(cases);
        }

        // POST: BackOffice/Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameCase,NameCaseEn,NameCaseFr,NameCaseZh")] Case cases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cases);
        }

        // GET: BackOffice/Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case cases = db.Cases.Find(id);
            if (cases == null)
            {
                return HttpNotFound();
            }
            return View(cases);
        }

        // POST: BackOffice/Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Case cases = db.Cases.Find(id);
            db.Cases.Remove(cases);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
