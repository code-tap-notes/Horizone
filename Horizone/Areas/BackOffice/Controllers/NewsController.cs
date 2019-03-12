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
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/News
        public ActionResult Index()
        {
            var newses = db.Newses.Include(n => n.Collaborator).Include(n => n.Language).Include(n => n.Topic);
            return View(newses.ToList());
        }

        // GET: BackOffice/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: BackOffice/News/Create
        public ActionResult Create()
        {
            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "UserId");
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicName");
            return View();
        }

        // POST: BackOffice/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Summary,Content,View,TopicId,CollaboratorId,LanguageId")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Newses.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "UserId", news.CollaboratorId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", news.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicName", news.TopicId);
            return View(news);
        }

        // GET: BackOffice/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "UserId", news.CollaboratorId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", news.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicName", news.TopicId);
            return View(news);
        }

        // POST: BackOffice/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Summary,Content,View,TopicId,CollaboratorId,LanguageId")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "UserId", news.CollaboratorId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", news.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicName", news.TopicId);
            return View(news);
        }

        // GET: BackOffice/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: BackOffice/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.Newses.Find(id);
            db.Newses.Remove(news);
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
