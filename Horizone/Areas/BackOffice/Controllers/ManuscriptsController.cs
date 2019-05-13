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
            var manuscripts = db.Manuscripts.Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool);
            return View(manuscripts.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
       
        
        // GET: BackOffice/Manuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(x=>x.Catalogie).Include(x=>x.Map).Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m=>m.Id==id);
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
            Manuscript manuscript = db.Manuscripts.Include(x => x.Catalogie).Include(x => x.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(x => x.Catalogie).Include(x => x.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(x => x.Catalogie).Include(x => x.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m=>m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(x => x.Catalogie).Include(x => x.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(x => x.Catalogie).Include(x => x.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        public ActionResult TextContents(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(x => x.Catalogie).Include(x => x.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }

            // GET: BackOffice/Manuscripts/Create
            public ActionResult Create()
        {
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture");
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name");
            ViewBag.AlignmentTypeId = new SelectList(db.AlignmentTypes, "Id", "AlignmentTypeEn");
            ViewBag.DescriptionManuscriptId = new SelectList(db.DescriptionManuscripts, "Id", "DescriptionEn");
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn");
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn");
            ViewBag.LanguageDetailId = new SelectList(db.LanguageDetails, "Id", "LanguageDetailEn");
            ViewBag.LanguageStageId = new SelectList(db.LanguageStages, "Id", "LanguageStageEn");
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "MaterialEn");
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "MetricEn");
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn");
            ViewBag.RemarkAddId = new SelectList(db.RemarkAdds, "Id", "RemarkEn");
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn");
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn");
            ViewBag.RulingDetailId = new SelectList(db.RulingDetails, "Id", "RulingDetailEn");
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn");
            ViewBag.ScriptAddId = new SelectList(db.ScriptAdds, "Id", "ScriptAddEn");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn");
            ViewBag.SubGenderManuscriptId = new SelectList(db.SubGenderManuscripts, "Id", "SubGenderEn");
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn");
            ViewBag.Bibliographys = new SelectList(db.Bibliographys, "Id", "Title");
            return View();
        }

        // POST: BackOffice/Manuscripts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatalogieId,Index,Collection,Siglum,Joint,OtherSiglum,ExpeditionCode, MapId,SpecificFindSpot,StateId,DescriptionManuscriptId,RemarkAddId,LeafNumber,SizeHeight,Completeness,SizeWidth,NumberOfLine,LineDistance,FormatId,RulingId,RulingColorId,RulingDetailId,StringholeHeight,StringholeWidth,DistanceStringholeRight,DistanceStringholeLeft,InterruptedLine,Transliteration,Transcription,English,Francaise,Chinese,Editor,References,PhilologicalCommentary,MaterialId,PaperColorId,PaperThickness,WritingToolId,AlignmentTypeId,ModuleWidth,ModuleHeight,AvCharPerLigne,NibThickness,ScriptId,ScriptAddId,TochLanguageId,LanguageStageId,LanguageDetailId,GenderManuscriptId,SubGenderManuscriptId,Title,Passage,Parallel,MetricId,Tune,Cetom,Visible")] Manuscript manuscript, int[] BibliographyId)
        {
            if (BibliographyId.Count() > 0)
                manuscript.Bibliographys = db.Bibliographys.Where(x => BibliographyId.Contains(x.Id)).ToList();

            if (ModelState.IsValid)
            {
                db.Manuscripts.Add(manuscript);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture", manuscript.MapId);
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name", manuscript.CatalogieId);
            ViewBag.AlignmentTypeId = new SelectList(db.AlignmentTypes, "Id", "AlignmentTypeEn", manuscript.AlignmentTypeId);
            ViewBag.DescriptionManuscriptId = new SelectList(db.DescriptionManuscripts, "Id", "DescriptionEn", manuscript.DescriptionManuscriptId);
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn", manuscript.FormatId);
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn", manuscript.GenderManuscriptId);
            ViewBag.LanguageDetailId = new SelectList(db.LanguageDetails, "Id", "LanguageDetailEn", manuscript.LanguageDetailId);
            ViewBag.LanguageStageId = new SelectList(db.LanguageStages, "Id", "LanguageStageEn", manuscript.LanguageStageId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "MaterialEn", manuscript.MaterialId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "MetricEn", manuscript.MetricId);
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn", manuscript.PaperColorId);
            ViewBag.RemarkAddId = new SelectList(db.RemarkAdds, "Id", "RemarkEn", manuscript.RemarkAddId);
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn", manuscript.RulingId);
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn", manuscript.RulingColorId);
            ViewBag.RulingDetailId = new SelectList(db.RulingDetails, "Id", "RulingDetailEn", manuscript.RulingDetailId);
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn", manuscript.ScriptId);
            ViewBag.ScriptAddId = new SelectList(db.ScriptAdds, "Id", "ScriptAddEn", manuscript.ScriptAddId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn", manuscript.StateId);
            ViewBag.SubGenderManuscriptId = new SelectList(db.SubGenderManuscripts, "Id", "SubGenderEn", manuscript.SubGenderManuscriptId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", manuscript.TochLanguageId);
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn", manuscript.WritingToolId);
            ViewBag.Bibliographys = new SelectList(db.Bibliographys, "Id", "Title");
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
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture", manuscript.MapId);
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name");
            ViewBag.AlignmentTypeId = new SelectList(db.AlignmentTypes, "Id", "AlignmentTypeEn", manuscript.AlignmentTypeId);
            ViewBag.DescriptionManuscriptId = new SelectList(db.DescriptionManuscripts, "Id", "DescriptionEn", manuscript.DescriptionManuscriptId);
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn", manuscript.FormatId);
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn", manuscript.GenderManuscriptId);
            ViewBag.LanguageDetailId = new SelectList(db.LanguageDetails, "Id", "LanguageDetailEn", manuscript.LanguageDetailId);
            ViewBag.LanguageStageId = new SelectList(db.LanguageStages, "Id", "LanguageStageEn", manuscript.LanguageStageId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "MaterialEn", manuscript.MaterialId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "MetricEn", manuscript.MetricId);
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn", manuscript.PaperColorId);
            ViewBag.RemarkAddId = new SelectList(db.RemarkAdds, "Id", "RemarkEn", manuscript.RemarkAddId);
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn", manuscript.RulingId);
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn", manuscript.RulingColorId);
            ViewBag.RulingDetailId = new SelectList(db.RulingDetails, "Id", "RulingDetailEn", manuscript.RulingDetailId);
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn", manuscript.ScriptId);
            ViewBag.ScriptAddId = new SelectList(db.ScriptAdds, "Id", "ScriptAddEn", manuscript.ScriptAddId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn", manuscript.StateId);
            ViewBag.SubGenderManuscriptId = new SelectList(db.SubGenderManuscripts, "Id", "SubGenderEn", manuscript.SubGenderManuscriptId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", manuscript.TochLanguageId);
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn", manuscript.WritingToolId);
            ViewBag.Bibliographys = new SelectList(db.Bibliographys, "Id", "Title");
            return View(manuscript);
        }

        // POST: BackOffice/Manuscripts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatalogieId,Index,Collection,Siglum,Joint,OtherSiglum,ExpeditionCode,MapId,SpecificFindSpot,StateId,DescriptionManuscriptId,RemarkAddId,LeafNumber,SizeHeight,Completeness,SizeWidth,NumberOfLine,LineDistance,FormatId,RulingId,RulingColorId,RulingDetailId,StringholeHeight,StringholeWidth,DistanceStringholeRight,DistanceStringholeLeft,InterruptedLine,Transliteration,Transcription,English,Francaise,Chinese,Editor,References,PhilologicalCommentary,MaterialId,PaperColorId,PaperThickness,WritingToolId,AlignmentTypeId,ModuleWidth,ModuleHeight,AvCharPerLigne,NibThickness,ScriptId,ScriptAddId,TochLanguageId,LanguageStageId,LanguageDetailId,GenderManuscriptId,SubGenderManuscriptId,Title,Passage,Parallel,MetricId,Tune,Cetom,Visible")] Manuscript manuscript, int[] BibliographyId)
        {
            db.Entry(manuscript).State = EntityState.Modified;
            db.Manuscripts.Include("Catalogie").Include("Map").Include("ImageManuscripts").Include("State").Include("DescriptionManuscript").Include("RemarkAdd").Include("Format").Include("Ruling").Include("RulingColor").Include("RulingDetail").Include("Material").Include("PaperColor").Include("WritingTool").Include("AlignmentType").Include("Script").Include("ScriptAdd").Include("LanguageStage").Include("Tochlanguage").Include("LanguageDetail").Include("GenderManuscript").Include("SubGenderManuscript").Include("Metric").Include("Bibliographys").SingleOrDefault(x => x.Id == manuscript.Id);
            if (ModelState.IsValid)
            {
                if (BibliographyId != null)
                    manuscript.Bibliographys = db.Bibliographys.Where(x => BibliographyId.Contains(x.Id)).ToList();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture", manuscript.MapId);
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name", manuscript.CatalogieId);
            ViewBag.AlignmentTypeId = new SelectList(db.AlignmentTypes, "Id", "AlignmentTypeEn", manuscript.AlignmentTypeId);
            ViewBag.DescriptionManuscriptId = new SelectList(db.DescriptionManuscripts, "Id", "DescriptionEn", manuscript.DescriptionManuscriptId);
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn", manuscript.FormatId);
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn", manuscript.GenderManuscriptId);
            ViewBag.LanguageDetailId = new SelectList(db.LanguageDetails, "Id", "LanguageDetailEn", manuscript.LanguageDetailId);
            ViewBag.LanguageStageId = new SelectList(db.LanguageStages, "Id", "LanguageStageEn", manuscript.LanguageStageId);
            ViewBag.MaterialId = new SelectList(db.Materials, "Id", "MaterialEn", manuscript.MaterialId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "MetricEn", manuscript.MetricId);
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn", manuscript.PaperColorId);
            ViewBag.RemarkAddId = new SelectList(db.RemarkAdds, "Id", "RemarkEn", manuscript.RemarkAddId);
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn", manuscript.RulingId);
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn", manuscript.RulingColorId);
            ViewBag.RulingDetailId = new SelectList(db.RulingDetails, "Id", "RulingDetailEn", manuscript.RulingDetailId);
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn", manuscript.ScriptId);
            ViewBag.ScriptAddId = new SelectList(db.ScriptAdds, "Id", "ScriptAddEn", manuscript.ScriptAddId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn", manuscript.StateId);
            ViewBag.SubGenderManuscriptId = new SelectList(db.SubGenderManuscripts, "Id", "SubGenderEn", manuscript.SubGenderManuscriptId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", manuscript.TochLanguageId);
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn", manuscript.WritingToolId);
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
