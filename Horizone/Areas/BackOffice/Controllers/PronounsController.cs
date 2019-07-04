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
        public ActionResult Index(int page = 1, int pageSize = 50)
        {
            var pronouns = db.Pronouns.Include(p => p.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons"); ;
            return View(pronouns.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }

        // GET: BackOffice/Pronouns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include(p => p.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            if (pronoun.Cases.Count() == 0)
                pronoun.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
            if (pronoun.Genders.Count() == 0)
                pronoun.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();
            if (pronoun.Numbers.Count() == 0)
                pronoun.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();
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
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses, "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses, "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses, "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses, "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses, "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses, "Id", "SubClassZh");

            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");

            return View();
        }

        // POST: BackOffice/Pronouns/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] Pronoun pronoun, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
                if (CaseId.Count() > 0)
                {
                    pronoun.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                }
                else { pronoun.Cases = db.Cases.Where(x => x.Id == 1).ToList(); }
                if (GenderId.Count() > 0)
                {
                    pronoun.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                }
                else
                {
                    pronoun.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                }
                if (NumberId.Count() > 0)
                {
                    pronoun.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                else
                {
                    pronoun.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }
                if (PersonId.Count() > 0)
                {
                    pronoun.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                }
                else
                {
                    pronoun.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                }
                if (pronoun.TochLanguageId == 1)
                {
                    pronoun.EquivalentTA = pronoun.TochWord;
                }
                if (pronoun.TochLanguageId == 2)
                {
                    pronoun.EquivalentTB = pronoun.TochWord;
                }
                db.Pronouns.Add(pronoun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses, "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses, "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses, "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses, "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses, "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses, "Id", "SubClassZh");

            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");
            return View(pronoun);
        }

        // GET: BackOffice/Pronouns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include(t => t.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
            if (pronoun == null)
            {
                return HttpNotFound();
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses, "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses, "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses, "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses, "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses, "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses, "Id", "SubClassZh");

            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");
            return View(pronoun);
        }

        // POST: BackOffice/Pronouns/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] Pronoun pronoun, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            db.Entry(pronoun).State = EntityState.Modified;
            db.Pronouns.Include(t => t.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == pronoun.Id);

            if (ModelState.IsValid)
            {
                if (pronoun.TochLanguageId == 1 || pronoun.TochLanguageId == 3)
                {
                    pronoun.EquivalentTA = pronoun.TochWord;
                }
                if (pronoun.TochLanguageId == 2 || pronoun.TochLanguageId == 4)
                {
                    pronoun.EquivalentTB = pronoun.TochWord;
                }

                if (CaseId != null)
                    pronoun.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    pronoun.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId != null)
                    pronoun.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (PersonId != null)
                    pronoun.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses, "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses, "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses, "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses, "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses, "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses, "Id", "SubClassZh");

            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");
            return View(pronoun);
        }

        // GET: BackOffice/Pronouns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
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
            Pronoun pronoun = db.Pronouns.Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
            db.Pronouns.Remove(pronoun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
