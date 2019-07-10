using Horizone.Controllers;
using Horizone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]    
    public class DashBoardsController : BaseController
    {
        // GET: BackOffice/DashBoards
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("ADMINISTRATOR");
            return RedirectToAction("index", "home", new { area = "" });
        }
        //Pour menu About
        public ActionResult About()
        {
            var aboutProjets = db.AboutProjets.Include("Language");
            return View(aboutProjets.ToList());
        }
       
        //Pour Home page
        [ChildActionOnly]
        public ActionResult PresenteProjet()
        {
            var aboutProjets = db.AboutProjets.Include("Language").Include("ImageProjects");
            return PartialView(aboutProjets.ToList());
        }

        [ChildActionOnly]
        public ActionResult SpecialCharacter()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Address()
        {
            var aboutProjets = db.AboutProjets.Include("Language");
            return PartialView(aboutProjets.ToList());
        }
        public ActionResult AboutUs()
        {
            var collaborations = db.Collaborations;
            foreach ( var item in collaborations)
            if (item.Team) collaborations.Add(item);
       
            return View(collaborations.Include("Publications").Include("ImageCollaborations").OrderBy(x => x.Order).ToList());
        }
        // GET: FrontContact/Create
        public ActionResult Contact()
        {
            var aboutProjets = db.AboutProjets.Include("Language");
            return View(aboutProjets.ToList());
        }
        [ChildActionOnly]
        public ActionResult PageActivity()
        {
            var activitys = db.Activitys.Include("Language");
            return PartialView(activitys.OrderByDescending(x => x.DateofActivity).Take(5).ToList());
        }
        [ChildActionOnly]
        public ActionResult PagePublication()
        {
            return PartialView(db.Publications.OrderByDescending(x => x.Id).Take(5).ToList());

        }
        // 3 news have max view
        [ChildActionOnly]
        public ActionResult News()
        {           
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses");
            return PartialView(news.OrderByDescending(x => x.View).Take(3).ToList());            
        }
        // 1 latest news
       
        [ChildActionOnly]
        public ActionResult LatestNewsFr()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses").Where(x => x.LanguageId == 1);
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }
        [ChildActionOnly]
        public ActionResult LatestNewsEn()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses").Where(x => x.LanguageId == 2);
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }
        [ChildActionOnly]
        public ActionResult LatestNewsZh()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses").Where(x => x.LanguageId == 3);
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult Help()
        {
            return View();
        }
        //Press
        [ChildActionOnly]
        public ActionResult InPresse()
        {
          var linkAndPresses = db.LinkAndPresses;
            foreach (var item in db.LinkAndPresses)
            {
              if (item.Press)
                    linkAndPresses.Add(item);
            }
            return PartialView(linkAndPresses.ToList());
        }
        [ChildActionOnly]
        public ActionResult Search(string search)
        {
            IEnumerable<Bibliography> bibliographies = db.Bibliographys;
            if (!string.IsNullOrWhiteSpace(search))
            {
                bibliographies = bibliographies.Where(x => x.Author.Contains(search)
                || x.Journal.Contains(search)
                || x.Title.Contains(search));
            }
            if (bibliographies.Count() == 0)
            {
                Display("Aucun résultat");
            }
            return PartialView("Search", bibliographies.ToList());
        }
        public ActionResult SearchWord(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("TochLanguage").Include("WordClass").Include("WordSubClass").Include("Cases").Include("Numbers").Include("Genders").Include("Persons");

            if (!string.IsNullOrWhiteSpace(search))
            {
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Word.Contains(search));
            }
            if (dictionaryTocharians.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search; 
            return View("SearchWord", dictionaryTocharians.ToList());
        }
        public ActionResult AddDic(string search)
        {
            var dictionaryTocharian = new DictionaryTocharian();
            if (ModelState.IsValid)
            {
                dictionaryTocharian.Cases = db.Cases.Where(x => x.Id == 1).ToList();
                dictionaryTocharian.Genders = db.Genders.Where(x => x.Id == 1).ToList();
                dictionaryTocharian.Numbers = db.Numbers.Where(x => x.Id == 1).ToList();
                dictionaryTocharian.Persons = db.Persons.Where(x => x.Id == 1).ToList();
                dictionaryTocharian.Word = search;
                dictionaryTocharian.MoodId = 1;
                dictionaryTocharian.TochLanguageId = 1;
                dictionaryTocharian.TenseAndAspectId = 1;
                dictionaryTocharian.ValencyId = 1;
                dictionaryTocharian.WordClassId = 1;
                dictionaryTocharian.WordSubClassId = 1;
                dictionaryTocharian.VoiceId = 1;
                db.DictionaryTocharians.Add(dictionaryTocharian);
                db.SaveChanges();
                return RedirectToAction("Edit", "DictionaryTocharians", new {id=dictionaryTocharian.Id });
            }
            ViewBag.Newword = search;
            return View();
        }
       
    }
}