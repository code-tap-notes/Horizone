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
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.Mood).Include(d => d.TenseAndAspect).Include(d => d.TochLanguage).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons");
            return View(dictionaryTocharians.ToList());
        }

        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.TenseAndAspect).Include(d => d.Mood).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
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
        // GET: BackOffice/DictionaryTocharians/Reverse/5
        public ActionResult Reverse(int? id)
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
       
        public ActionResult AddReverse(int? id)
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

            var reverseDictionary = new ReverseDictionary();
           
                char[] cArray = dictionaryTocharian.Word.ToCharArray();
                string reverse = String.Empty;
                for (int i = cArray.Length - 1; i > -1; i--)
                {
                    reverse += cArray[i];
                }
            if (ModelState.IsValid)
            {
                reverseDictionary.Word = dictionaryTocharian.Word;
                reverseDictionary.ReverseWord = reverse;
                db.ReverseDictionaries.Add(reverseDictionary);
                db.SaveChanges();

                return RedirectToAction("Index", "ReverseDictionaries");
            }
            ViewBag.Reverse = reverse;
            ViewBag.Id = id;
            return View();
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

            ViewBag.MoodEnId = new SelectList(db.Moods, "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods, "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods, "Id", "MoodZh");
            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects, "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects, "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects, "Id", "TenseZh");
            ViewBag.ValencyEnId = new SelectList(db.Valencies, "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies, "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies, "Id", "ValencyZh");
            ViewBag.VoiceEnId = new SelectList(db.Voices, "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices, "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices, "Id", "VoiceZh");
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
        public ActionResult Create([Bind(Include = "Id,Word,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,NominateMasculineSingular,NominateMasculineDual,NominateMasculinePlural,NominateFeminineSingular,NominateFeminineDual,NominateFemininePlural,NominateNeuterSingular,NominateNeuterDual,NominateNeuterPlural,ObliqueMasculineSingular,ObliqueMasculineDual,ObliqueMasculinePlural,ObliqueFeminineSingular,ObliqueFeminineDual,ObliqueFemininePlural,ObliqueNeuterSingular,ObliqueNeuterDual,ObliqueNeuterPlural,VocativeMasculineSingular,VocativeMasculineDual,VocativeMasculinePlural,VocativeFeminineSingular,VocativeFeminineDual,VocativeFemininePlural,VocativeNeuterSingular,VocativeNeuterDual,VocativeNeuterPlural,GenitiveMasculineSingular,GenitiveMasculineDual,GenitiveMasculinePlural,GenitiveFeminineSingular,GenitiveFeminineDual,GenitiveFemininePlural,GenitiveNeuterSingular,GenitiveNeuterDual,GenitiveNeuterPlural,LocativeMasculineSingular,LocativeMasculineDual,LocativeMasculinePlural,LocativeFeminineSingular,LocativeFeminineDual,LocativeFemininePlural,LocativeNeuterSingular,LocativeNeuterDual,LocativeNeuterPlural,AblativeMasculineSingular,AblativeMasculineDual,AblativeMasculinePlural,AblativeFeminineSingular,AblativeFeminineDual,AblativeFemininePlural,AblativeNeuterSingular,AblativeNeuterDual,AblativeNeuterPlural,AllativeMasculineSingular,AllativeMasculineDual,AllativeMasculinePlural,AllativeFeminineSingular,AllativeFeminineDual,AllativeFemininePlural,AllativeNeuterSingular,AllativeNeuterDual,AllativeNeuterPlural,PerlativeMasculineSingular,PerlativeMasculineDual,PerlativeMasculinePlural,PerlativeFeminineSingular,PerlativeFeminineDual,PerlativeFemininePlural,PerlativeNeuterSingular,PerlativeNeuterDual,PerlativeNeuterPlural,InstrumentalMasculineSingular,InstrumentalMasculineDual,InstrumentalMasculinePlural,InstrumentalFeminineSingular,InstrumentalFeminineDual,InstrumentalFemininePlural,InstrumentalNeuterSingular,InstrumentalNeuterDual,InstrumentalNeuterPlural,ComitativeMasculineSingular,ComitativeMasculineDual,ComitativeMasculinePlural,ComitativeFeminineSingular,ComitativeFeminineDual,ComitativeFemininePlural,ComitativeNeuterSingular,ComitativeNeuterDual,ComitativeNeuterPlural,CausativeMasculineSingular,CausativeMasculineDual,CausativeMasculinePlural,CausativeFeminineSingular,CausativeFeminineDual,CausativeFemininePlural,CausativeNeuterSingular,CausativeNeuterDual,CausativeNeuterPlural,Stem,StemClass,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix,Visible")] DictionaryTocharian dictionaryTocharian, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
                                
                if (CaseId.Count() > 0)
                {
                    dictionaryTocharian.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                }
                else { dictionaryTocharian.Cases = db.Cases.Where(x => x.Id == 1).ToList(); }
                if (GenderId.Count() > 0) { 
                    dictionaryTocharian.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                }
                else { 
                    dictionaryTocharian.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                }
                if (NumberId.Count() > 0)
                {
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                else
                {
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }
                if (PersonId.Count() > 0)
                {
                    dictionaryTocharian.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                }
                else
                {
                    dictionaryTocharian.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                }
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

            ViewBag.MoodEnId = new SelectList(db.Moods, "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods, "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods, "Id", "MoodZh");
            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects, "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects, "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects, "Id", "TenseZh");
            ViewBag.ValencyEnId = new SelectList(db.Valencies, "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies, "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies, "Id", "ValencyZh");
            ViewBag.VoiceEnId = new SelectList(db.Voices, "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices, "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices, "Id", "VoiceZh");
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

            ViewBag.MoodEnId = new SelectList(db.Moods, "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods, "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods, "Id", "MoodZh");
            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects, "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects, "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects, "Id", "TenseZh");
            ViewBag.ValencyEnId = new SelectList(db.Valencies, "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies, "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies, "Id", "ValencyZh");
            ViewBag.VoiceEnId = new SelectList(db.Voices, "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices, "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices, "Id", "VoiceZh");
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
        public ActionResult Edit([Bind(Include = "Id,Word,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,NominateMasculineSingular,NominateMasculineDual,NominateMasculinePlural,NominateFeminineSingular,NominateFeminineDual,NominateFemininePlural,NominateNeuterSingular,NominateNeuterDual,NominateNeuterPlural,ObliqueMasculineSingular,ObliqueMasculineDual,ObliqueMasculinePlural,ObliqueFeminineSingular,ObliqueFeminineDual,ObliqueFemininePlural,ObliqueNeuterSingular,ObliqueNeuterDual,ObliqueNeuterPlural,VocativeMasculineSingular,VocativeMasculineDual,VocativeMasculinePlural,VocativeFeminineSingular,VocativeFeminineDual,VocativeFemininePlural,VocativeNeuterSingular,VocativeNeuterDual,VocativeNeuterPlural,GenitiveMasculineSingular,GenitiveMasculineDual,GenitiveMasculinePlural,GenitiveFeminineSingular,GenitiveFeminineDual,GenitiveFemininePlural,GenitiveNeuterSingular,GenitiveNeuterDual,GenitiveNeuterPlural,LocativeMasculineSingular,LocativeMasculineDual,LocativeMasculinePlural,LocativeFeminineSingular,LocativeFeminineDual,LocativeFemininePlural,LocativeNeuterSingular,LocativeNeuterDual,LocativeNeuterPlural,AblativeMasculineSingular,AblativeMasculineDual,AblativeMasculinePlural,AblativeFeminineSingular,AblativeFeminineDual,AblativeFemininePlural,AblativeNeuterSingular,AblativeNeuterDual,AblativeNeuterPlural,AllativeMasculineSingular,AllativeMasculineDual,AllativeMasculinePlural,AllativeFeminineSingular,AllativeFeminineDual,AllativeFemininePlural,AllativeNeuterSingular,AllativeNeuterDual,AllativeNeuterPlural,PerlativeMasculineSingular,PerlativeMasculineDual,PerlativeMasculinePlural,PerlativeFeminineSingular,PerlativeFeminineDual,PerlativeFemininePlural,PerlativeNeuterSingular,PerlativeNeuterDual,PerlativeNeuterPlural,InstrumentalMasculineSingular,InstrumentalMasculineDual,InstrumentalMasculinePlural,InstrumentalFeminineSingular,InstrumentalFeminineDual,InstrumentalFemininePlural,InstrumentalNeuterSingular,InstrumentalNeuterDual,InstrumentalNeuterPlural,ComitativeMasculineSingular,ComitativeMasculineDual,ComitativeMasculinePlural,ComitativeFeminineSingular,ComitativeFeminineDual,ComitativeFemininePlural,ComitativeNeuterSingular,ComitativeNeuterDual,ComitativeNeuterPlural,CausativeMasculineSingular,CausativeMasculineDual,CausativeMasculinePlural,CausativeFeminineSingular,CausativeFeminineDual,CausativeFemininePlural,CausativeNeuterSingular,CausativeNeuterDual,CausativeNeuterPlural,Stem,StemClass,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix,Visible")] DictionaryTocharian dictionaryTocharian, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            db.Entry(dictionaryTocharian).State = EntityState.Modified;
            db.DictionaryTocharians.Include(t => t.TochLanguage).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == dictionaryTocharian.Id);

            if (ModelState.IsValid)
            {
                if (CaseId != null)
                    dictionaryTocharian.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    dictionaryTocharian.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId != null)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (PersonId != null)
                    dictionaryTocharian.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();

                /* if (CaseId.Count() == 0)
                     dictionaryTocharian.Cases = db.Cases.Where(x => x.Id == 1).ToList();
                 if (GenderId.Count() == 0)
                     dictionaryTocharian.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                 if (NumberId.Count() == 0)
                     dictionaryTocharian.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                 if (PersonId.Count() == 0)
                     dictionaryTocharian.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                 */
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

            ViewBag.MoodEnId = new SelectList(db.Moods, "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods, "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods, "Id", "MoodZh");
            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects, "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects, "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects, "Id", "TenseZh");
            ViewBag.ValencyEnId = new SelectList(db.Valencies, "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies, "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies, "Id", "ValencyZh");
            ViewBag.VoiceEnId = new SelectList(db.Voices, "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices, "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices, "Id", "VoiceZh");
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
