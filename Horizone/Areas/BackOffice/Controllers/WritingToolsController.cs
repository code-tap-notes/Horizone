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
    public class WritingToolsController : BaseController
    {

        // GET: BackOffice/WritingTools
        public ActionResult Index()
        {
            return View(db.WritingTools.ToList());
        }

         

        // GET: BackOffice/WritingTools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/WritingTools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WritingToolEn,WritingToolFr,WritingToolZh")] WritingTool writingTool)
        {
            if (ModelState.IsValid)
            {
                db.WritingTools.Add(writingTool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(writingTool);
        }

        // GET: BackOffice/WritingTools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WritingTool writingTool = db.WritingTools.Find(id);
            if (writingTool == null)
            {
                return HttpNotFound();
            }
            return View(writingTool);
        }

        // POST: BackOffice/WritingTools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WritingToolEn,WritingToolFr,WritingToolZh")] WritingTool writingTool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(writingTool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(writingTool);
        }

        // GET: BackOffice/WritingTools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WritingTool writingTool = db.WritingTools.Find(id);
            if (writingTool == null)
            {
                return HttpNotFound();
            }
            return View(writingTool);
        }

        // POST: BackOffice/WritingTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WritingTool writingTool = db.WritingTools.Find(id);
            db.WritingTools.Remove(writingTool);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
