using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horizone.Models;
using PagedList;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Net;
using Horizone.Controllers;
using Rotativa;

namespace Horizone.Controllers
{
    public class VocabulariesController : BaseController
    {
        // GET: Vocabularies
        public ActionResult Vocabulaire()
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons");
            return View(dictionaryTocharians.ToList());
        }
        public ActionResult Abbreviation()
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries;
            return View(abbreviationDictionaries.ToList());
        }
        

            public ActionResult PrintVocabulaire()
        {
            var report = new ActionAsPdf("Details");
            return report;
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }
        public ActionResult Search(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians;
            if (!string.IsNullOrWhiteSpace(search))
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Word.Contains(search));              
            }          
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", dictionaryTocharians.ToList());
        }
        public ActionResult SearchEnglish(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians;
            if (!string.IsNullOrWhiteSpace(search))
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.English != null);
                dictionaryTocharians = dictionaryTocharians.Where(x => x.English.Contains(search));                
            }           
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", dictionaryTocharians.ToList());
        }
        public ActionResult SearchFrench(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians;
            if (!string.IsNullOrWhiteSpace(search)) 
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Francaise != null);
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Francaise.Contains(search));
            }
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", dictionaryTocharians.ToList());
        }
        public ActionResult SearchGerman(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians;
            if (!string.IsNullOrWhiteSpace(search))
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.German != null);
                dictionaryTocharians = dictionaryTocharians.Where(x => x.German.Contains(search));
            }
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", dictionaryTocharians.ToList());
        }
        public ActionResult SearchLatin(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians;
            if (!string.IsNullOrWhiteSpace(search))
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Latin != null);
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Latin.Contains(search));
            }
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", dictionaryTocharians.ToList());
        }
        public ActionResult SearchChinese(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians;
            if (!string.IsNullOrWhiteSpace(search))
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Chinese != null);
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Chinese.Contains(search));
            }
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("Search", dictionaryTocharians.ToList());
        }
    }
}