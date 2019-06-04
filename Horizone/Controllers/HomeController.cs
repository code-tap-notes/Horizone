using Horizone.Common;
using Horizone.Models;
using Rotativa;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Horizone.Controllers
{
    public class HomeController : BaseController
    {
        //Menu standard
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
        //Menu Aide
        public ActionResult Aide()
        {
            var visualAids = db.VisualAids.Include(v => v.Language);
            return View(visualAids.ToList());
        }
        //Pas fait//
        public ActionResult Photographs()
        {
            return View();
        }
        //Pas fait
        public ActionResult Glossary()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Map()
        {
            ViewBag.Place = new SelectList(db.ImageMaps, "Id", "NamePicture");
            return PartialView(db.Maps.Include("ImageMaps").ToList());
        }
       
        //Presentation pour homepage
        [ChildActionOnly]
        public ActionResult PresenteProject()
        {
           // var currentCulture = Session[CommonConstants.CurrentCulture];
            //var symbolLanguage = currentCulture.ToString();
            var aboutProjets = db.AboutProjets.Include("ImageProjects").Include("Language");
            return PartialView(aboutProjets.ToList());
        }
        //Presentation pour tous menus
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
        [ChildActionOnly]
        public ActionResult PresentationVisualAid()
        {
            return PartialView(db.Presentations.Include(a => a.Language).ToList());
        }
        //Menu about us
        public ActionResult AboutUs()
        {
            var collaborations = db.Collaborations;
            foreach (var item in collaborations)
                if (item.Team) collaborations.Add(item);
            return View(collaborations.Include("Publications").Include("ImageCollaborations").OrderBy(x => x.Order).ToList());
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
        //Link
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            return PartialView(db.LinkAndPresses.ToList());
        }
        //Press
        [ChildActionOnly]
        public ActionResult Presse()
        {
            return PartialView(db.LinkAndPresses.ToList());
        }
        //TochStory
        public ActionResult TochHistoire()
        {
            return View(db.TochStorys.Include("SourceStory").Include("ThemeStory").ToList());
        }

        // GET: BackOffice/TochStories/Details/5
        public ActionResult DetailsStory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TochStory tochStory = db.TochStorys.Include("SourceStory").Include("ThemeStory").Include("NamePlaces").Include("ProperNouns").SingleOrDefault(x => x.Id == id);
            if (tochStory.NamePlaces.Count() == 0)
                tochStory.NamePlaces = db.NamePlaces.Where(x => x.PlaceEn == "NA").ToList();
            if (tochStory.ProperNouns.Count() == 0)
                tochStory.ProperNouns = db.ProperNouns.Where(x => x.Name == "NA").ToList();
            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
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
        public ActionResult SourceStory()
        {
            return View(db.SourceStorys.ToList());
        }
        public ActionResult PrintHistoire()
        {
            var report = new ActionAsPdf("TochHistoire");
            return report;
        }
        //Activity sur menu
        public ActionResult Activity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic");
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
        //Activity Home page
        [ChildActionOnly]
        public ActionResult PageActivity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic");
            return PartialView(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
        public ActionResult Symposia()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x => x.Topic.Id == 14);
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
        public ActionResult Publications()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x => x.Topic.Id == 10);
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
        public ActionResult ConferencesAndSeminar()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x => x.Topic.Id == 13 || x.Topic.Id == 9 );
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
        }
        public ActionResult Missions()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x=>x.Topic.Id == 15);
            return View(activitys.OrderByDescending(x => x.DateofActivity).ToList());
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
            return View("SearchWord", dictionaryTocharians.ToList());
        }

    }
}