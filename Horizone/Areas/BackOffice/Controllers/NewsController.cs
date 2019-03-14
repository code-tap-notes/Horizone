using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Controllers;
using Horizone.Models;


namespace Horizone.Areas.BackOffice.Controllers
{
    public class NewsController : BaseController
    {      
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
            News news = db.Newses.Include(n => n.Collaborator).Include(n => n.Language).Include(n => n.Topic).Include(n => n.ImageNewses).SingleOrDefault(x => x.Id == id); 
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: BackOffice/News/Create
        public ActionResult Create()
        {
            ViewBag.CollaboratorId = new SelectList(db.Collaborators,"Id","FirstName");
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
            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "FirstName", news.CollaboratorId);
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
            News news = db.Newses.Include("ImageNewses").SingleOrDefault(x => x.Id == id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "FirstName", news.CollaboratorId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", news.LanguageId);
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
            db.Entry(news).State = EntityState.Modified;
            db.Newses.Include("ImageNewses").Include("Language").Include("Topic").Include("Collaborator").SingleOrDefault(x => x.Id == news.Id);
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollaboratorId = new SelectList(db.Collaborators, "Id", "FirstName", news.CollaboratorId);            
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", news.LanguageId);
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

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageNews();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.NewsId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageNews.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "News", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "News", new { id = id });
        }

        // GET
        public ActionResult DeletePicture(int id, int idnews)
        {
            ImageNews image = db.ImageNews.Find(id);
            db.ImageNews.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "News", new { id = idnews });
        }
       
    }
}
