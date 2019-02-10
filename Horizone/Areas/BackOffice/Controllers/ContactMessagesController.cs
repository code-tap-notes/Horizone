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
    public class ContactMessagesController : BaseController
    {
        

        // GET: BackOffice/ContactMessages
        public ActionResult Index()
        {
            return View(db.ContactMessages.ToList());
        }

        // GET: BackOffice/ContactMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = db.ContactMessages.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // GET: BackOffice/ContactMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ContactMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,LastName,FirstName,Email,PhoneNumber,SendDate,Message,SymbolLanguage")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessages.Add(contactMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactMessage);
        }

        // GET: BackOffice/ContactMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = db.ContactMessages.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // POST: BackOffice/ContactMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,LastName,FirstName,Email,PhoneNumber,SendDate,Message,SymbolLanguage")] ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactMessage);
        }

        // GET: BackOffice/ContactMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessage contactMessage = db.ContactMessages.Find(id);
            if (contactMessage == null)
            {
                return HttpNotFound();
            }
            return View(contactMessage);
        }

        // POST: BackOffice/ContactMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactMessage contactMessage = db.ContactMessages.Find(id);
            db.ContactMessages.Remove(contactMessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
