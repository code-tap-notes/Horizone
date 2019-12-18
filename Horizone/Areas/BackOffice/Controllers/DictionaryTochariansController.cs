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
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }

        // GET: BackOffice/DictionaryTocharians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).SingleOrDefault(y => y.Id == id);

            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            return View(dictionaryTocharian);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).SingleOrDefault(y => y.Id == id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            if (dictionaryTocharian.WordClass.ClassEn == "Verb")
            { return RedirectToAction("Edit", "Verbs",new { id= dictionaryTocharian.IdClassSource}); }
            if (dictionaryTocharian.WordClass.ClassEn == "Noun" || dictionaryTocharian.WordClass.ClassEn == "Adjective")
            { return RedirectToAction("Edit", "NounAdjectives", new { id = dictionaryTocharian.IdClassSource }); }
            if (dictionaryTocharian.WordClass.ClassEn == "Pronoun")
            { return RedirectToAction("Edit", "Pronouns", new { id = dictionaryTocharian.IdClassSource }); }
            if (dictionaryTocharian.WordClass.ClassEn != "Verb" && dictionaryTocharian.WordClass.ClassEn != "Adjective" && dictionaryTocharian.WordClass.ClassEn != "Noun" && dictionaryTocharian.WordClass.ClassEn != "Pronoun")
            { return RedirectToAction("Edit", "OtherWords", new { id = dictionaryTocharian.IdClassSource }); }
            return View();
        }
        public ActionResult AddDictionary(int? id)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToList());
        }
       
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult UpdateDictionary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass).SingleOrDefault(y => y.Id == id);
            if (dictionaryTocharian == null)
            {
                return HttpNotFound();
            }
            if (dictionaryTocharian.WordClass.ClassEn == "Noun" || dictionaryTocharian.WordClass.ClassEn == "Adjective")
            {
                IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Include(n => n.WordClass).Include(n => n.TochLanguage).Where(n => n.TochWord == dictionaryTocharian.Word);
                if (nounAdjectives.Count() == 0)
                {
                           ViewBag.Check = "NominalCategories: Noun-Adjective";
                    AddNounAdjective(id);

                }
                return RedirectToAction("index", "NounAdjectives");
            }
            if (dictionaryTocharian.WordClass.ClassEn == "Verb")
            {
                IEnumerable <Verb> verbs = db.Verbs.Include(n => n.WordClass).Include(n => n.TochLanguage).Where(n => n.TochWord == dictionaryTocharian.Word);
                if (verbs.Count() == 0)
                {
                    ViewBag.Check = "VerbalCategories";
                    AddVerb(id);
                }
                return RedirectToAction("index", "Verbs");
            }
            if (dictionaryTocharian.WordClass.ClassEn == "Pronoun")
            {
                IEnumerable <Pronoun> pronouns = db.Pronouns.Include(n => n.WordClass).Include(n => n.TochLanguage).Where(n => n.TochWord == dictionaryTocharian.Word);
                if (pronouns.Count() == 0)
                {
                    ViewBag.Check="Pronoun";
                    AddPronoun(id);
                }
                return RedirectToAction("index", "Pronouns");
            }
            if (dictionaryTocharian.WordClass.ClassEn != "Noun" && dictionaryTocharian.WordClass.ClassEn != "Adjective" && dictionaryTocharian.WordClass.ClassEn != "Verb" && dictionaryTocharian.WordClass.ClassEn != "Pronoun" && dictionaryTocharian.WordClass.ClassEn != "Proper Name" && dictionaryTocharian.WordClass.ClassEn != "Name Place" && dictionaryTocharian.WordClass.ClassEn != "Phrase")
            {
                IEnumerable <OtherWord> otherWords = db.OtherWords.Include(n => n.WordClass).Include(n => n.TochLanguage).Where(n => n.TochWord == dictionaryTocharian.Word);
                if (otherWords.Count() == 0)
                {
                    ViewBag.Check="OtherWord";
                    AddOtherWord(id);
                }
                return RedirectToAction("index", "OtherWords");
            }
            return View();
        }
        //Add a new word to dictionary
        public ActionResult AddNounAdjective(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.SingleOrDefault(x => x.Id == id);
            var nounAdjective = new NounAdjective();
            if (dictionaryTocharian.Word != null)
            {
                IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Where(y => y.TochWord == dictionaryTocharian.Word);

                if (nounAdjectives.Count() == 0)
                {
                    nounAdjective.TochWord = dictionaryTocharian.Word;
                    nounAdjective.English = dictionaryTocharian.English;
                    nounAdjective.Francaise = dictionaryTocharian.Francaise;
                    nounAdjective.German = dictionaryTocharian.German;
                    nounAdjective.Latin = dictionaryTocharian.Latin;
                    nounAdjective.Chinese = dictionaryTocharian.Chinese;
                    nounAdjective.Sanskrit = dictionaryTocharian.Sanskrit;
                    nounAdjective.EquivalentTA = dictionaryTocharian.EquivalentTA;
                    nounAdjective.EquivalentTB = dictionaryTocharian.EquivalentTB;
                    nounAdjective.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                    nounAdjective.TochLanguageId = dictionaryTocharian.TochLanguageId;
                    nounAdjective.WordClassId = dictionaryTocharian.WordClassId;
                    nounAdjective.WordSubClassId = dictionaryTocharian.WordSubClassId;
                    nounAdjective.Visible = true;
                    db.NounAdjectives.Add(nounAdjective);
                }
                else
                {
                    Display("Mots existé");
                }

                db.SaveChanges();
                ViewBag.NewWordId = nounAdjective.Id;
                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult AddVerb(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.SingleOrDefault(x => x.Id == id);
            var verb = new Verb(); 
            if (dictionaryTocharian.Word != null)
            {
                IEnumerable<Verb> verbs = db.Verbs.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Where(y => y.TochWord == dictionaryTocharian.Word);

                if (verbs.Count() == 0)
                {
                    verb.TochWord = dictionaryTocharian.Word;
                    verb.English = dictionaryTocharian.English;
                    verb.Francaise = dictionaryTocharian.Francaise;
                    verb.German = dictionaryTocharian.German;
                    verb.Chinese = dictionaryTocharian.Chinese;
                    verb.Latin = dictionaryTocharian.Latin;
                    verb.EquivalentTA = dictionaryTocharian.EquivalentTA;
                    verb.EquivalentTB = dictionaryTocharian.EquivalentTB;
                    verb.TochCommon = dictionaryTocharian.TochCommon;
                    verb.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                    verb.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                    verb.MoodId = 1;
                    verb.VoiceId = 1;
                    verb.TenseAndAspectId = 1;
                    verb.ValencyId = 1;
                    verb.Visible = true;
                    verb.TochLanguageId = dictionaryTocharian.TochLanguageId;
                    verb.WordClassId = dictionaryTocharian.WordClassId;
                    verb.WordSubClassId = dictionaryTocharian.WordSubClassId;

                    db.Verbs.Add(verb);
                }
                else
                {
                    Display("Mots existé");
                }

                db.SaveChanges();
                ViewBag.NewWordId = verb.Id;

                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult AddPronoun(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.SingleOrDefault(x => x.Id == id);
            var pronoun = new Pronoun();
            if (dictionaryTocharian.Word != null)
            {
                IEnumerable<Pronoun> pronouns = db.Pronouns.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Where(y => y.TochWord == dictionaryTocharian.Word);

                if (pronouns.Count() == 0)
                {
                    pronoun.TochWord = dictionaryTocharian.Word;
                    pronoun.English = dictionaryTocharian.English;
                    pronoun.Francaise = dictionaryTocharian.Francaise;
                    pronoun.German = dictionaryTocharian.German;
                    pronoun.Latin = dictionaryTocharian.Latin;
                    pronoun.Sanskrit = dictionaryTocharian.Sanskrit;
                    pronoun.Chinese = dictionaryTocharian.Chinese;
                    pronoun.EquivalentTA = dictionaryTocharian.EquivalentTA;
                    pronoun.EquivalentTB = dictionaryTocharian.EquivalentTB;
                    pronoun.TochCommon = dictionaryTocharian.TochCommon;
                    pronoun.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                    pronoun.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                    pronoun.TochLanguageId = dictionaryTocharian.TochLanguageId;
                    pronoun.WordClassId = dictionaryTocharian.WordClassId;
                    pronoun.WordSubClassId = dictionaryTocharian.WordSubClassId;

                    pronoun.Visible = true;

                    db.Pronouns.Add(pronoun);
                }
                else
                {
                    Display("Mots existé");
                }

                db.SaveChanges();
                ViewBag.NewWordId = pronoun.Id;

                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult AddOtherWord(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.SingleOrDefault(x => x.Id == id);
            var otherWord = new OtherWord(); 

            if (dictionaryTocharian.Word != null)
            {
                IEnumerable<OtherWord> otherWords = db.OtherWords.Where(x => x.TochWord == dictionaryTocharian.Word);
                if (otherWords.Count() == 0)
                {                  
                    otherWord.TochWord = dictionaryTocharian.Word;
                    otherWord.English = dictionaryTocharian.English;
                    otherWord.Francaise = dictionaryTocharian.Francaise;
                    otherWord.German = dictionaryTocharian.German;
                    otherWord.Latin = dictionaryTocharian.Latin;
                    otherWord.Chinese = dictionaryTocharian.Chinese;
                    otherWord.Sanskrit = dictionaryTocharian.Sanskrit;
                    otherWord.EquivalentTA = dictionaryTocharian.EquivalentTA;
                    otherWord.EquivalentTB = dictionaryTocharian.EquivalentTB;
                    otherWord.TochCorrespondence = dictionaryTocharian.TochCorrespondence;
                    otherWord.TochCommon = dictionaryTocharian.TochCommon;
                    otherWord.EquivalentInOther = dictionaryTocharian.EquivalentInOther;
                    otherWord.TochLanguageId = dictionaryTocharian.TochLanguageId;
                    otherWord.WordClassId = dictionaryTocharian.WordClassId;
                    otherWord.WordSubClassId = dictionaryTocharian.WordSubClassId;
                    otherWord.Visible = true;
                    db.OtherWords.Add(otherWord);
                }
                else
                {
                    Display("Mots existé");
                }
                db.SaveChanges();
                ViewBag.NewWordId = otherWord.Id;

                return RedirectToAction("index");
            }
            return View();
        }
      
        // GET: BackOffice/DictionaryTocharians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.SingleOrDefault(x => x.Id == id);
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
            DictionaryTocharian dictionaryTocharian = db.DictionaryTocharians.SingleOrDefault(x => x.Id == id);
            //Case cases = dictionaryTocharian.Cases.Where(X=>X.Id ==id);
            db.DictionaryTocharians.Remove(dictionaryTocharian);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Parallel(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.EquivalentTA).ToPagedList(page, pageSize));
        }

        public ActionResult TocharianA(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Where(x => x.TochLanguage.Language.Contains("TA")).Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }
        public ActionResult TocharianB(int page = 1, int pageSize = 200)
        {
            var dictionaryTocharians = db.DictionaryTocharians.Where(x => x.TochLanguage.Language.Contains("TB")).Include(d => d.TochLanguage).Include(d => d.WordClass).Include(d => d.WordSubClass);
            return View(dictionaryTocharians.OrderBy(x => x.Word).ToPagedList(page, pageSize));
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
        public ActionResult AddEquivalentDictionary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").SingleOrDefault(y => y.Id == id);
            NounAdjective equivalent = new NounAdjective();
            if (nounAdjective.TochLanguageId == 1 && nounAdjective.EquivalentTB != null)
            {
                IEnumerable<NounAdjective> equivalentTB = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").Where(y => y.TochWord == nounAdjective.EquivalentTB);
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
    }
}
