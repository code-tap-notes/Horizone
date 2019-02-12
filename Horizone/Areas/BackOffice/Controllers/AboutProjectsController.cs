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
    public class AboutProjectsController : BaseController
    {
       
        // GET: BackOffice/AboutProjects
        public ActionResult Index()
        {
            var aboutProjets = db.AboutProjets.Include(a => a.Language);
            return View(aboutProjets.ToList());
        }

        // GET: BackOffice/AboutProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutProject aboutProject = db.AboutProjets.Find(id);
            if (aboutProject == null)
            {
                return HttpNotFound();
            }
            return View(aboutProject);
        }

        // GET: BackOffice/AboutProjects/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            return View();
        }

        // POST: BackOffice/AboutProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Aim,Funding,Programing,Feedback,Contact,LanguageId")] AboutProject aboutProject)
        {
            if (ModelState.IsValid)
            {
                db.AboutProjets.Add(aboutProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", aboutProject.LanguageId);
            return View(aboutProject);
        }

        // GET: BackOffice/AboutProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutProject aboutProject = db.AboutProjets.Find(id);
            if (aboutProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", aboutProject.LanguageId);
            return View(aboutProject);
        }

        // POST: BackOffice/AboutProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aim,Funding,Programing,Feedback,Contact,LanguageId")] AboutProject aboutProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", aboutProject.LanguageId);
            return View(aboutProject);
        }

        // GET: BackOffice/AboutProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutProject aboutProject = db.AboutProjets.Find(id);
            if (aboutProject == null)
            {
                return HttpNotFound();
            }
            return View(aboutProject);
        }

        // POST: BackOffice/AboutProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutProject aboutProject = db.AboutProjets.Find(id);
            db.AboutProjets.Remove(aboutProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
