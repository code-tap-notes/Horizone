using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class TextContentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/TextContents
        public ActionResult Index()
        {
            return View(db.TextContents.ToList());
        }

        // GET: BackOffice/TextContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextContent textContent = db.TextContents.Find(id);
            if (textContent == null)
            {
                return HttpNotFound();
            }
            return View(textContent);
        }

        // GET: BackOffice/TextContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/TextContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TitleOfTheWork,Passage,TextGenre,TextSubgenre,VerseProse")] TextContent textContent)
        {
            if (ModelState.IsValid)
            {
                db.TextContents.Add(textContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(textContent);
        }

        // GET: BackOffice/TextContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextContent textContent = db.TextContents.Find(id);
            if (textContent == null)
            {
                return HttpNotFound();
            }
            return View(textContent);
        }

        // POST: BackOffice/TextContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TitleOfTheWork,Passage,TextGenre,TextSubgenre,VerseProse")] TextContent textContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textContent);
        }

        // GET: BackOffice/TextContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextContent textContent = db.TextContents.Find(id);
            if (textContent == null)
            {
                return HttpNotFound();
            }
            return View(textContent);
        }

        // POST: BackOffice/TextContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextContent textContent = db.TextContents.Find(id);
            db.TextContents.Remove(textContent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
