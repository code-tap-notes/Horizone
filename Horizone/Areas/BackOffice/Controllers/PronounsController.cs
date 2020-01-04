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
    public class PronounsController : BaseController
    {
        // GET: BackOffice/Pronouns
        public ActionResult Index()
        {
            var pronouns = db.Pronouns.Include(p => p.DictionaryTocharian)
                .Include(p=>p.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Persons").Include("Cases").OrderBy(x => x.DictionaryTocharian.Word);
            return View(pronouns.ToList());
        }
        // GET: BackOffice/Pronouns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Persons").Include("Cases")
                .SingleOrDefault(p=>p.Id == id);
            if (pronoun.Cases.Count() == 0)
                pronoun.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
            if (pronoun.Genders.Count() == 0)
                pronoun.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();
            if (pronoun.Persons.Count() == 0)
                pronoun.Persons = db.Persons.Where(x => x.ConjugatedPersonEn == "No Person").ToList();
            if (pronoun == null)
            {
                return HttpNotFound();
            }
            return View(pronoun);
        }
        // GET: BackOffice/Pronouns/Create
        public ActionResult Create()
        {
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 3 || x.WordSubClassId == 80).OrderBy(x => x.Word), "Id", "Word");


            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");
            return View();
        }

        // POST: BackOffice/Pronouns/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DictionaryId")] Pronoun pronoun, int[] CaseId, int[] GenderId, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
               
                if (CaseId.Count() == 0)
                { pronoun.Cases = db.Cases.Where(x => x.Id == 1).ToList(); }

                else
                {
                    pronoun.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                }
                if (GenderId.Count() == 0)
                {
                    pronoun.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                }
                else
                {
                    pronoun.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                }                               
                if (PersonId.Count() == 0)
                {
                    pronoun.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                }
                else
                {
                    pronoun.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                }
                db.Pronouns.Add(pronoun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 3 || x.WordSubClassId == 80).OrderBy(x => x.Word), "Id", "Word", pronoun.DictionaryId);

            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");
            return View(pronoun);
        }

        // GET: BackOffice/Pronouns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include("Genders").Include("Persons").Include("Cases")
                .SingleOrDefault(p => p.Id == id);
            if (pronoun == null)
            {
                return HttpNotFound();
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 3 || x.WordSubClassId == 80).OrderBy(x => x.Word), "Id", "Word", pronoun.DictionaryId);


            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");
            return View(pronoun);
        }

        // POST: BackOffice/Pronouns/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DictionaryId")] Pronoun pronoun, int[] CaseId, int[] GenderId, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pronoun).State = EntityState.Modified;
                if (CaseId != null)
                    pronoun.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    pronoun.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (PersonId != null)
                    pronoun.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                if (pronoun.Cases.Count() == 0)
                    pronoun.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
                if (pronoun.Genders.Count() == 0)
                    pronoun.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();
                if (pronoun.Persons.Count() == 0)
                    pronoun.Persons = db.Persons.Where(x => x.ConjugatedPersonEn == "No Person").ToList();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 3 || x.WordSubClassId == 80).OrderBy(x => x.Word), "Id", "Word", pronoun.DictionaryId);

            ViewBag.CasesEn = new SelectList(db.Cases.OrderBy(x => x.NameCaseEn), "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases.OrderBy(x => x.NameCaseFr), "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases.OrderBy(x => x.NameCaseZh), "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders.OrderBy(x => x.NameGenderEn), "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders.OrderBy(x => x.NameGenderFr), "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders.OrderBy(x => x.NameGenderZh), "Id", "NameGenderZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");
            return View(pronoun);
        }

        // GET: BackOffice/Pronouns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include(p => p.DictionaryTocharian).Include(p => p.DictionaryTocharian.TochLanguage).Include("Genders").Include("Persons").Include("Cases").SingleOrDefault(p => p.Id == id);
            if (pronoun == null)
            {
                return HttpNotFound();
            }
            return View(pronoun);
        }

        // POST: BackOffice/Pronouns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pronoun pronoun = db.Pronouns.Include(p => p.DictionaryTocharian).Include(p => p.DictionaryTocharian.TochLanguage).Include("Genders").Include("Persons").Include("Cases").SingleOrDefault(p => p.Id == id);
            db.Pronouns.Remove(pronoun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchDictionary(string search)
        {
            IEnumerable<Pronoun> pronouns = db.Pronouns.Include(d => d.DictionaryTocharian)
                .Include(d => d.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.WordClass)
                .Include(d => d.DictionaryTocharian.WordSubClass)
;
            if (!string.IsNullOrWhiteSpace(search))
            {
                pronouns = pronouns.Where(x => x.DictionaryTocharian.Word.Contains(search));
            }
            if (pronouns.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Count = pronouns.Count();
            ViewBag.Search = search;
            return View("SearchDictionary", pronouns.ToList());
        }
    }
}
