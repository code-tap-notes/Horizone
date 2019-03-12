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
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            var manuscripts = db.Manuscripts.Include(m => m.TochLanguage).Include(m => m.Language).Include(m=>m.Bibliographys);            
            return View(manuscripts.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
      

        // GET: BackOffice/Manuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        // GET: BackOffice/Manuscripts/Details/layout/5
        public ActionResult LayoutManuscripts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        // GET: BackOffice/Manuscripts/Details/Description/5
        public ActionResult OverallDescriptions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        // GET: BackOffice/Manuscripts/Details/Script/5
        public ActionResult ScriptManuscripts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        // GET: BackOffice/Manuscripts/Details/Text/5
        public ActionResult TextContents(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).Include(y=>y.Bibliographys).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        // GET: BackOffice/Manuscripts/Details/Language/5
        public ActionResult TextLanguages(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).Include(y=>y.TochLanguage).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        // GET: BackOffice/Manuscripts/Details/Materiel/5
        public ActionResult MaterialManuscripts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).SingleOrDefault(x => x.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
          
        // GET: BackOffice/Manuscripts/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol");
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");
            ViewBag.Bibliographys = new SelectList(db.Bibliographys, "Id", "Title");           
            return View();
        }

        // POST: BackOffice/Manuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Index,Collection,Siglum,Joint,OtherSiglum,ExpeditionCode,MainFindSpot,SpecificFindSpot,GeneralState,Description,Remark,LeafNumber,SizeHeight,Completeness,SizeWidth,NumberOfLine,LineDistance,Format,Ruling,RulingColor,RulingDetail,StringholeHeight,StringholeWidth,DistanceStringholeRight,DistanceStringholeLeft,InterruptedLine,Transliteration,Transcription,English,Francaise,Chinese,Editor,References,PhilologicalCommentary,Material,PaperColor,PaperThickness,WritingTool,AlignmentType,ModuleWidth,ModuleHeight,AvCharPerLigne,NibThickness,Script,ScriptAdd,TochLanguageId,LanguageStage,LanguageDetails,TextGenre,TextSubGenre,Title,Passage,Parallel,MetricForm,Tune,Cetom,Visible,LanguageId")] Manuscript manuscript, int[] BibliographyId)
        {
            if (BibliographyId.Count() > 0)
                manuscript.Bibliographys = db.Bibliographys.Where(x => BibliographyId.Contains(x.Id)).ToList();
            
            if (ModelState.IsValid)
            {
                db.Manuscripts.Add(manuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", manuscript.LanguageId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", manuscript.TochLanguageId);
            ViewBag.BibliographyId = new SelectList(db.Bibliographys, "Id", "Title");
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
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", manuscript.LanguageId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", manuscript.TochLanguageId);
            ViewBag.Bibliographys = new SelectList(db.Bibliographys, "Id", "Title");
            return View(manuscript);
        }

        // POST: BackOffice/Manuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Index,Collection,Siglum,Joint,OtherSiglum,ExpeditionCode,MainFindSpot,SpecificFindSpot,GeneralState,Description,Remark,LeafNumber,SizeHeight,Completeness,SizeWidth,NumberOfLine,LineDistance,Format,Ruling,RulingColor,RulingDetail,StringholeHeight,StringholeWidth,DistanceStringholeRight,DistanceStringholeLeft,InterruptedLine,Transliteration,Transcription,English,Francaise,Chinese,Editor,References,PhilologicalCommentary,Material,PaperColor,PaperThickness,WritingTool,AlignmentType,ModuleWidth,ModuleHeight,AvCharPerLigne,NibThickness,Script,ScriptAdd,TochLanguageId,LanguageStage,LanguageDetails,TextGenre,TextSubGenre,Title,Passage,Parallel,MetricForm,Tune,Cetom,Visible,LanguageId")] Manuscript manuscript, int[] BibliographyId)
        {
            db.Entry(manuscript).State = EntityState.Modified;
            db.Manuscripts.Include("ImageManuscripts").Include("Language").Include("Tochlanguage").Include("Bibliographys").SingleOrDefault(x => x.Id == manuscript.Id);
            if (ModelState.IsValid)
            {

                if (BibliographyId != null)
                    manuscript.Bibliographys = db.Bibliographys.Where(x => BibliographyId.Contains(x.Id)).ToList();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Symbol", manuscript.LanguageId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", manuscript.TochLanguageId);
            ViewBag.Bibliographys = new SelectList(db.Bibliographys, "Id", "Title");
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
