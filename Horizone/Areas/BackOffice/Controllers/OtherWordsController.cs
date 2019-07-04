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
    public class OtherWordsController : BaseController
    {

        // GET: BackOffice/OtherWords
        public ActionResult Index(int page = 1, int pageSize = 50)
        {
            var otherWords = db.OtherWords.Include(o => o.TochLanguage).Include(o => o.WordClass).Include(o => o.WordSubClass).Include("Numbers");
            return View(otherWords.OrderBy(x => x.TochWord).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/OtherWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherWord otherWord = db.OtherWords.Include(o => o.TochLanguage).Include(o => o.WordClass).Include(o => o.WordSubClass).Include("Numbers").SingleOrDefault(y => y.Id == id);
            if (otherWord.Numbers.Count() == 0)
                otherWord.Numbers = db.Numbers.Where(x => x.WordNumberEn == "No Number").ToList();

            if (otherWord == null)
            {
                return HttpNotFound();
            }
            return View(otherWord);
        }

        // GET: BackOffice/OtherWords/Create
        public ActionResult Create()
        {
            ViewBag.TochLanguageId = new SelectList(db.TochLanguages, "Id", "Language");

            ViewBag.WordClassEnId = new SelectList(db.WordClasses, "Id", "ClassEn");
            ViewBag.WordClassFrId = new SelectList(db.WordClasses, "Id", "ClassFr");
            ViewBag.WordClassZhId = new SelectList(db.WordClasses, "Id", "ClassZh");

            ViewBag.WordSubClassEnId = new SelectList(db.WordSubClasses, "Id", "SubClassEn");
            ViewBag.WordSubClassFrId = new SelectList(db.WordSubClasses, "Id", "SubClassFr");
            ViewBag.WordSubClassZhId = new SelectList(db.WordSubClasses, "Id", "SubClassZh");

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");
            return View();
        }

        // POST: BackOffice/OtherWords/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] OtherWord otherWord, int[] NumberId)
        {
            if (ModelState.IsValid)
            {
              
                if (NumberId.Count() > 0)
                {
                    otherWord.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();
                }
                else
                {
                    otherWord.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                }
               
                if (otherWord.TochLanguageId == 1)
                {
                    otherWord.EquivalentTA = otherWord.TochWord;
                }
                if (otherWord.TochLanguageId == 2)
                {
                    otherWord.EquivalentTB = otherWord.TochWord;
                }
                db.OtherWords.Add(otherWord);
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

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh"); return View(otherWord);
        }

        // GET: BackOffice/OtherWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherWord otherWord = db.OtherWords.Include(t => t.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (otherWord == null)
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

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh"); return View(otherWord);
        }

        // POST: BackOffice/OtherWords/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TochWord,English,Francaise,German,Latin,Chinese,TochLanguageId,WordClassId,WordSubClassId,EquivalentTA,EquivalentTB,TochCorrespondence,EquivalentInOther,DerivedFrom,RelatedLexemes,RootCharacter,InternalRootVowel,Stem,StemClass,Visible")] OtherWord otherWord, int[] NumberId)
        {
            db.Entry(otherWord).State = EntityState.Modified;
            db.OtherWords.Include(t => t.TochLanguage).Include(p => p.WordClass).Include(p => p.WordSubClass).Include("Numbers").SingleOrDefault(x => x.Id == otherWord.Id);

            if (ModelState.IsValid)
            {
                if (otherWord.TochLanguageId == 1 || otherWord.TochLanguageId == 3)
                {
                    otherWord.EquivalentTA = otherWord.TochWord;
                }
                if (otherWord.TochLanguageId == 2 || otherWord.TochLanguageId == 4)
                {
                    otherWord.EquivalentTB = otherWord.TochWord;
                }

                if (NumberId != null)
                    otherWord.Numbers = db.Numbers.Where(x => NumberId.Contains(x.Id)).ToList();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                db.Entry(otherWord).State = EntityState.Modified;
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

            ViewBag.NumbersEn = new SelectList(db.Numbers, "Id", "WordNumberEn");
            ViewBag.NumbersFr = new SelectList(db.Numbers, "Id", "WordNumberFr");
            ViewBag.NumbersZh = new SelectList(db.Numbers, "Id", "WordNumberZh");

            return View(otherWord);
        }

        // GET: BackOffice/OtherWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherWord otherWord = db.OtherWords.Include("Numbers").SingleOrDefault(x => x.Id == id);
            if (otherWord == null)
            {
                return HttpNotFound();
            }
            return View(otherWord);
        }

        // POST: BackOffice/OtherWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherWord otherWord = db.OtherWords.Include("Numbers").SingleOrDefault(x => x.Id == id);
            db.OtherWords.Remove(otherWord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
