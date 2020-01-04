using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;
using PagedList;
using Rotativa;

namespace Horizone.Controllers
{
    public class FontBibliographiesController : BaseController
    {  
        // GET: FontBibliographies       
        public ActionResult Bibliographie(int page = 1, int pageSize = 40)
        {
            var bibliographys = db.Bibliographys;

            foreach (var item in db.Bibliographys)
                if (!item.Book) bibliographys.Add(item);
            return View(bibliographys.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
        public ActionResult Abbreviation(int page = 1, int pageSize = 40)
        {
            return View(db.Abreviations.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult Book()
        {
            var bibliographys = db.Bibliographys;

            foreach (var item in db.Bibliographys)
                if (item.Book) bibliographys.Add(item);
            return View(bibliographys.Include("ImageBooks").OrderBy(x => x.Title).ToList());
        }
        public ActionResult PrintAllReport()
        {
            var report = new ActionAsPdf("Bibliographie");
            return report;
        }
        public ActionResult PrintAbreviation()
        {
            var report = new ActionAsPdf("Abbreviation");
            return report;
        }

        // GET: FontBibliographies/Details/5
        public ActionResult Details(int? id)
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

        // GET: Bibliographies/Search/

        public ActionResult Search(string search)
        {
            IEnumerable<Bibliography> bibliographies = db.Bibliographys;

            if (!string.IsNullOrWhiteSpace(search))
            {
                bibliographies = bibliographies.Where(x => x.Author.Contains(search)
                || x.Title.Contains(search) || x.Journal.Contains(search));
                //|| x.PublicationDate.Contains(search));

            }

            if (bibliographies.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("Search", bibliographies.ToList());

        }
        public ActionResult SearchAbreviation(string search)
        {
            IEnumerable<Abreviation> abreviations = db.Abreviations;

            if (!string.IsNullOrWhiteSpace(search))
            {
                abreviations = abreviations.Where(x => x.Symbol == search);
              
            }
          
            if (abreviations.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;
            return View("SearchAbreviation", abreviations.ToList());
        }
        // GET: BackOffice/Verbs/Details/5
        public ActionResult DetailsAbbreviation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abreviation = db.Abreviations.SingleOrDefault(y => y.Id == id);

            if (abreviation == null)
            {
                return HttpNotFound();
            }
            return View(abreviation);
        }
    }
}
