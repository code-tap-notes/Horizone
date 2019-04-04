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
       
        public ActionResult Contact()
        {
            var aboutProjets = db.AboutProjets.Include(a => a.Language);
            return View(aboutProjets.ToList());
        }
        public ActionResult Aide()
        {
            var visualAids = db.VisualAids.Include(v => v.Language);
            return View(visualAids.ToList());
        }
        [ChildActionOnly]
        public ActionResult PresentationVisualAid()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        [ChildActionOnly]
        public ActionResult PresenteProject()
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
        [ChildActionOnly]
        public ActionResult PresentationTochPhrase()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        [ChildActionOnly]
        public ActionResult PresentationTochStory()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        [ChildActionOnly]
        public ActionResult PresentationManuscript()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        [ChildActionOnly]
        public ActionResult PresentationDictionaryTocharian()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        [ChildActionOnly]
        public ActionResult PresentationActivity()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        public ActionResult PresentationAboutUs()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        
        [ChildActionOnly]
        public ActionResult PresentationBibliography()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        public ActionResult AboutUs()
        {
            var collaborations = db.Collaborations;
            foreach (var item in collaborations)
            if (item.Team) collaborations.Add(item);
            return View(collaborations.Include("Publications").Include("ImageCollaborations").OrderBy(x=>x.Order).ToList());
        }

        public ActionResult Collaboration()
        {
            var collaborations = db.Collaborations;
            foreach (var item in db.Collaborations)
             if (item.Collaborator) collaborations.Add(item);

            return View(collaborations.Include("Publications").Include("ImageCollaborations").OrderBy(x => x.Order).ToList());
        }
        public ActionResult AssociatedResearcher()
        {
            var collaborations = db.Collaborations;
            foreach (var item in db.Collaborations)
                if (item.AssociatedResearcher) collaborations.Add(item);

            return View(collaborations.Include("Publications").Include("ImageCollaborations").OrderBy(x => x.Order).ToList());
        }
        public ActionResult Partner()
        {            
            return View();
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
                                             
        public ActionResult Activity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic");            
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
        [ChildActionOnly]
        public ActionResult PageActivity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic");
            return PartialView(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }    
    }
}