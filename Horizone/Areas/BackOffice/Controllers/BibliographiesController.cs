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
using PagedList;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class BibliographiesController : BaseController
    {        
        // GET: BackOffice/Bibliographies
        public ActionResult Index(int page = 1, int pageSize = 40)
        {
            return View(db.Bibliographys.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }

        public ActionResult Book(int page = 1, int pageSize = 12)
        {
            var bibliographys = db.Bibliographys;
            foreach (var item in db.Bibliographys)
                if (item.Book) bibliographys.Add(item);
            return View(bibliographys.OrderBy(x => x.Title).ToPagedList(page, pageSize));
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
        public ActionResult Create([Bind(Include = "Id,Author,PublicationDate,Title,Journal,UlrBibliography,Book")] Bibliography bibliography)
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
            Bibliography bibliography = db.Bibliographys.Include("ImageBooks").SingleOrDefault(x => x.Id ==id);
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
        public ActionResult Edit([Bind(Include = "Id,Author,PublicationDate,Title,Journal,UlrBibliography,Book")] Bibliography bibliography)
        {
            db.Entry(bibliography).State = EntityState.Modified;
            db.Bibliographys.Include("ImageBooks").SingleOrDefault(x => x.Id == bibliography.Id);

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
            Bibliography bibliography = db.Bibliographys.Include("ImageBooks").SingleOrDefault(x => x.Id == id);
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
            Bibliography bibliography = db.Bibliographys.Include("ImageBooks").SingleOrDefault(x => x.Id == id);
            db.Bibliographys.Remove(bibliography);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
      
        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageBook();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.BibliographyId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageBooks.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "Bibliographies", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "Collaborations", new { id = id });
        }

        // GET
        public ActionResult DeletePicture(int id, int idcollaboration)
        {
            ImageCollaboration image = db.ImageCollaborations.Find(id);
            db.ImageCollaborations.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "Collaborations", new { id = idcollaboration });
        }
    }
}
