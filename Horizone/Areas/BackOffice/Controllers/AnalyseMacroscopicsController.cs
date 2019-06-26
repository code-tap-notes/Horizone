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

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class AnalyseMacroscopicsController : BaseController
    {

        // GET: BackOffice/AnalyseMacroscopics
        public ActionResult Index()
        {
            var analyseMacroscopics = db.AnalyseMacroscopics.Include(a => a.Catalogie).Include(a => a.ChainLinesVisibility).Include(a => a.Drying).Include(a => a.FiberDirection).Include(a => a.FiberDistribution).Include(a => a.Format).Include(a => a.GenderManuscript).Include(a => a.LaidLinesRegularity).Include(a => a.ManufaturingDefect).Include(a => a.Map).Include(a => a.PaperColor).Include(a => a.PreparationPaperBeforeUsing).Include(a => a.Restore).Include(a => a.Ruling).Include(a => a.RulingColor).Include(a => a.Script).Include(a => a.SieveMark).Include(a => a.State).Include(a => a.TochLanguage).Include(a => a.WritingTool);
            return View(analyseMacroscopics.ToList());
        }

        // GET: BackOffice/AnalyseMacroscopics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.Include("TransmittedLights").SingleOrDefault(x => x.Id == id);
            if (analyseMacroscopic == null)
            {
                return HttpNotFound();
            }
            return View(analyseMacroscopic);
        }
        public ActionResult MacroscopicAnalyse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.Find(id);
            if (analyseMacroscopic == null)
            {
                return HttpNotFound();
            }
            return View(analyseMacroscopic);
        }
        public ActionResult PageLayout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.Find(id);
            if (analyseMacroscopic == null)
            {
                return HttpNotFound();
            }
            return View(analyseMacroscopic);
        }
        public ActionResult SheetDescription(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.Find(id);
            if (analyseMacroscopic == null)
            {
                return HttpNotFound();
            }
            return View(analyseMacroscopic);
        }
        // GET: BackOffice/AnalyseMacroscopics/Create
        public ActionResult Create()
        {
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name");
            ViewBag.ChainLinesVisibilityId = new SelectList(db.ChainLinesVisibilitys, "Id", "ChainLinesVisibilityEn");
            ViewBag.DryingId = new SelectList(db.Dryings, "Id", "DryingEn");
            ViewBag.FiberDirectionId = new SelectList(db.FiberDirections, "Id", "DirectionEn");
            ViewBag.FiberDistributionId = new SelectList(db.FiberDistributions, "Id", "DistributionEn");
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn");
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn");
            ViewBag.LaidLinesRegularityId = new SelectList(db.LaidLinesRegularitys, "Id", "LaidLinesRegularityEn");
            ViewBag.ManufaturingDefectId = new SelectList(db.ManufaturingDefects, "Id", "ManufaturingDefectEn");
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture");
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn");
            ViewBag.PreparationPaperBeforeUsingId = new SelectList(db.PreparationPaperBeforeUsings, "Id", "PreparationEn");
            ViewBag.RestoreId = new SelectList(db.Restores, "Id", "RestoreEn");
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn");
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn");
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn");
            ViewBag.SieveMarkId = new SelectList(db.SieveMarks, "Id", "SieveMarkEn");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn");
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn");
            return View();
        }

        // POST: BackOffice/AnalyseMacroscopics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CatalogieId,Index,MapId,EstimatedDateProduction,PlaceProduction,Title,GenderManuscriptId,StateId,TochLanguageId,FormatId,NumberOfHoles,Description,AverageThickness,Correction,SheetCondition,NeedForConservation,Observation,RestoreId,RulingId,NumberOfLine,ScriptId,PageFrame,PaperColorId,WritingToolId,SoftQuality,RattleQuality,Transparency,SurfaceAspect,RulingColorId,CoatingDecayingCondition,ClayOrSandParticules,SurfaceOnBothSides,FiberDistributionId,NumberLayer,SieveMarkId,FiberDirectionId,LaidLinesRegularityId,NumberChainLinePerCm,ChainLinesVisibilityId,SpaceBetweenLines,DryingId,PreparationPaperBeforeUsingId,ManufaturingDefectId,Visible")] AnalyseMacroscopic analyseMacroscopic)
        {
            if (ModelState.IsValid)
            {
                db.AnalyseMacroscopics.Add(analyseMacroscopic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name", analyseMacroscopic.CatalogieId);
            ViewBag.ChainLinesVisibilityId = new SelectList(db.ChainLinesVisibilitys, "Id", "ChainLinesVisibilityEn", analyseMacroscopic.ChainLinesVisibilityId);
            ViewBag.DryingId = new SelectList(db.Dryings, "Id", "DryingEn", analyseMacroscopic.DryingId);
            ViewBag.FiberDirectionId = new SelectList(db.FiberDirections, "Id", "DirectionEn", analyseMacroscopic.FiberDirectionId);
            ViewBag.FiberDistributionId = new SelectList(db.FiberDistributions, "Id", "DistributionEn", analyseMacroscopic.FiberDistributionId);
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn", analyseMacroscopic.FormatId);
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn", analyseMacroscopic.GenderManuscriptId);
            ViewBag.LaidLinesRegularityId = new SelectList(db.LaidLinesRegularitys, "Id", "LaidLinesRegularityEn", analyseMacroscopic.LaidLinesRegularityId);
            ViewBag.ManufaturingDefectId = new SelectList(db.ManufaturingDefects, "Id", "ManufaturingDefectEn", analyseMacroscopic.ManufaturingDefectId);
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture", analyseMacroscopic.MapId);
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn", analyseMacroscopic.PaperColorId);
            ViewBag.PreparationPaperBeforeUsingId = new SelectList(db.PreparationPaperBeforeUsings, "Id", "PreparationEn", analyseMacroscopic.PreparationPaperBeforeUsingId);
            ViewBag.RestoreId = new SelectList(db.Restores, "Id", "RestoreEn", analyseMacroscopic.RestoreId);
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn", analyseMacroscopic.RulingId);
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn", analyseMacroscopic.RulingColorId);
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn", analyseMacroscopic.ScriptId);
            ViewBag.SieveMarkId = new SelectList(db.SieveMarks, "Id", "SieveMarkEn", analyseMacroscopic.SieveMarkId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn", analyseMacroscopic.StateId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", analyseMacroscopic.TochLanguageId);
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn", analyseMacroscopic.WritingToolId);
            return View(analyseMacroscopic);
        }

        // GET: BackOffice/AnalyseMacroscopics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.Include("TransmittedLights").SingleOrDefault(x => x.Id == id);
            if (analyseMacroscopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name", analyseMacroscopic.CatalogieId);
            ViewBag.ChainLinesVisibilityId = new SelectList(db.ChainLinesVisibilitys, "Id", "ChainLinesVisibilityEn", analyseMacroscopic.ChainLinesVisibilityId);
            ViewBag.DryingId = new SelectList(db.Dryings, "Id", "DryingEn", analyseMacroscopic.DryingId);
            ViewBag.FiberDirectionId = new SelectList(db.FiberDirections, "Id", "DirectionEn", analyseMacroscopic.FiberDirectionId);
            ViewBag.FiberDistributionId = new SelectList(db.FiberDistributions, "Id", "DistributionEn", analyseMacroscopic.FiberDistributionId);
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn", analyseMacroscopic.FormatId);
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn", analyseMacroscopic.GenderManuscriptId);
            ViewBag.LaidLinesRegularityId = new SelectList(db.LaidLinesRegularitys, "Id", "LaidLinesRegularityEn", analyseMacroscopic.LaidLinesRegularityId);
            ViewBag.ManufaturingDefectId = new SelectList(db.ManufaturingDefects, "Id", "ManufaturingDefectEn", analyseMacroscopic.ManufaturingDefectId);
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture", analyseMacroscopic.MapId);
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn", analyseMacroscopic.PaperColorId);
            ViewBag.PreparationPaperBeforeUsingId = new SelectList(db.PreparationPaperBeforeUsings, "Id", "PreparationEn", analyseMacroscopic.PreparationPaperBeforeUsingId);
            ViewBag.RestoreId = new SelectList(db.Restores, "Id", "RestoreEn", analyseMacroscopic.RestoreId);
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn", analyseMacroscopic.RulingId);
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn", analyseMacroscopic.RulingColorId);
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn", analyseMacroscopic.ScriptId);
            ViewBag.SieveMarkId = new SelectList(db.SieveMarks, "Id", "SieveMarkEn", analyseMacroscopic.SieveMarkId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn", analyseMacroscopic.StateId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", analyseMacroscopic.TochLanguageId);
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn", analyseMacroscopic.WritingToolId);
            return View(analyseMacroscopic);
        }

        // POST: BackOffice/AnalyseMacroscopics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CatalogieId,Index,MapId,EstimatedDateProduction,PlaceProduction,Title,GenderManuscriptId,StateId,TochLanguageId,FormatId,NumberOfHoles,Description,AverageThickness,Correction,SheetCondition,NeedForConservation,Observation,RestoreId,RulingId,NumberOfLine,ScriptId,PageFrame,PaperColorId,WritingToolId,SoftQuality,RattleQuality,Transparency,SurfaceAspect,RulingColorId,CoatingDecayingCondition,ClayOrSandParticules,SurfaceOnBothSides,FiberDistributionId,NumberLayer,SieveMarkId,FiberDirectionId,LaidLinesRegularityId,NumberChainLinePerCm,ChainLinesVisibilityId,SpaceBetweenLines,DryingId,PreparationPaperBeforeUsingId,ManufaturingDefectId,Visible")] AnalyseMacroscopic analyseMacroscopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analyseMacroscopic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatalogieId = new SelectList(db.Catalogies, "Id", "Name", analyseMacroscopic.CatalogieId);
            ViewBag.ChainLinesVisibilityId = new SelectList(db.ChainLinesVisibilitys, "Id", "ChainLinesVisibilityEn", analyseMacroscopic.ChainLinesVisibilityId);
            ViewBag.DryingId = new SelectList(db.Dryings, "Id", "DryingEn", analyseMacroscopic.DryingId);
            ViewBag.FiberDirectionId = new SelectList(db.FiberDirections, "Id", "DirectionEn", analyseMacroscopic.FiberDirectionId);
            ViewBag.FiberDistributionId = new SelectList(db.FiberDistributions, "Id", "DistributionEn", analyseMacroscopic.FiberDistributionId);
            ViewBag.FormatId = new SelectList(db.Formats, "Id", "FormatEn", analyseMacroscopic.FormatId);
            ViewBag.GenderManuscriptId = new SelectList(db.GenderManuscripts, "Id", "NameGenderEn", analyseMacroscopic.GenderManuscriptId);
            ViewBag.LaidLinesRegularityId = new SelectList(db.LaidLinesRegularitys, "Id", "LaidLinesRegularityEn", analyseMacroscopic.LaidLinesRegularityId);
            ViewBag.ManufaturingDefectId = new SelectList(db.ManufaturingDefects, "Id", "ManufaturingDefectEn", analyseMacroscopic.ManufaturingDefectId);
            ViewBag.MapId = new SelectList(db.Maps, "Id", "NamePicture", analyseMacroscopic.MapId);
            ViewBag.PaperColorId = new SelectList(db.PaperColors, "Id", "PaperColorEn", analyseMacroscopic.PaperColorId);
            ViewBag.PreparationPaperBeforeUsingId = new SelectList(db.PreparationPaperBeforeUsings, "Id", "PreparationEn", analyseMacroscopic.PreparationPaperBeforeUsingId);
            ViewBag.RestoreId = new SelectList(db.Restores, "Id", "RestoreEn", analyseMacroscopic.RestoreId);
            ViewBag.RulingId = new SelectList(db.Rulings, "Id", "RulingEn", analyseMacroscopic.RulingId);
            ViewBag.RulingColorId = new SelectList(db.RulingColors, "Id", "RulingColorEn", analyseMacroscopic.RulingColorId);
            ViewBag.ScriptId = new SelectList(db.Scripts, "Id", "ScriptEn", analyseMacroscopic.ScriptId);
            ViewBag.SieveMarkId = new SelectList(db.SieveMarks, "Id", "SieveMarkEn", analyseMacroscopic.SieveMarkId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateEn", analyseMacroscopic.StateId);
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", analyseMacroscopic.TochLanguageId);
            ViewBag.WritingToolId = new SelectList(db.WritingTools, "Id", "WritingToolEn", analyseMacroscopic.WritingToolId);
            return View(analyseMacroscopic);
        }

        // GET: BackOffice/AnalyseMacroscopics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.SingleOrDefault(x => x.Id == id);
            if (analyseMacroscopic == null)
            {
                return HttpNotFound();
            }
            return View(analyseMacroscopic);
        }

        // POST: BackOffice/AnalyseMacroscopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnalyseMacroscopic analyseMacroscopic = db.AnalyseMacroscopics.SingleOrDefault(x => x.Id == id);
            db.AnalyseMacroscopics.Remove(analyseMacroscopic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new TransmittedLight();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.AnalyseMacroscopicId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.TransmittedLights.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "AnalyseMacroscopics", new { id = id });
            }
            Display("une image doit être séléctionnée");
            // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "AnalyseMacroscopics", new { id = id });
        }

        // GET
        public ActionResult DeletePicture(int id, int idanalyseMacroscopic)
        {
            TransmittedLight image = db.TransmittedLights.Find(id);
            db.TransmittedLights.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "AnalyseMacroscopics", new { id = idanalyseMacroscopic});
        }

    }
}
