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
    public class VerbsController : BaseController
    {

        // GET: BackOffice/Verbs
        public ActionResult Index(int page = 1, int pageSize = 50)
        {
            var verbs = db.Verbs.Include(v => v.Mood).Include(v => v.TenseAndAspect).Include(v => v.TochLanguage).Include(v => v.Valency).Include(v => v.Voice).Include(v => v.WordClass).Include(v => v.WordSubClass).Include("Numbers").Include("Persons"); ;
            return View(verbs.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }

        // GET: BackOffice/Verbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include(v => v.Mood).Include(v => v.TenseAndAspect).Include(v => v.TochLanguage).Include(v => v.Valency).Include(v => v.Voice).Include(v => v.WordClass).Include(v => v.WordSubClass).Include("Numbers").Include("Persons").SingleOrDefault(y => y.Id == id);
 
            if (verb.Numbers.Count() == 0)
                verb.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();
            if (verb.Persons.Count() == 0)
                verb.Persons = db.Persons.Where(x => x.ConjugatedPersonEn == "No Person").ToList();

            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }

        // GET: BackOffice/Verbs/Create
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

         
            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");

            return View();
        }

        // POST: BackOffice/Verbs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] Verb verb, int[] NumberId, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
               
                if (NumberId.Count() > 0)
                {
                    verb.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                else
                {
                    verb.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }
                if (PersonId.Count() > 0)
                {
                    verb.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                }
                else
                {
                    verb.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                }
                if (verb.TochLanguageId == 1)
                {
                    verb.EquivalentTA = verb.TochWord;
                }
                if (verb.TochLanguageId == 2)
                {
                    verb.EquivalentTB = verb.TochWord;
                }
                db.Verbs.Add(verb);
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


            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");
            return View(verb);
        }

        // GET: BackOffice/Verbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include(t => t.TochLanguage).Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
            if (verb == null)
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


            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");
            return View(verb);
        }

        // POST: BackOffice/Verbs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] Verb verb, int[] NumberId, int[] PersonId)
        {
            db.Entry(verb).State = EntityState.Modified;
            db.Verbs.Include(t => t.TochLanguage).Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == verb.Id);

            if (ModelState.IsValid)
            {
                if (verb.TochLanguageId == 1 || verb.TochLanguageId == 3)
                {
                    verb.EquivalentTA = verb.TochWord;
                }
                if (verb.TochLanguageId == 2 || verb.TochLanguageId == 4)
                {
                    verb.EquivalentTB = verb.TochWord;
                }

                if (NumberId != null)
                    verb.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                if (PersonId != null)
                    verb.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();

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


            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            ViewBag.PersonsEn = new SelectList(db.Persons, "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons, "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons, "Id", "ConjugatedPersonZh");
            return View(verb);
        }

        // GET: BackOffice/Verbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }

        // POST: BackOffice/Verbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verb verb = db.Verbs.Include("Numbers").Include("Persons").SingleOrDefault(x => x.Id == id);
            db.Verbs.Remove(verb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
