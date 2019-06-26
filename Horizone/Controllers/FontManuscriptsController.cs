using Horizone.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Net;
using Horizone.Controllers;
using Rotativa;

namespace Horizone.Controllers
{
    public class FontManuscriptsController : BaseController
    {
        // GET: Manuscripts
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            var manuscripts = db.Manuscripts.Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool);
            return View(manuscripts.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
        public ActionResult PrintIndex()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult PrintManuscript(int? id)
        {
            var report = new ActionAsPdf("Details", new { id = id });
            return report;
        }
        public ActionResult AnalyseMaterial()
        {
            return View(db.AnalyseMaterials.Include("ImageUVs").Include("ImageAnalyses").ToList());
        }
        // GET: BackOffice/AnalyseMacroscopics
        public ActionResult IndexAnalyseMacroscopic()
        {
            var analyseMacroscopics = db.AnalyseMacroscopics.Include(a => a.Catalogie).Include(a => a.ChainLinesVisibility).Include(a => a.Drying).Include(a => a.FiberDirection).Include(a => a.FiberDistribution).Include(a => a.Format).Include(a => a.GenderManuscript).Include(a => a.LaidLinesRegularity).Include(a => a.ManufaturingDefect).Include(a => a.Map).Include(a => a.PaperColor).Include(a => a.PreparationPaperBeforeUsing).Include(a => a.Restore).Include(a => a.Ruling).Include(a => a.RulingColor).Include(a => a.Script).Include(a => a.SieveMark).Include(a => a.State).Include(a => a.TochLanguage).Include(a => a.WritingTool);
            return View(analyseMacroscopics.ToList());
        }
        

             public ActionResult MacroscopicDetails(int? id)
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
        // GET: BackOffice/Manuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.Map).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        public ActionResult Search(string search)
        {

            IEnumerable<Manuscript> manuscripts = db.Manuscripts.Include("Catalogie").Include("Map").Include("ImageManuscripts").Include("State").Include("DescriptionManuscript").Include("RemarkAdd").Include("Format").Include("Ruling").Include("RulingColor").Include("RulingDetail").Include("Material").Include("PaperColor").Include("WritingTool").Include("AlignmentType").Include("Script").Include("ScriptAdd").Include("LanguageStage").Include("Tochlanguage").Include("LanguageDetail").Include("GenderManuscript").Include("SubGenderManuscript").Include("Metric").Include("Bibliographys");

            if (!string.IsNullOrWhiteSpace(search))
            {
                manuscripts = db.Manuscripts.Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.Script.ScriptType).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).Where(x => x.Transliteration.Contains(search));
             
            }           

            if (manuscripts.Count() == 0)
            {
                Display("Aucun résultat");
            }

            return View("Search", manuscripts.ToList());
        }
    }
}