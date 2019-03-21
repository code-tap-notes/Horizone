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

namespace Horizone.Controllers
{
    public class FontManuscriptsController : BaseController
    {
        // GET: Manuscripts
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            var manuscripts = db.Manuscripts.Include(m => m.TochLanguage).Include(m => m.Language).Include(m => m.Bibliographys);
            return View(manuscripts.OrderBy(x => x.Id).ToPagedList(page, pageSize));
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).Include(y => y.Bibliographys).SingleOrDefault(x => x.Id == id);
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
            Manuscript manuscript = db.Manuscripts.Include(y => y.Language).Include(y => y.TochLanguage).SingleOrDefault(x => x.Id == id);
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