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
    public class NounAdjectivesController : BaseController
    {

        // GET: BackOffice/NounAdjectives
        public ActionResult Index(int page = 1, int pageSize = 200)
        {
            var nounAdjectives = db.NounAdjectives
                .Include(n => n.DictionaryTocharian)
                .Include(n => n.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Cases");
            return View(nounAdjectives.OrderBy(x => x.DictionaryTocharian.Word).ToPagedList(page, pageSize));
        }
        public ActionResult IndexNoun(int page = 1, int pageSize = 200)
        {
            var nounAdjectives = db.NounAdjectives
                .Include(n => n.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(n => n.DictionaryTocharian.Numbers)
                .Include("Cases").Include("Genders").Where(n => n.DictionaryTocharian.WordClass.Id == 2); ;
            return View(nounAdjectives.OrderBy(x => x.DictionaryTocharian.Word).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/NounAdjectives
        public ActionResult IndexAdjective(int page = 1, int pageSize = 200)
        {
            var nounAdjectives = db.NounAdjectives
            .Include(n => n.DictionaryTocharian.TochLanguage)
            .Include(n => n.DictionaryTocharian.WordClass)
            .Include(n => n.DictionaryTocharian.WordSubClass)
            .Include(n => n.DictionaryTocharian.Numbers)
            .Include("Cases").Include("Genders").Where(n=>n.DictionaryTocharian.WordClass.Id==4);
            return View(nounAdjectives.OrderBy(x => x.DictionaryTocharian.Word).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/NounAdjectives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives
                .Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Cases").SingleOrDefault(p => p.Id == id);
            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            return View(nounAdjective);
        }

        // GET: BackOffice/NounAdjectives/Create
        public ActionResult Create()
        {
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x=>x.WordClassId == 2 || x.WordClassId == 4).OrderBy(x=>x.Word), "Id", "Word");

            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x=>x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x=>x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");
            return View();
        }
        // POST: BackOffice/NounAdjectives/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DictionaryId")] NounAdjective nounAdjective, int[] CaseId, int[] GenderId)
        {
            if (ModelState.IsValid)
            {
                if (CaseId.Count() == 0)
                { nounAdjective.Cases = db.Cases.Where(x => x.Id == 1).ToList(); }

                else
                {
                    nounAdjective.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                }
                if (GenderId.Count() == 0)
                {
                    nounAdjective.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                }
                else
                {
                    nounAdjective.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                }
                db.NounAdjectives.Add(nounAdjective);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 2 || x.WordClassId == 4).OrderBy(x => x.Word), "Id", "Word");

            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");
            return View(nounAdjective);
        }

        // GET: BackOffice/NounAdjectives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives
                .Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.WordClass)
                .Include(d => d.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Cases").SingleOrDefault(p => p.Id == id);
            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 2 || x.WordClassId == 4).OrderBy(x => x.Word), "Id", "Word",nounAdjective.DictionaryId);

            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");
            return View(nounAdjective);
        }

        // POST: BackOffice/NounAdjectives/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DictionaryId")] NounAdjective nounAdjective, int[] CaseId, int[] GenderId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nounAdjective).State = EntityState.Modified;
                if (CaseId != null)
                    nounAdjective.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    nounAdjective.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (nounAdjective.Cases.Count() == 0)
                    nounAdjective.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
                if (nounAdjective.Genders.Count() == 0)
                    nounAdjective.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 2 || x.WordClassId == 4).OrderBy(x => x.Word), "Id", "Word",nounAdjective.DictionaryId);

            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");
            return View(nounAdjective);
        }

        // GET: BackOffice/NounAdjectives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include("Genders").Include("Cases")
                .SingleOrDefault(p => p.Id == id);
            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            return View(nounAdjective);
        }

        // POST: BackOffice/NounAdjectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NounAdjective nounAdjective = db.NounAdjectives
                .Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(p => p.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Cases").SingleOrDefault(p => p.Id == id);
            db.NounAdjectives.Remove(nounAdjective);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchDictionary(string search)
        {
            IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Include(d=>d.DictionaryTocharian)
                .Include(d => d.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.WordClass)
                .Include(d => d.DictionaryTocharian.WordSubClass)
;
            if (!string.IsNullOrWhiteSpace(search))
            {
                nounAdjectives = nounAdjectives.Where(x => x.DictionaryTocharian.Word.Contains(search));
            }
            if (nounAdjectives.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Count = nounAdjectives.Count();
            ViewBag.Search = search;
            return View("SearchDictionary", nounAdjectives.ToList());
        }
    }
}
