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
    public class ManuscriptsController : BaseController
    {
        // GET: BackOffice/Manuscripts
        public ActionResult Index(int page = 1, int pageSize = 12)
        {
            var manuscripts = db.Manuscripts.Include(m => m.LayoutManuscript).Include(m => m.MaterialManuscript).Include(m => m.OverallDescription).Include(m => m.ScriptManuscript).Include(m => m.TextContent).Include(m => m.TextLanguage);
            return View(manuscripts.OrderBy(x => x.Id).ToPagedList(page, pageSize));       
        }
        // GET: BackOffice/Manuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Manuscript manuscript = db.Manuscripts.Include(y=>y.ImageManuscripts).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
            
        }

        // GET: BackOffice/Manuscripts/Create
        public ActionResult Create()
        {
            ViewBag.LayoutManuscriptId = new SelectList(db.LayoutManuscripts, "Id", "SizeHeight");
            ViewBag.MaterialManuscriptId = new SelectList(db.MaterialManuscripts, "Id", "Material");
            ViewBag.OverallDescriptionId = new SelectList(db.OverallDescriptions, "Id", "Collection");
            ViewBag.ScriptManuscriptId = new SelectList(db.ScriptManuscripts, "Id", "AlignmentType");
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TextGenre");
            ViewBag.TextLanguageId = new SelectList(db.TextLanguages, "Id", "Language");
            return View();
        }

        // POST: BackOffice/Manuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Index,Transliteration,Transcription,English,Francaise,Chinese,Editor,References,PhilologicalCommentary,ScriptManuscriptId,TextContentId,MaterialManuscriptId,OverallDescriptionId,LayoutManuscriptId,TextLanguageId,Visible")] Manuscript manuscript)
        {
            if (ModelState.IsValid)
            {
                db.Manuscripts.Add(manuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LayoutManuscriptId = new SelectList(db.LayoutManuscripts, "Id", "SizeHeight", manuscript.LayoutManuscriptId);
            ViewBag.MaterialManuscriptId = new SelectList(db.MaterialManuscripts, "Id", "Material", manuscript.MaterialManuscriptId);
            ViewBag.OverallDescriptionId = new SelectList(db.OverallDescriptions, "Id", "Collection", manuscript.OverallDescriptionId);
            ViewBag.ScriptManuscriptId = new SelectList(db.ScriptManuscripts, "Id", "AlignmentType", manuscript.ScriptManuscriptId);
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TextGenre", manuscript.TextContentId);
            ViewBag.TextLanguageId = new SelectList(db.TextLanguages, "Id", "Language", manuscript.TextLanguageId);
            return View(manuscript);
        }

        // GET: BackOffice/Manuscripts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
                Manuscript manuscript = db.Manuscripts.Include("ImageManuscripts").SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            ViewBag.LayoutManuscriptId = new SelectList(db.LayoutManuscripts, "Id", "SizeHeight", manuscript.LayoutManuscriptId);
            ViewBag.MaterialManuscriptId = new SelectList(db.MaterialManuscripts, "Id", "Material", manuscript.MaterialManuscriptId);
            ViewBag.OverallDescriptionId = new SelectList(db.OverallDescriptions, "Id", "Collection", manuscript.OverallDescriptionId);
            ViewBag.ScriptManuscriptId = new SelectList(db.ScriptManuscripts, "Id", "AlignmentType", manuscript.ScriptManuscriptId);
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TextGenre", manuscript.TextContentId);
            ViewBag.TextLanguageId = new SelectList(db.TextLanguages, "Id", "Language", manuscript.TextLanguageId);
            return View(manuscript);
        }

        // POST: BackOffice/Manuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Index,Transliteration,Transcription,English,Francaise,Chinese,Editor,References,PhilologicalCommentary,ScriptManuscriptId,TextContentId,MaterialManuscriptId,OverallDescriptionId,LayoutManuscriptId,TextLanguageId,Visible")] Manuscript manuscript)
        {
            db.Manuscripts.Include("ImageManuscripts").SingleOrDefault(x => x.Id == manuscript.Id);
            
                if (ModelState.IsValid)
            {
                db.Entry(manuscript).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LayoutManuscriptId = new SelectList(db.LayoutManuscripts, "Id", "SizeHeight", manuscript.LayoutManuscriptId);
            ViewBag.MaterialManuscriptId = new SelectList(db.MaterialManuscripts, "Id", "Material", manuscript.MaterialManuscriptId);
            ViewBag.OverallDescriptionId = new SelectList(db.OverallDescriptions, "Id", "Collection", manuscript.OverallDescriptionId);
            ViewBag.ScriptManuscriptId = new SelectList(db.ScriptManuscripts, "Id", "AlignmentType", manuscript.ScriptManuscriptId);
            ViewBag.TextContentId = new SelectList(db.TextContents, "Id", "TextGenre", manuscript.TextContentId);
            ViewBag.TextLanguageId = new SelectList(db.TextLanguages, "Id", "Language", manuscript.TextLanguageId);
            return View(manuscript);
        }

        // GET: BackOffice/Manuscripts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Find(id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }

        // POST: BackOffice/Manuscripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manuscript manuscript = db.Manuscripts.Find(id);
            db.Manuscripts.Remove(manuscript);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageManuscript();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.ManuscriptId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageManuscripts.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "Manuscripts", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "Manuscripts", new { id = id });
        }
                      
        // GET
        public ActionResult DeletePicture(int id, int idmanuscript)
        {
            ImageManuscript image = db.ImageManuscripts.Find(id);
            db.ImageManuscripts.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "Manuscripts", new { id = idmanuscript });
        }
    }
}
