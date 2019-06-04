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
        public ActionResult Reverse()
        {
            var reverseDictionaries = db.ReverseDictionaries;
            return View(reverseDictionaries.ToList());
        }
        public ActionResult CheckReverse(int? id)
        {           
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);

                if (dictionaryTocharian.Cases.Count() == 0)
                    dictionaryTocharian.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
                if (dictionaryTocharian.Genders.Count() == 0)
                    dictionaryTocharian.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();
                if (dictionaryTocharian.Numbers.Count() == 0)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();
                if (dictionaryTocharian.Persons.Count() == 0)
                    dictionaryTocharian.Persons = db.Persons.Where(x => x.ConjugatedPersonEn == "No Person").ToList();
                char[] cArray = dictionaryTocharian.Word.ToCharArray();
                string reverse = String.Empty;
                for (int i = cArray.Length - 1; i > -1; i--)
                {
                    reverse += cArray[i];
                }
                IEnumerable<ReverseDictionary> reverseDictionaries = db.ReverseDictionaries;
                reverseDictionaries = reverseDictionaries.Where(x => (x.Word == reverse || x.ReverseWord == reverse));
                if (reverseDictionaries.Count() == 0)
                {
                    Display("Aucun reverse");
                }
                if (reverseDictionaries == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Id = id;
                ViewBag.Reverse = reverse;

                return View(reverseDictionaries.ToList());          
        }

        public ActionResult PrintVocabulaire()
        {
            var report = new ActionAsPdf("Vocabulaire");
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
       
        public ActionResult SearchAbbreviation(string search)
        {
            IEnumerable<AbbreviationDictionary> abbreviationDictionarys = db.AbbreviationDictionaries;

            if (!string.IsNullOrWhiteSpace(search))
            {
                abbreviationDictionarys = abbreviationDictionarys.Where(x => x.Symbol.Contains(search));
            }
            if (abbreviationDictionarys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("SearchAbbreviation", abbreviationDictionarys.ToList());
        }
        public ActionResult SearchReverse(string search)
        {
            IEnumerable<ReverseDictionary> reverseDictionarys = db.ReverseDictionaries;

            if (!string.IsNullOrWhiteSpace(search))
            {
                reverseDictionarys = reverseDictionarys.Where(x => x.Word.Contains(search)|| x.ReverseWord.Contains(search));
            }
            if (reverseDictionarys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return View("SearchReverse", reverseDictionarys.ToList());
        }
    }
}