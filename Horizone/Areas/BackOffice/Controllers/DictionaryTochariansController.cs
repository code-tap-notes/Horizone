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
    public class DictionaryTochariansController : BaseController
    {

        // GET: BackOffice/DictionaryTocharians
        public ActionResult Index(int page = 1, int pageSize = 50)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.Mood).Include(d => d.TenseAndAspect).Include(d => d.TochLanguage).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons");
            return View(dictionaryTocharians.OrderBy(x=>x.Word).ToPagedList(page, pageSize));
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
        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult AddNounAdjective(int? id)
        {
                  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.TenseAndAspect).Include(d => d.Mood).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            var nounAdjective = new NounAdjective();
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                nounAdjective.Cases = dictionaryTocharian.Cases.ToList();
                nounAdjective.Genders = dictionaryTocharian.Genders.ToList();
                nounAdjective.Numbers = dictionaryTocharian.Numbers.ToList();
                nounAdjective.TochWord = dictionaryTocharian.Word;
                nounAdjective.Sanskrit = dictionaryTocharian.Sanskrit;
                nounAdjective.English = dictionaryTocharian.English;
                nounAdjective.Francaise = dictionaryTocharian.Francaise;
                nounAdjective.German = dictionaryTocharian.German;
                nounAdjective.Latin = dictionaryTocharian.Latin;
                nounAdjective.Chinese = dictionaryTocharian.Chinese;
                nounAdjective.Stem = dictionaryTocharian.Stem;
                nounAdjective.StemClass = dictionaryTocharian.StemClass;
                nounAdjective.Visible = true;
                nounAdjective.EquivalentTA = dictionaryTocharian.EquivalentTA;
                nounAdjective.EquivalentTB = dictionaryTocharian.EquivalentTB;
                nounAdjective.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                nounAdjective.RelatedLexemes = dictionaryTocharian.RelatedLexemes;
                nounAdjective.RootCharacter = dictionaryTocharian.RootCharacter;
                nounAdjective.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                nounAdjective.InternalRootVowel = dictionaryTocharian.InternalRootVowel;

                nounAdjective.TochLanguageId = dictionaryTocharian.TochLanguageId;
                nounAdjective.WordClassId = dictionaryTocharian.WordClassId;
                nounAdjective.WordSubClassId = dictionaryTocharian.WordSubClassId;
                db.NounAdjectives.Add(nounAdjective);
                db.SaveChanges();
                return RedirectToAction("Edit", "nounAdjectives", new { id = nounAdjective.Id });
            }
            ViewBag.NewwordId = nounAdjective.Id;
            return View();
                       
        }
        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult AddVerb(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.TenseAndAspect).Include(d => d.Mood).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            var verb = new Verb();
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                verb.MoodId = dictionaryTocharian.MoodId;
                verb.ValencyId = dictionaryTocharian.ValencyId;
                verb.VoiceId = dictionaryTocharian.VoiceId;
                verb.TenseAndAspectId = dictionaryTocharian.TenseAndAspectId;
                verb.Numbers = dictionaryTocharian.Numbers.ToList();
                verb.Persons = dictionaryTocharian.Persons.ToList();
                verb.TochWord = dictionaryTocharian.Word;
                verb.Sanskrit = dictionaryTocharian.Sanskrit;
                verb.English = dictionaryTocharian.English;
                verb.Francaise = dictionaryTocharian.Francaise;
                verb.German = dictionaryTocharian.German;
                verb.Chinese = dictionaryTocharian.Chinese;
                verb.Latin = dictionaryTocharian.Latin;
                verb.Stem = dictionaryTocharian.Stem;
                verb.StemClass = dictionaryTocharian.StemClass;
                verb.InternalRootVowel = dictionaryTocharian.InternalRootVowel;

                verb.Visible = true;
                verb.EquivalentTA = dictionaryTocharian.EquivalentTA;
                verb.EquivalentTB = dictionaryTocharian.EquivalentTB;
                verb.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                verb.RelatedLexemes = dictionaryTocharian.RelatedLexemes;
                verb.RootCharacter = dictionaryTocharian.RootCharacter;
                verb.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                verb.PronounSuffix = dictionaryTocharian.PronounSuffix;
                verb.TochLanguageId = dictionaryTocharian.TochLanguageId;
                verb.WordClassId = dictionaryTocharian.WordClassId;
                verb.WordSubClassId = dictionaryTocharian.WordSubClassId;
                db.Verbs.Add(verb);
                db.SaveChanges();
                return RedirectToAction("Edit", "verbs", new { id = verb.Id });
            }
            ViewBag.NewwordId = verb.Id;
            return View();

        }
        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult AddPronoun(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.TenseAndAspect).Include(d => d.Mood).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            var pronoun = new Pronoun();
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                pronoun.Cases = dictionaryTocharian.Cases.ToList();
                pronoun.Genders = dictionaryTocharian.Genders.ToList();
                pronoun.Numbers = dictionaryTocharian.Numbers.ToList();
                pronoun.Persons = dictionaryTocharian.Persons.ToList();
                pronoun.TochWord = dictionaryTocharian.Word;
                pronoun.Sanskrit = dictionaryTocharian.Sanskrit;
                pronoun.English = dictionaryTocharian.English;
                pronoun.Francaise = dictionaryTocharian.Francaise;
                pronoun.German = dictionaryTocharian.German;
                pronoun.Latin = dictionaryTocharian.Latin;
                pronoun.Chinese = dictionaryTocharian.Chinese;
                pronoun.Stem = dictionaryTocharian.Stem;
                pronoun.StemClass = dictionaryTocharian.StemClass;
                pronoun.Visible = true;
                pronoun.EquivalentTA = dictionaryTocharian.EquivalentTA;
                pronoun.EquivalentTB = dictionaryTocharian.EquivalentTB;
                pronoun.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                pronoun.RelatedLexemes = dictionaryTocharian.RelatedLexemes;
                pronoun.RootCharacter = dictionaryTocharian.RootCharacter;
                pronoun.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                pronoun.InternalRootVowel = dictionaryTocharian.InternalRootVowel;
                
                pronoun.TochLanguageId = dictionaryTocharian.TochLanguageId;
                pronoun.WordClassId = dictionaryTocharian.WordClassId;
                pronoun.WordSubClassId = dictionaryTocharian.WordSubClassId;
                db.Pronouns.Add(pronoun);
                db.SaveChanges();
                return RedirectToAction("Edit", "pronouns", new { id = pronoun.Id });
            }
            ViewBag.NewwordId = pronoun.Id;
            return View();

        }
        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult AddWord(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.Valency).Include(d => d.Voice).Include(d => d.TenseAndAspect).Include(d => d.Mood).Include(d => d.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Include("Persons").SingleOrDefault(y => y.Id == id);
            var otherWord = new OtherWord();
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                otherWord.Numbers = dictionaryTocharian.Numbers.ToList();
                otherWord.TochWord = dictionaryTocharian.Word;
                otherWord.Sanskrit = dictionaryTocharian.Sanskrit;
                otherWord.English = dictionaryTocharian.English;
                otherWord.Francaise = dictionaryTocharian.Francaise;
                otherWord.German = dictionaryTocharian.German;
                otherWord.Latin = dictionaryTocharian.Latin;
                otherWord.Chinese = dictionaryTocharian.Chinese;
                otherWord.Stem = dictionaryTocharian.Stem;
                otherWord.StemClass = dictionaryTocharian.StemClass;
                otherWord.Visible = true;
                otherWord.EquivalentTA = dictionaryTocharian.EquivalentTA;
                otherWord.EquivalentTB = dictionaryTocharian.EquivalentTB;
                otherWord.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                otherWord.RelatedLexemes = dictionaryTocharian.RelatedLexemes;
                otherWord.RootCharacter = dictionaryTocharian.RootCharacter;
                otherWord.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                otherWord.InternalRootVowel = dictionaryTocharian.InternalRootVowel;

                otherWord.TochLanguageId = dictionaryTocharian.TochLanguageId;
                otherWord.WordClassId = dictionaryTocharian.WordClassId;
                otherWord.WordSubClassId = dictionaryTocharian.WordSubClassId;
                db.OtherWords.Add(otherWord);
                db.SaveChanges();
                return RedirectToAction("Edit", "OtherWords", new { id = otherWord.Id });
            }
            ViewBag.NewwordId = otherWord.Id;
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
        public ActionResult Create([Bind(Include = "Id,Word,Sanskrit,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix,Visible")] DictionaryTocharian dictionaryTocharian, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
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
                if (dictionaryTocharian.TochLanguageId == 1)
                {
                    dictionaryTocharian.EquivalentTA = dictionaryTocharian.Word;
                }
                if (dictionaryTocharian.TochLanguageId == 2)
                {
                    dictionaryTocharian.EquivalentTB = dictionaryTocharian.Word;
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
        public ActionResult Edit([Bind(Include = "Id,Word,Sanskrit,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix,Visible")] DictionaryTocharian dictionaryTocharian, int[] CaseId, int[] GenderId, int[] NumberId, int[] PersonId)
        {
            db.Entry(dictionaryTocharian).State = EntityState.Modified;
            db.DictionaryTocharians.Include(t => t.TochLanguage).Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == dictionaryTocharian.Id);
            
            if (ModelState.IsValid)
            {
                if (dictionaryTocharian.TochLanguageId == 1 || dictionaryTocharian.TochLanguageId == 3)
                {
                    dictionaryTocharian.EquivalentTA = dictionaryTocharian.Word;
                }
                if (dictionaryTocharian.TochLanguageId == 2 || dictionaryTocharian.TochLanguageId == 4)
                {
                    dictionaryTocharian.EquivalentTB = dictionaryTocharian.Word;
                }
                

                if (CaseId != null)
                    dictionaryTocharian.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    dictionaryTocharian.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId != null)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (PersonId != null)
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
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id); 
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
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include("Cases").Include("Genders").Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id); 
            //Case cases = dictionaryTocharian.Cases.Where(X=>X.Id ==id);
            db.DictionaryTocharians.Remove(dictionaryTocharian);
            db.SaveChanges();
            return RedirectToAction("Index");
        }    
    }
}
