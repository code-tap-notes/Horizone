using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;

namespace Horizone.Controllers
{
    public class FontTochPhrasesController : BaseController
    {        

        // GET: FontTochPhrases
        public ActionResult Index()
        {
            var tochPhrases = db.TochPhrases.Include(t => t.Language).Include(t => t.TochLanguage);
            return View(tochPhrases.ToList());
        }

        // GET: FontTochPhrases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochPhrase tochPhrase = db.TochPhrases.Include("Language").Include("TochLanguage").SingleOrDefault(x=>x.Id==id);
            if (tochPhrase == null)
            {
                return HttpNotFound();
            }
            return View(tochPhrase);
        }
        public ActionResult Search(string search)
        {

            IEnumerable<TochPhrase> tochPhrases = db.TochPhrases;

            if (!string.IsNullOrWhiteSpace(search))
            {
                tochPhrases = tochPhrases.Where(x => x.Phrase.Contains(search));

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

            if (tochPhrases.Count() == 0)
            {
                Display("Aucun résultat");
            }

            return View("Search", tochPhrases.ToList());
        }
    }
}
