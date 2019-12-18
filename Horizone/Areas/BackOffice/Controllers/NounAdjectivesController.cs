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
    public class NounAdjectivesController : BaseController
    {
        // GET: BackOffice/NounAdjectives
        public ActionResult Index(int page = 1, int pageSize = 200)
        {
            var nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/NounAdjectives
        public ActionResult IndexNoun(int page = 1, int pageSize = 200)
        {
            var nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/NounAdjectives
        public ActionResult IndexAdjective(int page = 1, int pageSize = 200)
        {
            var nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }

        // GET: BackOffice/NounAdjectives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").SingleOrDefault(y => y.Id == id);
            if (nounAdjective.Cases.Count() == 0)
                nounAdjective.Cases = db.Cases.Where(x => x.NameCaseEn == "No Case").ToList();
            if (nounAdjective.Genders.Count() == 0)
                nounAdjective.Genders = db.Genders.Where(x => x.NameGenderEn == "No Gender").ToList();
            if (nounAdjective.Numbers.Count() == 0)
                nounAdjective.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();

            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            return View(nounAdjective);
        }

        // GET: BackOffice/NounAdjectives/Create
        public ActionResult Create()
        {

            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassZh");


            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");
            return View();
        }

        // POST: BackOffice/NounAdjectives/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] NounAdjective nounAdjective, int[] CaseId, int[] GenderId, int[] NumberId)
        {
            if (ModelState.IsValid)
            {
                if (CaseId.Count() > 0)
                {
                    nounAdjective.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                }
                else { nounAdjective.Cases = db.Cases.Where(x => x.Id == 1).ToList(); }
                if (GenderId.Count() > 0)
                {
                    nounAdjective.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                }
                else
                {
                    nounAdjective.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                }
                if (NumberId.Count() > 0)
                {
                    nounAdjective.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                else
                {
                    nounAdjective.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }

                if (nounAdjective.TochLanguageId == 1 || nounAdjective.TochLanguageId == 3 || nounAdjective.TochLanguageId == 6)
                {
                    nounAdjective.EquivalentTA = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 2 || nounAdjective.TochLanguageId == 4 || nounAdjective.TochLanguageId == 6 || nounAdjective.TochLanguageId == 8)
                {
                    nounAdjective.EquivalentTB = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 7)
                {
                    nounAdjective.Sanskrit = nounAdjective.TochWord;
                }


                db.NounAdjectives.Add(nounAdjective);

                db.SaveChanges();
                if (nounAdjective.TochLanguageId == 1 && nounAdjective.EquivalentTB != null)
                {
                    AddEquivalentDictionary(nounAdjective.Id);
                }
                if (nounAdjective.TochLanguageId == 2 && nounAdjective.EquivalentTA != null)
                {
                    AddEquivalentDictionary(nounAdjective.Id);
                }
                AddDictionary(nounAdjective.Id);

                return RedirectToAction("Index");
            }

            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassZh");

            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            return View(nounAdjective);
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
        //Add a new word to dictionary
        public ActionResult AddDictionary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders").SingleOrDefault(y => y.Id == id);
            var dictionaryTocharian = new DictionaryTocharian();
            if (nounAdjective == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (nounAdjective.TochWord != null)
            {
                IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Where(x => x.Word == nounAdjective.TochWord);

                if (dictionaryTocharians.Count() == 0)
                {
                    dictionaryTocharian.Word = nounAdjective.TochWord;
                    dictionaryTocharian.Sanskrit = nounAdjective.Sanskrit;
                    dictionaryTocharian.English = nounAdjective.English;
                    dictionaryTocharian.Francaise = nounAdjective.Francaise;
                    dictionaryTocharian.German = nounAdjective.German;
                    dictionaryTocharian.Latin = nounAdjective.Latin;
                    dictionaryTocharian.Chinese = nounAdjective.Chinese;
                    dictionaryTocharian.Visible = true;
                    dictionaryTocharian.EquivalentTA = nounAdjective.EquivalentTA;
                    dictionaryTocharian.EquivalentTB = nounAdjective.EquivalentTB;
                    dictionaryTocharian.TochCommon = nounAdjective.TochCommon;
                    dictionaryTocharian.TochCorrespondence = nounAdjective.TochCorrespondence;
                    dictionaryTocharian.EquivalentInOther = nounAdjective.EquivalentInOther;
                    dictionaryTocharian.TochLanguageId = nounAdjective.TochLanguageId;
                    dictionaryTocharian.WordClassId = nounAdjective.WordClassId;
                    dictionaryTocharian.WordSubClassId = nounAdjective.WordSubClassId;
                    dictionaryTocharian.IdClassSource = nounAdjective.Id;
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

        // GET: BackOffice/NounAdjectives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Genders").Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassZh");



            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            return View(nounAdjective);
        }

        // POST: BackOffice/NounAdjectives/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCommon,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] NounAdjective nounAdjective, int[] CaseId, int[] GenderId, int[] NumberId)
        {
            db.Entry(nounAdjective).State = EntityState.Modified;
            db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Genders").Include("Numbers").SingleOrDefault(x => x.Id == nounAdjective.Id);

            if (ModelState.IsValid)
            {
                if (nounAdjective.TochLanguageId == 1 || nounAdjective.TochLanguageId == 3 || nounAdjective.TochLanguageId == 6)
                {
                    nounAdjective.EquivalentTA = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 2 || nounAdjective.TochLanguageId == 4 || nounAdjective.TochLanguageId == 6 || nounAdjective.TochLanguageId == 8)
                {
                    nounAdjective.EquivalentTB = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 7)
                {
                    nounAdjective.Sanskrit = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 1 && nounAdjective.EquivalentTB != null)
                {
                    AddEquivalentDictionary(nounAdjective.Id);
                }
                if (nounAdjective.TochLanguageId == 2 && nounAdjective.EquivalentTA != null)
                {
                    AddEquivalentDictionary(nounAdjective.Id);
                }
                if (CaseId != null)
                    nounAdjective.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    nounAdjective.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId != null)
                    nounAdjective.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                EditDictionary(nounAdjective.Id);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses.Where(x => x.ClassEn == "Noun" || x.ClassEn == "Adjective"), "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses.Where(x => x.WordClass.ClassEn == "Noun" || x.WordClass.ClassEn == "Adjective"), "Id", "SubClassZh");



            ViewBag.CasesEn = new SelectList(db.Cases, "Id", "NameCaseEn");
            ViewBag.CasesFr = new SelectList(db.Cases, "Id", "NameCaseFr");
            ViewBag.CasesZh = new SelectList(db.Cases, "Id", "NameCaseZh");

            ViewBag.GendersFr = new SelectList(db.Genders, "Id", "NameGenderFr");
            ViewBag.GendersEn = new SelectList(db.Genders, "Id", "NameGenderEn");
            ViewBag.GendersZh = new SelectList(db.Genders, "Id", "NameGenderZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            return View(nounAdjective);
        }
        //Update a word in dictionary
        public ActionResult EditDictionary(int? id)
        {
            NounAdjective nounAdjective = db.NounAdjectives.Include("WordClass").Include("WordSubClass").Include("TochLanguage").SingleOrDefault(x => x.Id == id);
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("TochLanguage").Include("WordClass").Include("WordSubClass").Where(x => x.WordClassId == 2 || x.WordClassId == 4);
            dictionaryTocharians = dictionaryTocharians.Where(x => x.Word == nounAdjective.TochWord && x.TochLanguageId == nounAdjective.TochLanguageId );
            DictionaryTocharian dictionaryTocharian = dictionaryTocharians.SingleOrDefault(x => x.IdClassSource == id);
            
            if (dictionaryTocharian != null)
            {
                dictionaryTocharian.Sanskrit = nounAdjective.Sanskrit;
                dictionaryTocharian.English = nounAdjective.English;
                dictionaryTocharian.Francaise = nounAdjective.Francaise;
                dictionaryTocharian.German = nounAdjective.German;
                dictionaryTocharian.Latin = nounAdjective.Latin;
                dictionaryTocharian.Chinese = nounAdjective.Chinese;
                dictionaryTocharian.Visible = true;
                dictionaryTocharian.EquivalentTA = nounAdjective.EquivalentTA;
                dictionaryTocharian.EquivalentTB = nounAdjective.EquivalentTB;
                dictionaryTocharian.TochCommon = nounAdjective.TochCommon;
                dictionaryTocharian.TochCorrespondence = nounAdjective.TochCorrespondence;
                dictionaryTocharian.EquivalentInOther = nounAdjective.EquivalentInOther;
                dictionaryTocharian.TochLanguageId = nounAdjective.TochLanguageId;
                dictionaryTocharian.WordClassId = nounAdjective.WordClassId;
                dictionaryTocharian.WordSubClassId = nounAdjective.WordSubClassId;
                dictionaryTocharian.IdClassSource = nounAdjective.Id;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        // GET: BackOffice/NounAdjectives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NounAdjective nounAdjective = db.NounAdjectives.Include("Cases").Include("Genders").Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (nounAdjective == null)
            {
                return HttpNotFound();
            }
            return View(nounAdjective);
        }

        // POST: BackOffice/NounAdjectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NounAdjective nounAdjective = db.NounAdjectives.Include("Cases").Include("Genders").Include("Numbers").SingleOrDefault(x => x.Id == id);
            db.NounAdjectives.Remove(nounAdjective);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchNounAdjective(string search)
        {
            IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Include("WordClass").Include("WordSubClass").Include("TochLanguage").Include("Genders").Include("Cases").Where(x => x.TochWord.Contains(search)
                    || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                    || (x.English != null && x.English.Contains(search))
                    || (x.Francaise != null && x.Francaise.Contains(search))
                    || (x.German != null && x.German.Contains(search))
                    || (x.Latin != null && x.Latin.Contains(search))
                    || (x.Chinese != null && x.Chinese.Contains(search))
                    ); ;

            if (nounAdjectives.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;
            return View("SearchNounAdjective", nounAdjectives.ToList());
        }
    }
}
