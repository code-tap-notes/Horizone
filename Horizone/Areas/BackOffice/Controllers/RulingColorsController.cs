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
    public class RulingColorsController : BaseController
    {

        // GET: BackOffice/RulingColors
        public ActionResult Index()
        {
            return View(db.RulingColors.ToList());
        }

        // GET: BackOffice/RulingColors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RulingColor rulingColor = db.RulingColors.Find(id);
            if (rulingColor == null)
            {
                return HttpNotFound();
            }
            return View(rulingColor);
        }

        // GET: BackOffice/RulingColors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/RulingColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RulingColorEn,RulingColorFr,RulingColorZh")] RulingColor rulingColor)
        {
            if (ModelState.IsValid)
            {
                db.RulingColors.Add(rulingColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rulingColor);
        }

        // GET: BackOffice/RulingColors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RulingColor rulingColor = db.RulingColors.Find(id);
            if (rulingColor == null)
            {
                return HttpNotFound();
            }
            return View(rulingColor);
        }

        // POST: BackOffice/RulingColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RulingColorEn,RulingColorFr,RulingColorZh")] RulingColor rulingColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rulingColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rulingColor);
        }

        // GET: BackOffice/RulingColors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RulingColor rulingColor = db.RulingColors.Find(id);
            if (rulingColor == null)
            {
                return HttpNotFound();
            }
            return View(rulingColor);
        }

        // POST: BackOffice/RulingColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RulingColor rulingColor = db.RulingColors.Find(id);
            db.RulingColors.Remove(rulingColor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
