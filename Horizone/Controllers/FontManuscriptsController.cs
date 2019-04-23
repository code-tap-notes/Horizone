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
            var manuscripts = db.Manuscripts.Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool);
            return View(manuscripts.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
        public ActionResult PrintIndex()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult AnalyseMaterial()
        {
            return View(db.AnalyseMaterials.Include("ImageUVs").Include("ImageAnalyses").ToList());
        }
       

        // GET: BackOffice/Manuscripts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        public ActionResult PrintManuscript()
        {
            var report = new ActionAsPdf("Details");
            return report;
        }
        // GET: BackOffice/Manuscripts/Details/layout/5
        public ActionResult LayoutManuscripts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.ImageManuscripts).Include(m => m.AlignmentType).Include(m => m.DescriptionManuscript).Include(m => m.Format).Include(m => m.GenderManuscript).Include(m => m.LanguageDetail).Include(m => m.LanguageStage).Include(m => m.Map).Include(m => m.Material).Include(m => m.Metric).Include(m => m.PaperColor).Include(m => m.RemarkAdd).Include(m => m.Ruling).Include(m => m.RulingColor).Include(m => m.RulingDetail).Include(m => m.Script).Include(m => m.ScriptAdd).Include(m => m.State).Include(m => m.SubGenderManuscript).Include(m => m.TochLanguage).Include(m => m.WritingTool).SingleOrDefault(m => m.Id == id);
            if (manuscript == null)
            {
                return HttpNotFound();
            }
            return View(manuscript);
        }
        public ActionResult Search(string search, string index, string language)
        {

            IEnumerable<Manuscript> manuscripts = db.Manuscripts;

            if (!string.IsNullOrWhiteSpace(search))
            {
                manuscripts = manuscripts.Where(x => x.Transliteration.Contains(search));

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

            if (manuscripts.Count() == 0)
            {
                Display("Aucun résultat");
            }

            return View("Search", manuscripts.ToList());
        }
    }
}