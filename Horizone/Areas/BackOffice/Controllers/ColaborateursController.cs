using Horizone.Controllers;
using Horizone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Colaborator,Admin")]
    public class ColaborateursController : BaseController
    {
        // GET: BackOffice/Colaborateurs
        public ActionResult Index()
        {
            List<Colaborateur> colaborateurs = db.Colaborateurs.ToList();
            return View(colaborateurs);
        }


        // GET: BackOffice/Colaborateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborateur colaborateur = db.Colaborateurs.Find(id);
            if (colaborateur == null)
            {
                return HttpNotFound();
            }
            return View(colaborateur);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Colaborateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UseId,Title,LastName,FirstName,PhoneNumber")] Colaborateur colaborateur)
        {
            if (ModelState.IsValid)
            {
                db.Colaborateurs.Add(colaborateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colaborateur);
        }

        // GET: BackOffice/Colaborateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborateur colaborateur = db.Colaborateurs.Find(id);
            if (colaborateur == null)
            {
                return HttpNotFound();
            }
            return View(colaborateur);
        }

        // POST: BackOffice/Colaborateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UseId,Title,LastName,FirstName,PhoneNumber")] Colaborateur colaborateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaborateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaborateur);
        }

        // GET: BackOffice/Colaborateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborateur colaborateur = db.Colaborateurs.Find(id);
            if (colaborateur == null)
            {
                return HttpNotFound();
            }
            return View(colaborateur);
        }

        // POST: BackOffice/Colaborateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaborateur colaborateur = db.Colaborateurs.Find(id);
            db.Colaborateurs.Remove(colaborateur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}