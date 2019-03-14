using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Horizone.Models;
using PagedList;
using Horizone.Common;
using System.IO;

namespace Horizone.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {                       
            var aboutProjets = db.AboutProjets.Include(a => a.Language);
            return View(aboutProjets.ToList());
        }

        [ChildActionOnly]
        public ActionResult Address()
        {
            var aboutProjets = db.AboutProjets.Include(a => a.Language);
            return PartialView(aboutProjets.ToList());
        }

        [ChildActionOnly]
        public ActionResult Presente()
        {
            var currentCulture = Session[CommonConstants.CurrentCulture];
            var symbolLanguage = currentCulture.ToString();
            var aboutProjets = db.AboutProjets;
            foreach (var item in db.AboutProjets.Include("Language"))
            {
                if (item.Language.Symbol == symbolLanguage)
                    aboutProjets.Add(item);
            }            
           return PartialView(aboutProjets.Include(a => a.Language).ToList());
        }

        public ActionResult AboutUs()
        {
            var collaborations = db.Collaborations;
            foreach (var item in collaborations)
            if (item.Team) collaborations.Add(item);
            return View(collaborations.Include("Publications").Include("ImageCollaborations").ToList());
        }

        public ActionResult Collaboration()
        {
            var collaborations = db.Collaborations;
            foreach (var item in db.Collaborations)
             if (!item.Team) collaborations.Add(item);

            return View(collaborations.Include("Publications").Include("ImageCollaborations").ToList());
        }

        // GET: FrontContact/Create
        public ActionResult Contact()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,LastName,FirstName,Email,PhoneNumber,SendDate,Message,SymbolLanguage")] ContactMessage contactMessage)
        {
            ViewBag.Message = "Nous contact:";          
            if (ModelState.IsValid)
            {
                var currentCulture = Session[CommonConstants.CurrentCulture];
                contactMessage.SymbolLanguage = currentCulture.ToString();
                db.ContactMessages.Add(contactMessage);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(contactMessage);
        }

        public FileResult DownLoad(string cvName, int id)
        {
            var fullPath = "~/Equipe/" + id + "-" + cvName;
            return File(fullPath, "application/CV-Download", Path.GetFileName(fullPath));
        }
       
        [ChildActionOnly]
       public ActionResult MainMenu()
       {
        return PartialView(db.LinkAndPresses.ToList());           
       }

        [ChildActionOnly]
        public ActionResult Presse()
        {
          return PartialView(db.LinkAndPresses.ToList());
        }

        public ActionResult TochHistoire()
        {                    
                return View(db.TochStorys.ToList());          
        }

        public ActionResult TochPhase()
        {        
            return View(db.TochPhrases.ToList());
        }
                     
        public ActionResult Aide()
        {           
            return View();
        }
               
        public ActionResult Activity()
        {
            var activitys = db.Activitys.Include("Language");            
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }

        [ChildActionOnly]
        public ActionResult PageActivity()
        {
            var activitys = db.Activitys.Include("Language");
            return PartialView(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }

       
    }
}