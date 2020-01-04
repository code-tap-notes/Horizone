using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;
using Rotativa;

namespace Horizone.Controllers
{
    public class FontTochPhrasesController : BaseController
    {        

        // GET: FontTochPhrases
        public ActionResult Index()
        {
            var tochPhrases = db.TochPhrases.Include(t => t.TochLanguage);
            return View(tochPhrases.ToList());
        }

        // GET: FontTochPhrases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TochPhrase tochPhrase = db.TochPhrases.Include("TochLanguage").SingleOrDefault(x=>x.Id==id);
            if (tochPhrase == null)
            {
                return HttpNotFound();
            }
            return View(tochPhrase);
        }
        public ActionResult PrintPhrase()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult Search(string search)
        {

            IEnumerable<TochPhrase> tochPhrases = db.TochPhrases;

            if (!string.IsNullOrWhiteSpace(search))
            {
                tochPhrases = db.TochPhrases.Include("TochLanguage").Where(x => x.Phrase.Contains(search) 
                || (x.English != null && x.English.Contains(search)) 
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.Chinese !=null && x.Chinese.Contains(search)));
             
            }
           
            if (tochPhrases.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("Search", tochPhrases.ToList());
        }

    }
}
