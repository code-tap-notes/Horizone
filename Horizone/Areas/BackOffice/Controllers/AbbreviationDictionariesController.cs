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
    public class AbbreviationDictionariesController : BaseController
    {
 
        // GET: BackOffice/AbbreviationDictionaries
        public ActionResult Index()
        {
            return View(db.AbbreviationDictionaries.ToList());
        }

        // GET: BackOffice/AbbreviationDictionaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }

        // GET: BackOffice/AbbreviationDictionaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/AbbreviationDictionaries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symbol,Description")] AbbreviationDictionary abbreviationDictionary)
        {
            if (ModelState.IsValid)
            {
                db.AbbreviationDictionaries.Add(abbreviationDictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abbreviationDictionary);
        }

        // GET: BackOffice/AbbreviationDictionaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }

        // POST: BackOffice/AbbreviationDictionaries/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symbol,Description")] AbbreviationDictionary abbreviationDictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abbreviationDictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abbreviationDictionary);
        }

        // GET: BackOffice/AbbreviationDictionaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }

        // POST: BackOffice/AbbreviationDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            db.AbbreviationDictionaries.Remove(abbreviationDictionary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
    }
}
