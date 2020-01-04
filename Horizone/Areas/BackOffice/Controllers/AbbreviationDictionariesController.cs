using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Controllers;
using Horizone.Models;
using PagedList;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class AbbreviationDictionariesController : BaseController
    {
 
        // GET: BackOffice/AbbreviationDictionaries
        public ActionResult Index(int page = 1, int pageSize = 30)
        {
            return View(db.AbbreviationDictionaries.OrderBy(x=>x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult OtherAbbreviation(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.OtherAbbreviation == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult AbbreviationGrammatical(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.GrammaticalAbbreviation == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult AbbreviationLanguage(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.AbbreviationsLanguage == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        public ActionResult AbbreviationManuscript(int page = 1, int pageSize = 30)
        {
            var abbreviationDictionaries = db.AbbreviationDictionaries.Where(x => x.AbbreviationManuscript == true);
            return View(abbreviationDictionaries.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/Verbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.SingleOrDefault(y => y.Id == id);

            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }
        // GET: BackOffice/AbbreviationDictionaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/AbbreviationDictionaries/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symbol,Description,OtherAbbreviation, AbbreviationManuscript,AbbreviationsLanguage, GrammaticalAbbreviation")] AbbreviationDictionary abbreviationDictionary)
        {
            if (ModelState.IsValid)
            {
                db.AbbreviationDictionaries.Add(abbreviationDictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abbreviationDictionary);
        }

        // GET: BackOffice/AbbreviationDictionaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }

        // POST: BackOffice/AbbreviationDictionaries/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symbol,Description,OtherAbbreviation, AbbreviationManuscript,AbbreviationsLanguage, GrammaticalAbbreviation")] AbbreviationDictionary abbreviationDictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abbreviationDictionary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abbreviationDictionary);
        }

        // GET: BackOffice/AbbreviationDictionaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            if (abbreviationDictionary == null)
            {
                return HttpNotFound();
            }
            return View(abbreviationDictionary);
        }

        // POST: BackOffice/AbbreviationDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbbreviationDictionary abbreviationDictionary = db.AbbreviationDictionaries.Find(id);
            db.AbbreviationDictionaries.Remove(abbreviationDictionary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchAbbreviation(string search)
        {
            IEnumerable<AbbreviationDictionary> abbreviationDictionarys = db.AbbreviationDictionaries;
            IEnumerable<Abreviation> abbreviations = db.Abreviations;

            List<SearchResult> searchResults = new List<SearchResult>();
            foreach (var item in db.SearchResults)
            {
                db.SearchResults.Remove(item);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {

                abbreviationDictionarys = db.AbbreviationDictionaries.Where(x => x.Symbol == search);
                if (abbreviationDictionarys.Count() != 0)
                {
                    foreach (var item in abbreviationDictionarys)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "AbbreviationDictionaries", IdResult = item.Id, Summary = item.Description });
                    }
                }
                abbreviations = db.Abreviations.Where(x => x.Symbol == search);
                if (abbreviations.Count() != 0)
                {
                    foreach (var item in abbreviations)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Abbreviations", IdResult = item.Id, Summary = (item.Symbol + " - " + item.Description) });
                    }
                }

                foreach (var item in searchResults)
                {
                    db.SearchResults.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.Search = search;
            return View("SearchAbbreviation", db.SearchResults.ToList());
        }

    }
}
