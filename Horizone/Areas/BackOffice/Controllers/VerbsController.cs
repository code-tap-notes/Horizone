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
    public class VerbsController : BaseController
    {

        // GET: BackOffice/Verbs
        public ActionResult Index()
        {
            var verbs = db.Verbs.Include(v => v.DictionaryTocharian)
                .Include(v => v.DictionaryTocharian.TochLanguage)
                .Include(v => v.DictionaryTocharian.WordClass)
                .Include(v => v.DictionaryTocharian.WordSubClass)
                .Include(v => v.DictionaryTocharian.Numbers)
                .Include(v => v.Mood).Include(v => v.TenseAndAspect)
                .Include(v => v.Valency).Include(v => v.Voice)               
                .Include("Persons");
            return View(verbs.OrderBy(x => x.DictionaryTocharian.Word).ToList());
        }
        // GET: BackOffice/Verbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include(v => v.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include(v => v.Mood).Include(v => v.TenseAndAspect)
                .Include(v => v.Valency).Include(v => v.Voice)                
                .Include("Persons").SingleOrDefault(p => p.Id == id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            return View(verb);
        }

        // GET: BackOffice/Verbs/Create
        public ActionResult Create()
        {
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 10).OrderBy(x=>x.Word), "Id", "Word");
 
            ViewBag.MoodEnId = new SelectList(db.Moods.OrderBy(x=>x.MoodEn), "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods.OrderBy(x => x.MoodFr), "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods.OrderBy(x => x.MoodZh), "Id", "MoodZh");

            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseEn), "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseFr), "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseZh), "Id", "TenseZh");

            ViewBag.ValencyEnId = new SelectList(db.Valencies.OrderBy(x => x.ValencyEn), "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies.OrderBy(x => x.ValencyFr), "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies.OrderBy(x => x.ValencyZh), "Id", "ValencyZh");

            ViewBag.VoiceEnId = new SelectList(db.Voices.OrderBy(x => x.VoiceEn), "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices.OrderBy(x => x.VoiceFr), "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices.OrderBy(x => x.VoiceZh), "Id", "VoiceZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");

            return View();
        }

        // POST: BackOffice/Verbs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DictionaryId,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix")] Verb verb, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
                  if (PersonId.Count() == 0)
                {
                    verb.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                }
                else
                {
                    verb.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                }

                db.Verbs.Add(verb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 10).OrderBy(x => x.Word), "Id", "Word");

            ViewBag.MoodEnId = new SelectList(db.Moods.OrderBy(x => x.MoodEn), "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods.OrderBy(x => x.MoodFr), "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods.OrderBy(x => x.MoodZh), "Id", "MoodZh");

            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseEn), "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseFr), "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseZh), "Id", "TenseZh");

            ViewBag.ValencyEnId = new SelectList(db.Valencies.OrderBy(x => x.ValencyEn), "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies.OrderBy(x => x.ValencyFr), "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies.OrderBy(x => x.ValencyZh), "Id", "ValencyZh");

            ViewBag.VoiceEnId = new SelectList(db.Voices.OrderBy(x => x.VoiceEn), "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices.OrderBy(x => x.VoiceFr), "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices.OrderBy(x => x.VoiceZh), "Id", "VoiceZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");

            return View(verb);
        }

        // GET: BackOffice/Verbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include(p => p.DictionaryTocharian)
                .Include(p => p.DictionaryTocharian.TochLanguage)
                .Include(n => n.DictionaryTocharian.WordClass)
                .Include(n => n.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Include("Persons").SingleOrDefault(p => p.Id == id);
            if (verb == null)
            {
                return HttpNotFound();
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 10).OrderBy(x => x.Word), "Id", "Word",verb.DictionaryId);

            ViewBag.MoodEnId = new SelectList(db.Moods.OrderBy(x => x.MoodEn), "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods.OrderBy(x => x.MoodFr), "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods.OrderBy(x => x.MoodZh), "Id", "MoodZh");

            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseEn), "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseFr), "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseZh), "Id", "TenseZh");

            ViewBag.ValencyEnId = new SelectList(db.Valencies.OrderBy(x => x.ValencyEn), "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies.OrderBy(x => x.ValencyFr), "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies.OrderBy(x => x.ValencyZh), "Id", "ValencyZh");

            ViewBag.VoiceEnId = new SelectList(db.Voices.OrderBy(x => x.VoiceEn), "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices.OrderBy(x => x.VoiceFr), "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices.OrderBy(x => x.VoiceZh), "Id", "VoiceZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");

            return View(verb);
        }

        // POST: BackOffice/Verbs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DictionaryId,VoiceId,ValencyId,TenseAndAspectId,MoodId,PronounSuffix")] Verb verb, int[] PersonId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verb).State = EntityState.Modified;
              
                if (PersonId != null)
                    verb.Persons = db.Persons.Where(x => PersonId.Contains(x.Id)).ToList();
                if (verb.Persons.Count() == 0)
                    verb.Persons = db.Persons.Where(x => x.ConjugatedPersonEn == "No Person").ToList();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId == 10).OrderBy(x => x.Word), "Id", "Word",verb.DictionaryId);

            ViewBag.MoodEnId = new SelectList(db.Moods.OrderBy(x => x.MoodEn), "Id", "MoodEn");
            ViewBag.MoodFrId = new SelectList(db.Moods.OrderBy(x => x.MoodFr), "Id", "MoodFr");
            ViewBag.MoodZhId = new SelectList(db.Moods.OrderBy(x => x.MoodZh), "Id", "MoodZh");

            ViewBag.TenseAndAspectEnId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseEn), "Id", "TenseEn");
            ViewBag.TenseAndAspectFrId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseFr), "Id", "TenseFr");
            ViewBag.TenseAndAspectZhId = new SelectList(db.TenseAndAspects.OrderBy(x => x.TenseZh), "Id", "TenseZh");

            ViewBag.ValencyEnId = new SelectList(db.Valencies.OrderBy(x => x.ValencyEn), "Id", "ValencyEn");
            ViewBag.ValencyFrId = new SelectList(db.Valencies.OrderBy(x => x.ValencyFr), "Id", "ValencyFr");
            ViewBag.ValencyZhId = new SelectList(db.Valencies.OrderBy(x => x.ValencyZh), "Id", "ValencyZh");

            ViewBag.VoiceEnId = new SelectList(db.Voices.OrderBy(x => x.VoiceEn), "Id", "VoiceEn");
            ViewBag.VoiceFrId = new SelectList(db.Voices.OrderBy(x => x.VoiceFr), "Id", "VoiceFr");
            ViewBag.VoiceZhId = new SelectList(db.Voices.OrderBy(x => x.VoiceZh), "Id", "VoiceZh");

            ViewBag.PersonsEn = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonEn");
            ViewBag.PersonsFr = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonFr");
            ViewBag.PersonsZh = new SelectList(db.Persons.OrderBy(x => x.ConjugatedPersonEn), "Id", "ConjugatedPersonZh");

            return View(verb);
        }

        // GET: BackOffice/Verbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verb verb = db.Verbs.Include(p => p.DictionaryTocharian).Include(p => p.DictionaryTocharian.TochLanguage).Include("Persons").SingleOrDefault(p => p.Id == id);
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
            Verb verb = db.Verbs.Include(p => p.DictionaryTocharian).Include(p => p.DictionaryTocharian.TochLanguage).Include("Persons").SingleOrDefault(p => p.Id == id);
            db.Verbs.Remove(verb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchDictionary(string search)
        {
            IEnumerable<Verb> verbs = db.Verbs.Include(d => d.DictionaryTocharian)
                .Include(d => d.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.WordClass)
                .Include(d => d.DictionaryTocharian.WordSubClass)
;
            if (!string.IsNullOrWhiteSpace(search))
            {
                verbs = verbs.Where(x => x.DictionaryTocharian.Word.Contains(search));
            }
            if (verbs.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Count = verbs.Count();
            ViewBag.Search = search;
            return View("SearchDictionary", verbs.ToList());
        }
    }
}
