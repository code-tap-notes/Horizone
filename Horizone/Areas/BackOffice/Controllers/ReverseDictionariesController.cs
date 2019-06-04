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
    public class ReverseDictionariesController : BaseController
    {

        // GET: BackOffice/ReverseDictionaries
        public ActionResult Index()
        {
            return View(db.ReverseDictionaries.ToList());
        }

        // GET: BackOffice/ReverseDictionaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary == null)
            {
                return HttpNotFound();
            }
            return View(reverseDictionary);
        }

        // GET: BackOffice/ReverseDictionaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ReverseDictionaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word,ReverseWord")] ReverseDictionary reverseDictionary)
        {
            if (ModelState.IsValid)
            {
                db.ReverseDictionaries.Add(reverseDictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reverseDictionary);
        }

        // GET: BackOffice/ReverseDictionaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary == null)
            {
                return HttpNotFound();
            }
            return View(reverseDictionary);
        }

        // POST: BackOffice/ReverseDictionaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word,ReverseWord")] ReverseDictionary reverseDictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reverseDictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reverseDictionary);
        }

        // GET: BackOffice/ReverseDictionaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary == null)
            {
                return HttpNotFound();
            }
            return View(reverseDictionary);
        }

        // POST: BackOffice/ReverseDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            db.ReverseDictionaries.Remove(reverseDictionary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}
