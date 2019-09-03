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
    public class NounAdjectivesController : BaseController
    {
        // GET: BackOffice/NounAdjectives
        public ActionResult Index(int page = 1, int pageSize = 50)
        {
            var nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/NounAdjectives
        public ActionResult IndexNoun(int page = 1, int pageSize = 50)
        {
            var nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");           
            return View(nounAdjectives.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/NounAdjectives
        public ActionResult IndexAdjective(int page = 1, int pageSize = 50)
        {
            var nounAdjectives = db.NounAdjectives.Include(n => n.TochLanguage).Include(n => n.WordClass).Include(n => n.WordSubClass).Include("Cases").Include("Numbers").Include("Genders");
            return View(nounAdjectives.OrderBy(x=>x.TochWord).ToPagedList(page, pageSize));
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
              
                if (nounAdjective.TochLanguageId == 1)
                {
                    nounAdjective.EquivalentTA = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 2)
                {
                    nounAdjective.EquivalentTB = nounAdjective.TochWord;
                }
                db.NounAdjectives.Add(nounAdjective);
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

            return View(nounAdjective);
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
                if (nounAdjective.TochLanguageId == 1 || nounAdjective.TochLanguageId == 3)
                {
                    nounAdjective.EquivalentTA = nounAdjective.TochWord;
                }
                if (nounAdjective.TochLanguageId == 2 || nounAdjective.TochLanguageId == 4)
                {
                    nounAdjective.EquivalentTB = nounAdjective.TochWord;
                }


                if (CaseId != null)
                    nounAdjective.Cases = db.Cases.Where(x => CaseId.Contains(x.Id)).ToList();
                if (GenderId != null)
                    nounAdjective.Genders = db.Genders.Where(x => GenderId.Contains(x.Id)).ToList();
                if (NumberId != null)
                    nounAdjective.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();

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

            return View(nounAdjective);
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
       
    }
}
