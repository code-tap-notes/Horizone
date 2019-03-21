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

namespace Horizone.Controllers
{
    public class FontBibliographiesController : BaseController
    {  
        // GET: FontBibliographies       
        public ActionResult Bibliographie(int page = 1, int pageSize = 20)
        {
            return View(db.Bibliographys.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
        public ActionResult Print()
        {
            return View();
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
