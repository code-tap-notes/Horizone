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

namespace Horizone.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Maincontent()
        {
            
            return View(db.MainContents.ToList());
        }

        public ActionResult About()
        {            
            return View(db.MainContents.ToList());           
        }
        public ActionResult AboutUs()
        {            
            return View();
        }
        public ActionResult Collaboration()
        {
          
            return View();
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


        public ActionResult Bibliographie(int page = 1, int pageSize = 6)
        {
            return View(db.Bibliographys.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            //return PartialView(db.Menus.ToList());
            return PartialView();
        }
        public ActionResult TochHistoire()
        {
                    
                return View(db.TochStorys.ToList());          
        }
        public ActionResult TochPhase()
        {
        
            return View(db.TochPhrases.ToList());
        }
        public ActionResult Vocabulaire()
        {
            var transcriptions = db.Transcriptions;
            return View(transcriptions.ToList());
           
        }
        public ActionResult Nouvelles()
        {

            var newss = db.Newss.Include(n => n.Colaborateur).Include(n => n.Topic);
            return View(newss.ToList());
        }
        // GET: Manuscripts
        public ActionResult Manuscript()
        {           
                       
        var manuscripts = db.Manuscripts;
        return View(manuscripts.ToList());
                       
        }
        public ActionResult Aide()
        {
            ViewBag.Message = "Comment utiliser le site web";

            return View();
        }
       
        [ChildActionOnly]
        public ActionResult Activity()
        {
            return PartialView(db.Activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
    }
}