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
    public class ActivitiesController : BaseController
    {

        // GET: BackOffice/Activities
        public ActionResult Index()
        {
            var activitys = db.Activitys.Include(a => a.Language).Include(a => a.Topic);
            return View(activitys.ToList());
        }

        // GET: BackOffice/Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activitys.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: BackOffice/Activities/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn");
            return View();
        }

        // POST: BackOffice/Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateofActivity,Place,NameActivity,Description,UlrActivity,Picture,TopicId,LanguageId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activitys.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", activity.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn", activity.TopicId);
            return View(activity);
        }

        // GET: BackOffice/Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activitys.Include("ImageActivitys").SingleOrDefault(x => x.Id==id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", activity.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn", activity.TopicId);
            return View(activity);
        }

        // POST: BackOffice/Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateofActivity,Place,NameActivity,Description,UlrActivity,Picture,TopicId,LanguageId")] Activity activity)
        {
            db.Entry(activity).State = EntityState.Modified;
            db.Activitys.Include("ImageActivitys").SingleOrDefault(x => x.Id == activity.Id);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", activity.LanguageId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "TopicEn", activity.TopicId);
            return View(activity);
        }

        // GET: BackOffice/Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activitys.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: BackOffice/Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activitys.Find(id);
            db.Activitys.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageActivity();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.ActivityId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageActivitys.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "Activities", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "Activities", new { id = id });
        }
        public ActionResult DeletePicture(int id, int idActivity)
        {
            ImageActivity image = db.ImageActivitys.Find(id);
            db.ImageActivitys.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "Activities", new { id = idActivity });
        }
    }
}
