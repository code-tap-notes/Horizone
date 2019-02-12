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
    [Authorize(Roles = "Collaborator,Admin")]
    public class ImageCollaborationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BackOffice/ImageCollaborations
        public ActionResult Index()
        {
            var imageCollaborations = db.ImageCollaborations.Include(i => i.Colaboration);
            return View(imageCollaborations.ToList());
        }

        // GET: BackOffice/ImageCollaborations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageCollaboration imageCollaboration = db.ImageCollaborations.Find(id);
            if (imageCollaboration == null)
            {
                return HttpNotFound();
            }
            return View(imageCollaboration);
        }

        // GET: BackOffice/ImageCollaborations/Create
        public ActionResult Create()
        {
            ViewBag.CollaborationId = new SelectList(db.Collaborations, "Id", "Title");
            return View();
        }

        // POST: BackOffice/ImageCollaborations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ContentType,Content,CollaborationId")] ImageCollaboration imageCollaboration)
        {
            if (ModelState.IsValid)
            {
                db.ImageCollaborations.Add(imageCollaboration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollaborationId = new SelectList(db.Collaborations, "Id", "Title", imageCollaboration.CollaborationId);
            return View(imageCollaboration);
        }

        // GET: BackOffice/ImageCollaborations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageCollaboration imageCollaboration = db.ImageCollaborations.Find(id);
            if (imageCollaboration == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollaborationId = new SelectList(db.Collaborations, "Id", "Title", imageCollaboration.CollaborationId);
            return View(imageCollaboration);
        }

        // POST: BackOffice/ImageCollaborations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContentType,Content,CollaborationId")] ImageCollaboration imageCollaboration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageCollaboration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollaborationId = new SelectList(db.Collaborations, "Id", "Title", imageCollaboration.CollaborationId);
            return View(imageCollaboration);
        }

        // GET: BackOffice/ImageCollaborations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageCollaboration imageCollaboration = db.ImageCollaborations.Find(id);
            if (imageCollaboration == null)
            {
                return HttpNotFound();
            }
            return View(imageCollaboration);
        }

        // POST: BackOffice/ImageCollaborations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageCollaboration imageCollaboration = db.ImageCollaborations.Find(id);
            db.ImageCollaborations.Remove(imageCollaboration);
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
