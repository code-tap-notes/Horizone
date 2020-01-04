using Horizone.Controllers;
using Horizone.Models;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class DictionaryTochariansController : BaseController
    {

        // GET: BackOffice/DictionaryTocharians
        public ActionResult Index(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers");
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }

        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (dictionaryTocharian.Numbers.Count() == 0)
                dictionaryTocharian.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();

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


            ViewBag.WordClassEnId = new SelectList(db.WordClasses.OrderBy(x => x.ClassEn), "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.OrderBy(x => x.ClassFr), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.OrderBy(x => x.ClassZh), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassEn), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassFr), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassZh), "Id", "SubClassZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers.OrderBy(x => x.WordNumberEn), "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers.OrderBy(x => x.WordNumberFr), "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers.OrderBy(x => x.WordNumberZh), "Id", "WordNumberZh");

            return View();
        }

        // POST: BackOffice/DictionaryTocharians/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word,Sanskrit,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] DictionaryTocharian dictionaryTocharian, int[] NumberId)
        {
            if (ModelState.IsValid)
            {
                if (NumberId.Count() > 0)
                {
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                else
                {
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }
                db.DictionaryTocharians.Add(dictionaryTocharian);
                db.SaveChanges();
                if (dictionaryTocharian.WordClassId == 10)
                {
                    AddVerb(dictionaryTocharian.Id);
                    return RedirectToAction("Details", "Verbs", new { id = ViewBag.Id });

                }
                if (dictionaryTocharian.WordClassId == 2 || dictionaryTocharian.WordClassId == 4)
                {
                    AddNounAdjective(dictionaryTocharian.Id);
                    return RedirectToAction("Details", "NounAdjectives", new { id = ViewBag.Id });

                }
                if (dictionaryTocharian.WordClassId == 3)
                {
                    AddPronoun(dictionaryTocharian.Id);
                    return RedirectToAction("Details", "Pronouns", new { id = ViewBag.Id });

                }
                if (dictionaryTocharian.WordClassId != 10 && dictionaryTocharian.WordClassId != 2 && dictionaryTocharian.WordClassId != 3 && dictionaryTocharian.WordClassId != 4)
                {
                    AddOtherWord(dictionaryTocharian.Id);
                    return RedirectToAction("Details", "OtherWords", new { id = ViewBag.Id });

                }
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", dictionaryTocharian.TochLanguageId);

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.OrderBy(x => x.ClassEn), "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.OrderBy(x => x.ClassFr), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.OrderBy(x => x.ClassZh), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassEn), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassFr), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassZh), "Id", "SubClassZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers.OrderBy(x => x.WordNumberEn), "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers.OrderBy(x => x.WordNumberFr), "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers.OrderBy(x => x.WordNumberZh), "Id", "WordNumberZh");

            return View();
        }

        // GET: BackOffice/DictionaryTocharians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", dictionaryTocharian.TochLanguageId);

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.OrderBy(x => x.ClassEn), "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.OrderBy(x => x.ClassFr), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.OrderBy(x => x.ClassZh), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassEn), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassFr), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassZh), "Id", "SubClassZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers.OrderBy(x => x.WordNumberEn), "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers.OrderBy(x => x.WordNumberFr), "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers.OrderBy(x => x.WordNumberZh), "Id", "WordNumberZh");


            return View(dictionaryTocharian);
        }

        // POST: BackOffice/DictionaryTocharians/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word,Sanskrit,English,Francaise,German,Latin,Chinese,WordClassId,WordSubClassId,TochLanguageId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] DictionaryTocharian dictionaryTocharian, int[] NumberId)
        {
            db.Entry(dictionaryTocharian).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                if (NumberId != null)
                    dictionaryTocharian.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();

                db.SaveChanges();
                if (dictionaryTocharian.WordClassId == 10)
                {
                    IEnumerable<Verb> verbs = db.Verbs.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                    if (verbs.Count() == 0)
                    {
                        AddVerb(dictionaryTocharian.Id);
                    }
                    else
                    {
                        ViewBag.Id = verbs.First().Id;
                    }
                    return RedirectToAction("Details", "Verbs", new { id = ViewBag.Id });
                }
                if (dictionaryTocharian.WordClassId == 2 || dictionaryTocharian.WordClassId == 4)
                {
                    IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                    if (nounAdjectives.Count() == 0)
                    {
                        AddNounAdjective(dictionaryTocharian.Id);
                    }
                    else
                    {
                        ViewBag.Id = nounAdjectives.First().Id;
                    }
                    return RedirectToAction("Details", "NounAdjectives", new { id = ViewBag.Id });
                }
                if (dictionaryTocharian.WordClassId == 3)
                {
                    IEnumerable<Pronoun> pronouns = db.Pronouns.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                    if (pronouns.Count() == 0)
                    {
                        AddPronoun(dictionaryTocharian.Id);
                    }
                    else
                    {
                        ViewBag.Id = pronouns.First().Id;
                    }
                    return RedirectToAction("Details", "Pronouns", new { id = ViewBag.Id });
                }
                if (dictionaryTocharian.WordClassId != 10 && dictionaryTocharian.WordClassId != 2 && dictionaryTocharian.WordClassId == 3 && dictionaryTocharian.WordClassId == 4)
                {
                    IEnumerable<OtherWord> otherWords = db.OtherWords.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                    if (otherWords.Count() == 0)
                    {
                        AddOtherWord(dictionaryTocharian.Id);
                    }
                    else
                    {
                        ViewBag.Id = otherWords.First().Id;
                    }
                    return RedirectToAction("Details", "OtherWords", new { id = ViewBag.Id });

                }
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language", dictionaryTocharian.TochLanguageId);

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.OrderBy(x => x.ClassEn), "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.OrderBy(x => x.ClassFr), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.OrderBy(x => x.ClassZh), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassEn), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassFr), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.OrderBy(x => x.SubClassZh), "Id", "SubClassZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers.OrderBy(x => x.WordNumberEn), "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers.OrderBy(x => x.WordNumberFr), "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers.OrderBy(x => x.WordNumberZh), "Id", "WordNumberZh");


            return View(dictionaryTocharian);
        }
        // POST: BackOffice/Verbs/AddVerb/5
        public ActionResult AddVerb(int? id)
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
            IEnumerable<Verb> verbs = db.Verbs.Where(x => x.DictionaryId == dictionaryTocharian.Id);
            Verb verb = new Verb();
            if (verbs.Count() == 0)
            {

                verb.DictionaryId = dictionaryTocharian.Id;
                verb.MoodId = 1;
                verb.TenseAndAspectId = 1;
                verb.ValencyId = 1;
                verb.VoiceId = 1;
            }
            else
            {
                Display("Verb existe");
            }
            db.Verbs.Add(verb);
            db.SaveChanges();
            ViewBag.Id = verb.Id;
            return RedirectToAction("Details", "Verbs", new { id = verb.Id });
        }
        // POST: BackOffice/DictionaryTocharians/AddNounAdjective/5
        public ActionResult AddNounAdjective(int? id)
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
            IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Where(x => x.DictionaryId == dictionaryTocharian.Id);
            NounAdjective nounAdjective = new NounAdjective();
            if (nounAdjectives.Count() == 0)
            {
                nounAdjective.DictionaryId = dictionaryTocharian.Id;
            }
            else
            {
                Display("NounAdjective existe");
            }
            db.NounAdjectives.Add(nounAdjective);
            db.SaveChanges();
            ViewBag.Id = nounAdjective.Id;
            return RedirectToAction("Details", "NounAdjectives", new { id = nounAdjective.Id });
        }
        // POST: BackOffice/DictionaryTocharians/Pronoun/5
        public ActionResult AddPronoun(int? id)
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
            IEnumerable<Pronoun> pronouns = db.Pronouns.Where(x => x.DictionaryId == dictionaryTocharian.Id);
            Pronoun pronoun = new Pronoun();
            if (pronouns.Count() == 0)
            {
                pronoun.DictionaryId = dictionaryTocharian.Id;
            }
            else
            {
                Display("Pronoun existe");
            }
            db.Pronouns.Add(pronoun);
            db.SaveChanges();
            ViewBag.Id = pronoun.Id;
            return RedirectToAction("Details", "Pronouns", new { id = pronoun.Id });
        }
        // POST: BackOffice/DictionaryTocharians/AddOtherWord/5
        public ActionResult AddOtherWord(int? id)
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
            IEnumerable<OtherWord> otherWords = db.OtherWords.Where(x => x.DictionaryId == dictionaryTocharian.Id);
            OtherWord otherWord = new OtherWord();
            if (otherWords.Count() == 0)
            {
                otherWord.DictionaryId = dictionaryTocharian.Id;
            }
            else
            {
                Display("OtherWord existe");
            }
            db.OtherWords.Add(otherWord);
            db.SaveChanges();
            ViewBag.Id = otherWord.Id;
            return RedirectToAction("Details", "OtherWords", new { id = otherWord.Id });
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
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (dictionaryTocharian.WordClassId == 10)
            {
                IEnumerable<Verb> verbs = db.Verbs.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                if (verbs.Count() != 0)
                {
                    foreach (var item in verbs)
                    {
                        db.Verbs.Remove(item);
                    }
                }
            }
            if (dictionaryTocharian.WordClassId == 2 || dictionaryTocharian.WordClassId == 4)
            {
                IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                if (nounAdjectives.Count() != 0)
                {
                    foreach (var item in nounAdjectives)
                    {
                        db.NounAdjectives.Remove(item);
                    }

                }
            }
            if (dictionaryTocharian.WordClassId == 3)
            {
                IEnumerable<Pronoun> pronouns = db.Pronouns.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                if (pronouns.Count() != 0)
                {
                    foreach (var item in pronouns)
                    {
                        db.Pronouns.Remove(item);
                    }
                }
            }
            if (dictionaryTocharian.WordClassId != 10 && dictionaryTocharian.WordClassId != 2 && dictionaryTocharian.WordClassId != 3 && dictionaryTocharian.WordClassId != 4)
            {
                IEnumerable<OtherWord> otherWords = db.OtherWords.Where(x => x.DictionaryId == dictionaryTocharian.Id);
                if (otherWords.Count() != 0)
                {
                    foreach (var item in otherWords)
                    {
                        db.OtherWords.Remove(item);
                    }
                }
            }
            db.DictionaryTocharians.Remove(dictionaryTocharian);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Parallel(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }

        public ActionResult TocharianA(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Where(x => x.TochLanguage.Language.Contains("TA")).Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.EquivalentTA).ToPagedList(page, pageSize));
        }
        public ActionResult TocharianB(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Where(x => x.TochLanguage.Language.Contains("TB")).Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.EquivalentTB).ToPagedList(page, pageSize));
        }
        public ActionResult SearchParallel(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("WordClass").Include("WordSubClass").Include("TochLanguage").Where(x => x.Word.Contains(search)
                || (x.EquivalentTA != null && x.EquivalentTA.Contains(search))
                || (x.EquivalentTB != null && x.EquivalentTB.Contains(search))
                || (x.EquivalentTB != null && x.TochCommon.Contains(search))
                || (x.EquivalentTB != null && x.TochCorrespondence.Contains(search))
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))); ;

            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;
            return View("SearchParallel", dictionaryTocharians.ToList());
        }
        /*
        public ActionResult AddEquivalentDictionary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include(n => n.DictionaryTocharian.TochLanguage).Include(n => n.DictionaryTocharian.WordClass).Include(n => n.DictionaryTocharian.WordSubClass).Include("Cases").Include("Genders").SingleOrDefault(y => y.Id == id);
            NounAdjective equivalent = new NounAdjective();

            if (nounAdjective.DictionaryTocharian.TochLanguageId == 1 && nounAdjective.DictionaryTocharian.EquivalentTB != null)
            {
                IEnumerable<NounAdjective> equivalentTB = db.NounAdjectives.Include(n => n.DictionaryTocharian.TochLanguage).Include(n => n.DictionaryTocharian.WordClass).Include(n => n.DictionaryTocharian.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Where(y => y.DictionaryTocharian.Word == nounAdjective.DictionaryTocharian.EquivalentTB);
                if (equivalentTB.Count() == 0)
                {
                     equivalent.TochWord = nounAdjective.EquivalentTB;
                     equivalent.EquivalentTA = nounAdjective.TochWord;
                     equivalent.EquivalentTB = nounAdjective.EquivalentTB;
                     equivalent.TochLanguageId = 2;
                     equivalent.Sanskrit = nounAdjective.Sanskrit;
                     equivalent.English = nounAdjective.English;
                     equivalent.Francaise = nounAdjective.Francaise;
                     equivalent.German = nounAdjective.German;
                     equivalent.Latin = nounAdjective.Latin;
                     equivalent.Chinese = nounAdjective.Chinese;
                     equivalent.Visible = true;
                     equivalent.TochCommon = nounAdjective.TochCommon;
                     equivalent.TochCorrespondence = nounAdjective.TochCorrespondence;
                     equivalent.EquivalentInOther = nounAdjective.EquivalentInOther;
                     equivalent.WordClassId = nounAdjective.WordClassId;
                     equivalent.WordSubClassId = nounAdjective.WordSubClassId;
                     db.NounAdjectives.Add(equivalent);

                 }
                 else
                 {
                     Display("Mots existé");
                 }
             }
             if (nounAdjective.TochLanguageId == 2 && nounAdjective.EquivalentTA != null)
             {
                 IEnumerable<NounAdjective> equivalentTA = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Where(y => y.TochWord == nounAdjective.EquivalentTA);
                 if (equivalentTA.Count() == 0)
                 {
                     equivalent.TochWord = nounAdjective.EquivalentTA;
                     equivalent.EquivalentTB = nounAdjective.TochWord;
                     equivalent.EquivalentTA = nounAdjective.EquivalentTA;
                     equivalent.TochLanguageId = 1;
                     equivalent.Sanskrit = nounAdjective.Sanskrit;
                     equivalent.English = nounAdjective.English;
                     equivalent.Francaise = nounAdjective.Francaise;
                     equivalent.German = nounAdjective.German;
                     equivalent.Latin = nounAdjective.Latin;
                     equivalent.Chinese = nounAdjective.Chinese;
                     equivalent.Visible = true;
                     equivalent.TochCommon = nounAdjective.TochCommon;
                     equivalent.TochCorrespondence = nounAdjective.TochCorrespondence;
                     equivalent.EquivalentInOther = nounAdjective.EquivalentInOther;
                     equivalent.WordClassId = nounAdjective.WordClassId;
                     equivalent.WordSubClassId = nounAdjective.WordSubClassId;
                     db.NounAdjectives.Add(equivalent);
                 }
                 else
                 {
                     Display("Mots existé");
                 }

                 }
                db.SaveChanges();
            return RedirectToAction("index");
             }
               return View();*/
    }
}
