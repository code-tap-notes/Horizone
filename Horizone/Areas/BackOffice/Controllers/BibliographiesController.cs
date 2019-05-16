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
using PagedList;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class BibliographiesController : BaseController
    {        
        // GET: BackOffice/Bibliographies
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            return View(db.Bibliographys.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
        

        // GET: BackOffice/Bibliographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Bibliographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Author,PublicationDate,Title,Journal,UlrBibliography")] Bibliography bibliography)
        {
            if (ModelState.IsValid)
            {
                db.Bibliographys.Add(bibliography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bibliography);
        }

        // GET: BackOffice/Bibliographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliography bibliography = db.Bibliographys.Find(id);
            if (bibliography == null)
            {
                return HttpNotFound();
            }
            return View(bibliography);
        }

        // POST: BackOffice/Bibliographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Author,PublicationDate,Title,Journal,UlrBibliography")] Bibliography bibliography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bibliography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bibliography);
        }

        // GET: BackOffice/Bibliographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bibliography bibliography = db.Bibliographys.Find(id);
            if (bibliography == null)
            {
                return HttpNotFound();
            }
            return View(bibliography);
        }

        // POST: BackOffice/Bibliographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bibliography bibliography = db.Bibliographys.Find(id);
            db.Bibliographys.Remove(bibliography);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Search(string search, string title, string journal)
        {
            IEnumerable<Bibliography> bibliographies = db.Bibliographys;

            if (!string.IsNullOrWhiteSpace(search))
            {
                bibliographies = bibliographies.Where(x => x.Author.Contains(search));
                //bibliographies = bibliographies.Where(x => x.PublicationDate.Contains(search));
                //bibliographies = bibliographies.Where(x => x.Title.Contains(search));
                //|| || (x=> x.PublicationDate.Contains(search)
                //|| x.Journal.Contains(search)
                //|| x.Title.Contains(search));
            }
            //if (!string.IsNullOrWhiteSpace(title))
            //    bibliographies = bibliographies.Where(y => y.Title.Contains(title));
            //if (!string.IsNullOrWhiteSpace(journal))
            //    bibliographies = bibliographies.Where(y => y.Journal.Contains(journal));
            if (bibliographies.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", bibliographies.ToList());
        }

    }
}
