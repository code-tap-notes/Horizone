using Horizone.Controllers;
using Horizone.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class ReverseDictionariesController : BaseController
    {

        // GET: BackOffice/ReverseDictionaries
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            return View(db.ReverseDictionaries.OrderBy(x => x.Word).ToPagedList(page, pageSize));
        }

        // GET: BackOffice/ReverseDictionaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary == null)
            {
                return HttpNotFound();
            }
            return View(reverseDictionary);
        }

        //Update a word in dictionary
        public ActionResult EditReverse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary != null)
            {

                string reverse = String.Empty;
                char[] cArray = reverseDictionary.ReverseWord.ToCharArray();
                for (int i = cArray.Length - 1; i > -1; i--)
                {
                    switch (cArray[i])
                    {
                        case ')':
                            reverse += '(';
                            break;
                        case '(':
                            reverse += ')';
                            break;
                        case 'ā':
                           
                            reverse += 'ā';
                            reverse += 'y';
                            reverse += 'y';
                            reverse += 'y';
                            break;
                        case 'ä':
                            
                            reverse += 'ä';
                            reverse += 'z';
                            reverse += 'z';
                            reverse += 'z';
                            break;
                        default:
                            reverse += cArray[i];
                            break;
                    }
                }
                reverseDictionary.Word = reverse;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: BackOffice/ReverseDictionaries/Create
        public ActionResult SortReverse()
        {
            IEnumerable<ReverseDictionary> reverseDictionaries = db.ReverseDictionaries;
            string reverse = String.Empty;

            foreach (var item in reverseDictionaries)
            {
                EditReverse(item.Id);
            }

            db.SaveChanges();
            return View(reverseDictionaries);

        }

        // GET: BackOffice/ReverseDictionaries/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: BackOffice/ReverseDictionaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word,SymbolPrefix,ReverseWord,SymbolSufix")] ReverseDictionary reverseDictionary)
        {
            char[] cArray = reverseDictionary.ReverseWord.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                if (cArray[i] == ')')
                {
                    reverse += '(';
                }
                else if (cArray[i] == '(')
                {
                    reverse += ')';
                }
                else
                    reverse += cArray[i];
            }
            reverseDictionary.Word = reverse;

            if (ModelState.IsValid)
            {
                db.ReverseDictionaries.Add(reverseDictionary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reverseDictionary);
        }

        // GET: BackOffice/ReverseDictionaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary == null)
            {
                return HttpNotFound();
            }
            return View(reverseDictionary);
        }

        // POST: BackOffice/ReverseDictionaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word,SymbolPrefix,ReverseWord,SymbolSufix")] ReverseDictionary reverseDictionary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reverseDictionary).State = EntityState.Modified;
                char[] cArray = reverseDictionary.ReverseWord.ToCharArray();
                string reverse = String.Empty;
                for (int i = cArray.Length - 1; i > -1; i--)
                {
                    reverse += cArray[i];
                }
                reverseDictionary.Word = reverse;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reverseDictionary);
        }

        // GET: BackOffice/ReverseDictionaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            if (reverseDictionary == null)
            {
                return HttpNotFound();
            }
            return View(reverseDictionary);
        }

        // POST: BackOffice/ReverseDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReverseDictionary reverseDictionary = db.ReverseDictionaries.Find(id);
            db.ReverseDictionaries.Remove(reverseDictionary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SearchReverse(string search)
        {
            IEnumerable<ReverseDictionary> reverseDictionarys = db.ReverseDictionaries;

            if (!string.IsNullOrWhiteSpace(search))
            {
                reverseDictionarys = reverseDictionarys.Where(x => x.ReverseWord.Contains(search));
            }
            if (reverseDictionarys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchReverse", reverseDictionarys.ToList());
        }

        public ActionResult SearchEnd(string search)
        {
            IEnumerable<ReverseDictionary> reverseDictionarys = db.ReverseDictionaries;


            if (!string.IsNullOrWhiteSpace(search))
            {
                int i = search.Length;
                reverseDictionarys = reverseDictionarys.Where(x => x.ReverseWord.Length >= i && x.ReverseWord.Substring(x.ReverseWord.Length - i, i) == search);
            }
            if (reverseDictionarys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchReverse", reverseDictionarys.ToList());
        }
    }
}
