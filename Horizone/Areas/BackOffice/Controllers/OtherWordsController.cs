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
        public ActionResult Index(int page = 1, int pageSize = 200)
        {
            var otherWords = db.OtherWords.Include(o => o.DictionaryTocharian)
                .Include(d => d.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.WordClass)
                .Include(d => d.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers);              
            return View(otherWords.OrderBy(x => x.DictionaryTocharian.Word).ToPagedList(page, pageSize));
        }
        public ActionResult Adverb()
        {
            var otherWords = db.OtherWords.Include(d => d.DictionaryTocharian).Include(d => d.DictionaryTocharian.WordClass).Include(d => d.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.Numbers)
                .Where(x => x.DictionaryTocharian.WordClass.ClassEn == "Adverb" || x.DictionaryTocharian.WordSubClass.SubClassEn == "Adverb");
            return View(otherWords.OrderBy(x => x.DictionaryTocharian.Word).ToList());
        }
        // GET: BackOffice/OtherWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherWord otherWord = db.OtherWords
                .Include(x=>x.DictionaryTocharian)
                .Include(d => d.DictionaryTocharian.TochLanguage)
                .Include(d => d.DictionaryTocharian.WordClass)
                .Include(d => d.DictionaryTocharian.WordSubClass)
                .Include(d => d.DictionaryTocharian.Numbers)
                .SingleOrDefault(x=>x.Id==id);

            if (otherWord == null)
            {
                return HttpNotFound();
            }
            return View(otherWord);
        }

        // GET: BackOffice/OtherWords/Create
        public ActionResult Create()
        {
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId != 10 && x.WordClassId != 2 && x.WordClassId != 3 && x.WordClassId != 4).OrderBy(x => x.Word), "Id", "Word");

            return View();
        }

        // POST: BackOffice/OtherWords/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DictionaryId")] OtherWord otherWord)
        {
            if (ModelState.IsValid)
            {
               
                db.OtherWords.Add(otherWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DictionaryId = new SelectList(db.DictionaryTocharians.Where(x => x.WordClassId != 10 && x.WordClassId != 2 && x.WordClassId != 3 && x.WordClassId != 4).OrderBy(x => x.Word), "Id", "Word", otherWord.DictionaryId);
            return View(otherWord);
        }
    
        // GET: BackOffice/OtherWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherWord otherWord = db.OtherWords
                .Include(x => x.DictionaryTocharian).SingleOrDefault(x=>x.Id==id);
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
            OtherWord otherWord = db.OtherWords
                .Include(x => x.DictionaryTocharian).SingleOrDefault(x => x.Id == id);
            db.OtherWords.Remove(otherWord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
