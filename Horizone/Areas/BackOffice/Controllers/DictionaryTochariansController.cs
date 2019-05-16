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

namespace Horizone.Areas.BackOffice.Controllers
{
    public class DictionaryTochariansController : BaseController
    {
        // GET: BackOffice/DictionaryTocharians
        public ActionResult Index()
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons");
            return View(dictionaryTocharians.ToList());
        }
        
        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult Details(int? id)
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
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }                   
        // GET: BackOffice/DictionaryTocharians/Create
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
   
        // POST: BackOffice/DictionaryTocharians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,NominateMasculineSingular,NominateMasculineDual,NominateMasculinePlural,NominateFeminineSingular,NominateFeminineDual,NominateFemininePlural,ObliqueMasculineSingular,ObliqueMasculineDual,ObliqueMasculinePlural,ObliqueFeminineSingular,ObliqueFeminineDual,ObliqueFemininePlural,VocativeMasculineSingular,VocativeMasculineDual,VocativeMasculinePlural,VocativeFeminineSingular,VocativeFeminineDual,VocativeFemininePlural,GenitiveMasculineSingular,GenitiveMasculineDual,GenitiveMasculinePlural,GenitiveFeminineSingular,GenitiveFeminineDual,GenitiveFemininePlural,LocativeMasculineSingular,LocativeMasculineDual,LocativeMasculinePlural,LocativeFeminineSingular,LocativeFeminineDual,LocativeFemininePlural,AblativeMasculineSingular,AblativeMasculineDual,AblativeMasculinePlural,AblativeFeminineSingular,AblativeFeminineDual,AblativeFemininePlural,AllativeMasculineSingular,AllativeMasculineDual,AllativeMasculinePlural,AllativeFeminineSingular,AllativeFeminineDual,AllativeFemininePlural,PerlativeMasculineSingular,PerlativeMasculineDual,PerlativeMasculinePlural,PerlativeFeminineSingular,PerlativeFeminineDual,PerlativeFemininePlural,InstrumentalMasculineSingular,InstrumentalMasculineDual,InstrumentalMasculinePlural,InstrumentalFeminineSingular,InstrumentalFeminineDual,InstrumentalFemininePlural,ComitativeMasculineSingular,ComitativeMasculineDual,ComitativeMasculinePlural,ComitativeFeminineSingular,ComitativeFeminineDual,ComitativeFemininePlural,CausativeMasculineSingular,CausativeMasculineDual,CausativeMasculinePlural,CausativeFeminineSingular,CausativeFeminineDual,CausativeFemininePlural,Stem,StemClass,Voice,Valency,PronounSuffix,TenseMood,Visible")] DictionaryTocharian dictionaryTocharian, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
                if (CaseId.Count() > 0)
                    dictionaryTocharian.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (CaseId.Count() == 0)
                    dictionaryTocharian.Cases = db.Cases.Where(x => x.Id == 1).ToList();
                if (GenderId.Count() > 0)
                    dictionaryTocharian.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (GenderId.Count() == 0)
                    dictionaryTocharian.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                if (NumberId.Count() > 0)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (NumberId.Count() == 0)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                if (PersonId.Count() > 0)
                    dictionaryTocharian.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                if (PersonId.Count() == 0)
                    dictionaryTocharian.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                db.DictionaryTocharians.Add(dictionaryTocharian);
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
            return View(dictionaryTocharian);
        }
       

        // GET: BackOffice/DictionaryTocharians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(t => t.TochLanguage).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
            if (dictionaryTocharian == null)
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
            return View(dictionaryTocharian);
        }
        
       
        // POST: BackOffice/DictionaryTocharians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,NominateMasculineSingular,NominateMasculineDual,NominateMasculinePlural,NominateFeminineSingular,NominateFeminineDual,NominateFemininePlural,ObliqueMasculineSingular,ObliqueMasculineDual,ObliqueMasculinePlural,ObliqueFeminineSingular,ObliqueFeminineDual,ObliqueFemininePlural,VocativeMasculineSingular,VocativeMasculineDual,VocativeMasculinePlural,VocativeFeminineSingular,VocativeFeminineDual,VocativeFemininePlural,GenitiveMasculineSingular,GenitiveMasculineDual,GenitiveMasculinePlural,GenitiveFeminineSingular,GenitiveFeminineDual,GenitiveFemininePlural,LocativeMasculineSingular,LocativeMasculineDual,LocativeMasculinePlural,LocativeFeminineSingular,LocativeFeminineDual,LocativeFemininePlural,AblativeMasculineSingular,AblativeMasculineDual,AblativeMasculinePlural,AblativeFeminineSingular,AblativeFeminineDual,AblativeFemininePlural,AllativeMasculineSingular,AllativeMasculineDual,AllativeMasculinePlural,AllativeFeminineSingular,AllativeFeminineDual,AllativeFemininePlural,PerlativeMasculineSingular,PerlativeMasculineDual,PerlativeMasculinePlural,PerlativeFeminineSingular,PerlativeFeminineDual,PerlativeFemininePlural,InstrumentalMasculineSingular,InstrumentalMasculineDual,InstrumentalMasculinePlural,InstrumentalFeminineSingular,InstrumentalFeminineDual,InstrumentalFemininePlural,ComitativeMasculineSingular,ComitativeMasculineDual,ComitativeMasculinePlural,ComitativeFeminineSingular,ComitativeFeminineDual,ComitativeFemininePlural,CausativeMasculineSingular,CausativeMasculineDual,CausativeMasculinePlural,CausativeFeminineSingular,CausativeFeminineDual,CausativeFemininePlural,Stem,StemClass,Voice,Valency,PronounSuffix,TenseMood,Visible")] DictionaryTocharian dictionaryTocharian, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            db.Entry(dictionaryTocharian).State = EntityState.Modified;

            db.DictionaryTocharians.Include(t => t.TochLanguage).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == dictionaryTocharian.Id);
 
            if (ModelState.IsValid)
            {
                if (CaseId.Count() == 0)
                    dictionaryTocharian.Cases = db.Cases.Where(x => x.Id == 1).ToList();
                if (CaseId.Count() > 0)
                    dictionaryTocharian.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId.Count() == 0)
                    dictionaryTocharian.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                if (GenderId.Count() > 0)
                    dictionaryTocharian.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId.Count() == 0)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                if (NumberId.Count() > 0)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (PersonId.Count() == 0)
                    dictionaryTocharian.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                if (PersonId.Count() > 0)
                    dictionaryTocharian.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();               
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
            return View(dictionaryTocharian);
        }
  
        // GET: BackOffice/DictionaryTocharians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Find(id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }
        // POST: BackOffice/DictionaryTocharians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Find(id);
            db.DictionaryTocharians.Remove(dictionaryTocharian);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
