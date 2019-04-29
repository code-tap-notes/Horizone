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
using Rotativa;

namespace Horizone.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Photographs()
        {
            return View();
        }
        public ActionResult Glossary()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Map()
        {         
            ViewBag.Place = new SelectList(db.ImageMaps, "Id", "NamePicture");
            
            return PartialView();            
        }
        
        // GET: BackOffice/Maps/Details/5
        public ActionResult MapDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageMap allPicture = db.ImageMaps.Find(id);
            if (allPicture == null)
            {
                return HttpNotFound();
            }
            return View(allPicture);
        }
        public ActionResult About()
        {                       
            var aboutProjets = db.AboutProjets.Include(a => a.Language);
            return View(aboutProjets.Include("ImageProjects").ToList());
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
                var partnerAndRelations = db.PartnerAndRelations;
            foreach (var item in db.PartnerAndRelations)
                if (item.Partner) partnerAndRelations.Add(item);
            return View(partnerAndRelations.Include("ImagePartners").OrderBy(x => x.Order).ToList());
        }
       
        public ActionResult RelationInternational()
        {
                var partnerAndRelations = db.PartnerAndRelations;
            foreach (var item in db.PartnerAndRelations)
                if (item.Relation) partnerAndRelations.Add(item);
            return View(partnerAndRelations.Include("ImagePartners").OrderBy(x => x.Order).ToList());           
        }
            
        public FileResult DownLoad(int id)
        {
            var collaborations = db.Collaborations;
            var fullPath = "~/Equipe/" + id + "123-" + collaborations.Find(id).CV;
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
        public ActionResult ThemeStory()
        {
            return View(db.ThemeStorys.ToList());
        }
        public ActionResult NamePlace()
        {
            return View(db.NamePlaces.ToList());
        }
        public ActionResult ProperNoun()
        {
            return View(db.ProperNouns.ToList());
        }
        public ActionResult PrintHistoire()
        {
            var report = new ActionAsPdf("TochHistoire");
            return report;
        }

        public ActionResult Activity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Include("ImageActivity");            
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