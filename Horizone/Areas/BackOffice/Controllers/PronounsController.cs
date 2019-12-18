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
        public ActionResult Index(int page = 1, int pageSize = 200)
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
        //Add a new word to dictionary
        public ActionResult AddDictionary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pronoun pronoun = db.Pronouns.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Genders").SingleOrDefault(y => y.Id == id);
            var dictionaryTocharian = new DictionaryTocharian();
            if (pronoun == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (pronoun.TochWord != null)
            {
                IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Where(x => x.Word == pronoun.TochWord);

                if (dictionaryTocharians.Count() == 0)
                {
                    dictionaryTocharian.Word = pronoun.TochWord;
                    dictionaryTocharian.Sanskrit = pronoun.Sanskrit;
                    dictionaryTocharian.English = pronoun.English;
                    dictionaryTocharian.Francaise = pronoun.Francaise;
                    dictionaryTocharian.German = pronoun.German;
                    dictionaryTocharian.Latin = pronoun.Latin;
                    dictionaryTocharian.Chinese = pronoun.Chinese;
                    dictionaryTocharian.Visible = true;
                    dictionaryTocharian.EquivalentTA = pronoun.EquivalentTA;
                    dictionaryTocharian.EquivalentTB = pronoun.EquivalentTB;
                    dictionaryTocharian.TochCommon = pronoun.TochCommon;
                    dictionaryTocharian.TochCorrespondence = pronoun.TochCorrespondence;
                    dictionaryTocharian.EquivalentInOther = pronoun.EquivalentInOther;
                    dictionaryTocharian.TochLanguageId = pronoun.TochLanguageId;
                    dictionaryTocharian.WordClassId = pronoun.WordClassId;
                    dictionaryTocharian.WordSubClassId = pronoun.WordSubClassId;
                    dictionaryTocharian.IdClassSource = pronoun.Id;

                    db.DictionaryTocharians.Add(dictionaryTocharian);

                }
                else
                {
                    Display("Mots existé");
                }

                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        //Update a word in dictionary
        public ActionResult EditDictionary(int? id)
        {
            Pronoun pronoun = db.Pronouns.Include("WordClass").Include("WordSubClass").Include("TochLanguage").SingleOrDefault(x => x.Id == id);
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include("TochLanguage").Include("WordClass").Include("WordSubClass").SingleOrDefault(x => x.Word == pronoun.TochWord && x.WordClass.ClassEn == "Pronoun" && x.IdClassSource == pronoun.Id);
            if (dictionaryTocharian == null)
            {
                AddDictionary(pronoun.Id);
            }
                if (dictionaryTocharian != null)
            {

                dictionaryTocharian.Sanskrit = pronoun.Sanskrit;
                dictionaryTocharian.English = pronoun.English;
                dictionaryTocharian.Francaise = pronoun.Francaise;
                dictionaryTocharian.German = pronoun.German;
                dictionaryTocharian.Latin = pronoun.Latin;
                dictionaryTocharian.Chinese = pronoun.Chinese;
                dictionaryTocharian.Visible = true;
                dictionaryTocharian.EquivalentTA = pronoun.EquivalentTA;
                dictionaryTocharian.EquivalentTB = pronoun.EquivalentTB;
                dictionaryTocharian.TochCommon = pronoun.TochCommon;
                dictionaryTocharian.TochCorrespondence = pronoun.TochCorrespondence;
                dictionaryTocharian.EquivalentInOther = pronoun.EquivalentInOther;
                dictionaryTocharian.TochLanguageId = pronoun.TochLanguageId;
                dictionaryTocharian.WordClassId = pronoun.WordClassId;
                dictionaryTocharian.WordSubClassId = pronoun.WordSubClassId;
                dictionaryTocharian.IdClassSource = pronoun.Id;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: BackOffice/Pronouns/Create
        public ActionResult Create()
        {
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassZh");

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
        public ActionResult Create([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] Pronoun pronoun, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
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

                if (NumberId.Count() == 0)
                {
                    pronoun.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }
               
                else
                {
                    pronoun.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                if (PersonId.Count() == 0)
                {
                    pronoun.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                }
                else
                {
                    pronoun.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                }

                if (pronoun.TochLanguageId == 1 || pronoun.TochLanguageId == 3 || pronoun.TochLanguageId == 6)
                {
                    pronoun.EquivalentTA = pronoun.TochWord;
                }
                if (pronoun.TochLanguageId == 2 || pronoun.TochLanguageId == 4 || pronoun.TochLanguageId == 6 || pronoun.TochLanguageId == 8)
                {
                    pronoun.EquivalentTB = pronoun.TochWord;
                }
                if (pronoun.TochLanguageId == 7)
                {
                    pronoun.Sanskrit = pronoun.TochWord;
                }

                db.Pronouns.Add(pronoun);
                db.SaveChanges();
                AddDictionary(pronoun.Id);
                return RedirectToAction("Index");
            }

            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassZh");

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

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassZh");

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
        public ActionResult Edit([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] Pronoun pronoun, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            db.Entry(pronoun).State = EntityState.Modified;
            db.Pronouns.Include(t => t.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == pronoun.Id);

            if (ModelState.IsValid)
            {
                if (pronoun.TochLanguageId == 1 || pronoun.TochLanguageId == 3 || pronoun.TochLanguageId == 6)
                {
                    pronoun.EquivalentTA = pronoun.TochWord;
                }
                if (pronoun.TochLanguageId == 2 || pronoun.TochLanguageId == 4 || pronoun.TochLanguageId == 6 || pronoun.TochLanguageId == 8)
                {
                    pronoun.EquivalentTB = pronoun.TochWord;
                }
                if (pronoun.TochLanguageId == 7)
                {
                    pronoun.Sanskrit = pronoun.TochWord;
                }

                if (CaseId != null)
                    pronoun.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    pronoun.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId != null)
                    pronoun.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (PersonId != null)
                    pronoun.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                if (pronoun.Cases.Count() == 0)
                    pronoun.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
                if (pronoun.Genders.Count() == 0)
                    pronoun.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();
                if (pronoun.Numbers.Count() == 0)
                    pronoun.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();
                if (pronoun.Persons.Count() == 0)
                    pronoun.Persons = db.Persons.Where(x => x.ConjugatedPersonEn == "No Person").ToList();

                EditDictionary(pronoun.Id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Pronoun"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Pronoun"), "Id", "SubClassZh");

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
       
        public ActionResult SearchPronoun(string search)
        {           
                IEnumerable<Pronoun> pronouns = db.Pronouns.Include("WordClass").Include("WordSubClass").Include("TochLanguage").Include("Genders").Include("Cases").Include("Persons").Where(x => x.TochWord.Contains(search)
                    || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                    || (x.English != null && x.English.Contains(search))
                    || (x.Francaise != null && x.Francaise.Contains(search))
                    || (x.German != null && x.German.Contains(search))
                    || (x.Latin != null && x.Latin.Contains(search))
                    || (x.Chinese != null && x.Chinese.Contains(search))
                  );

                if (pronouns.Count() == 0)
                {
                    Display("Aucun résultat");
                }
            ViewBag.Search = search;
            return View("SearchPronoun", pronouns.ToList());
        }
    }
}
