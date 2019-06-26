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
    [Authorize(Roles = "Collaborator,Admin")]
    public class MoodsController : BaseController
    {

        // GET: BackOffice/Moods
        public ActionResult Index()
        {
            return View(db.Moods.ToList());
        }


        // GET: BackOffice/Moods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Moods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AbbreviationsMood,MoodEn,MoodFr,MoodZh")] Mood mood)
        {
            if (ModelState.IsValid)
            {
                db.Moods.Add(mood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mood);
        }

        // GET: BackOffice/Moods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mood mood = db.Moods.Find(id);
            if (mood == null)
            {
                return HttpNotFound();
            }
            return View(mood);
        }

        // POST: BackOffice/Moods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AbbreviationsMood,MoodEn,MoodFr,MoodZh")] Mood mood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mood);
        }

        // GET: BackOffice/Moods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mood mood = db.Moods.Find(id);
            if (mood == null)
            {
                return HttpNotFound();
            }
            return View(mood);
        }

        // POST: BackOffice/Moods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mood mood = db.Moods.Find(id);
            db.Moods.Remove(mood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}
