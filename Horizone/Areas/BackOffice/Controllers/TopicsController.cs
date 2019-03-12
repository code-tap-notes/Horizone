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
    public class TopicsController : BaseController
    {
       

        // GET: BackOffice/Topics
        public ActionResult Index()
        {
            var topics = db.Topics.Include(t => t.Language);
            return View(topics.ToList());
        }

        // GET: BackOffice/Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Include(t => t.Language).SingleOrDefault(x=>x.Id==id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: BackOffice/Topics/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            return View();
        }

        // POST: BackOffice/Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TopicName,LanguageId")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", topic.LanguageId);
            return View(topic);
        }

        // GET: BackOffice/Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", topic.LanguageId);
            return View(topic);
        }

        // POST: BackOffice/Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TopicName,LanguageId")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", topic.LanguageId);
            return View(topic);
        }

        // GET: BackOffice/Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: BackOffice/Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
