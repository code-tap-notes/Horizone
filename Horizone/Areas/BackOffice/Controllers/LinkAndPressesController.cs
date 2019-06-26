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
    public class LinkAndPressesController : BaseController
    {        

        // GET: BackOffice/LinkAndPresses
        public ActionResult Index()
        {
            var linkAndPresses = db.LinkAndPresses.Include(l => l.Language);
            return View(linkAndPresses.ToList());
        }
        //pour ficher dans menu Link page d'acceil
        [ChildActionOnly]
        public ActionResult Link()
        {

            var linkAndPresses = db.LinkAndPresses;

            foreach (var item in db.LinkAndPresses)
            {
                if (item.Order != 4)
                    linkAndPresses.Add(item);
            }
            return PartialView(linkAndPresses.ToList());
        }
       
        //pour travail dans bureau
        public ActionResult Press()
        {
            var linkAndPresses = db.LinkAndPresses;

            foreach (var item in db.LinkAndPresses)
            {
                if (item.Order == 4)
                    linkAndPresses.Add(item);
            }
            return View(linkAndPresses.ToList());
        }

        // GET: BackOffice/LinkAndPresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinkAndPress linkAndPress = db.LinkAndPresses.Find(id);
            if (linkAndPress == null)
            {
                return HttpNotFound();
            }
            return View(linkAndPress);
        }

        // GET: BackOffice/LinkAndPresses/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            return View();
        }

        // POST: BackOffice/LinkAndPresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Link,Order,Status,Target,Press,LanguageId")] LinkAndPress linkAndPress)
        {
            if (ModelState.IsValid)
            {
                db.LinkAndPresses.Add(linkAndPress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", linkAndPress.LanguageId);
            return View(linkAndPress);
        }

        // GET: BackOffice/LinkAndPresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinkAndPress linkAndPress = db.LinkAndPresses.Find(id);
            if (linkAndPress == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", linkAndPress.LanguageId);
            return View(linkAndPress);
        }

        // POST: BackOffice/LinkAndPresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Link,Order,Status,Target,Press,LanguageId")] LinkAndPress linkAndPress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linkAndPress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", linkAndPress.LanguageId);
            return View(linkAndPress);
        }

        // GET: BackOffice/LinkAndPresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinkAndPress linkAndPress = db.LinkAndPresses.Find(id);
            if (linkAndPress == null)
            {
                return HttpNotFound();
            }
            return View(linkAndPress);
        }

        // POST: BackOffice/LinkAndPresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinkAndPress linkAndPress = db.LinkAndPresses.Find(id);
            db.LinkAndPresses.Remove(linkAndPress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
