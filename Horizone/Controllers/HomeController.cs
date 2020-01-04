using Horizone.Models;
using Newtonsoft.Json.Linq;
using Rotativa;
using System;
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
        [ChildActionOnly]
        public ActionResult SpecialCharacter()
        {
            return PartialView();
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
            var question = db.VisualAids.Include(v => v.Language).Where(x => x.Question == true);          
            ViewBag.Aide = new SelectList(question, "Id", "Aids");

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
            return PartialView(db.Maps.Include("ImageMaps").OrderBy(x => x.NamePicture).ToList());
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
        [ChildActionOnly]
        public ActionResult LatestStory()
        {
            var latestStories = db.TochStorys.Include("ThemeStory").Include("SourceStory");
            return PartialView(latestStories.OrderByDescending(x => x.Id).Take(3).ToList());
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
        public ActionResult LinkMenu()
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
            return View(db.TochStorys.Include("SourceStory").Include("ThemeStory").OrderBy(x => x.Name).ToList());
        }

        // GET: BackOffice/TochStories/Details/5
        public ActionResult DetailsStory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TochStory tochStory = db.TochStorys.Include("SourceStory").Include("ThemeStory").SingleOrDefault(x => x.Id == id);

            if (tochStory == null)
            {
                return HttpNotFound();
            }
            return View(tochStory);
        }

        public ActionResult ThemeStory()
        {
           return View(db.ThemeStorys);
        }
        public ActionResult NamePlace()
        {
            return View(db.NamePlaces.OrderBy(x => x.Place).ToList());
        }
        public ActionResult PlaceInStory()
        {
            return View("NamePlace",db.NamePlaces.Where(x => x.InStory == true).OrderBy(x => x.Place).ToList());
        }
        public ActionResult ProperNoun()
        {
            return View(db.ProperNouns.OrderBy(x => x.Name).ToList());
        }
        public ActionResult NameInStory()
        {
            return View("ProperNoun",db.ProperNouns.Where(x=>x.InStory==true).OrderBy(x => x.Name).ToList());
        }
        public ActionResult SourceStory()
        {
            IEnumerable<SourceStory> sourceStories = db.SourceStorys;
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            {
                sourceStories.OrderBy(x => x.SourceEn.ToList());
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                sourceStories.OrderBy(x => x.SourceFr.ToList());
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                sourceStories.OrderBy(x => x.SourceZh.ToList());
            }

            return View(sourceStories);
        }
        // Search
        public ActionResult SearchName(string search)
        {
            IEnumerable<ProperNoun> properNouns = db.ProperNouns;

            if (!string.IsNullOrWhiteSpace(search))
            {
                properNouns = properNouns.Where(x => x.Name.Contains(search));
            }
            if (properNouns.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchName", properNouns.OrderBy(x => x.Name).ToList());
        }
        public ActionResult SearchTheme(string search)
        {
            IEnumerable<ThemeStory> themeStorys = db.ThemeStorys;

            if (!string.IsNullOrWhiteSpace(search))
            {
                themeStorys = themeStorys.Where(x => x.ThemeEn.Contains(search) 
                || x.ThemeFr.Contains(search) || x.ThemeZn.Contains(search));
            }
            if (themeStorys.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "en")
            { 
                themeStorys.OrderBy(x => x.ThemeEn).ToList();
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "fr")
            {
                themeStorys.OrderBy(x => x.ThemeFr).ToList();
            }
            if (Session[Horizone.Common.CommonConstants.CurrentCulture].ToString() == "zh")
            {
                themeStorys.OrderBy(x => x.ThemeZn).ToList();
            }

            return View("SearchTheme", themeStorys);
        }
        public ActionResult SearchStory(string search)
        {
            IEnumerable<TochStory> tochStories = db.TochStorys.Include("SourceStory").Include("ThemeStory");

            if (!string.IsNullOrWhiteSpace(search))
            {
                tochStories = tochStories.Where(x => (x.Content != null && x.Content.Contains(search)) 
                || (x.English != null && x.English.Contains(search)) 
                || (x.Francaise != null && x.Francaise.Contains(search)) 
                || (x.Chinese != null && x.Chinese.Contains(search))
                || (x.SourceStory.SourceEn != null && x.SourceStory.SourceEn.Contains(search)) 
                || (x.SourceStory.SourceFr != null && x.SourceStory.SourceFr.Contains(search)) 
                || (x.SourceStory.SourceZh != null && x.SourceStory.SourceZh.Contains(search)) 
                || (x.Name != null && x.Name.Contains(search)) 
                || (x.SourceStory.SourceEn != null && x.Description.Contains(search))
                || (x.ThemeStory.ThemeEn != null && x.ThemeStory.ThemeEn.Contains(search)) 
                || (x.ThemeStory.ThemeFr != null && x.ThemeStory.ThemeFr.Contains(search)) 
                || (x.ThemeStory.ThemeZn != null && x.ThemeStory.ThemeZn.Contains(search)));
            }
            if (tochStories.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchStory", tochStories.OrderBy(x => x.Name).ToList());
        }
        public ActionResult RefreshSearch()
        {
            foreach (var item in db.SearchResults)
            {
                db.SearchResults.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("SearchIndex");
        }
        public ActionResult SearchIndex(string search)
            
        {
            RefreshSearch();
            if (!string.IsNullOrWhiteSpace(search))
            {
            IEnumerable<TochStory> tochStories = db.TochStorys.Include("SourceStory").Include("ThemeStory").Where(x => (x.English != null && x.English.Contains(search)) 
                    || (x.Francaise != null && x.Francaise.Contains(search)) 
                    || (x.Chinese != null && x.Chinese.Contains(search))
                    || (x.Content != null && x.Content.Contains(search)) 
                    || (x.SourceStory.SourceEn != null && x.SourceStory.SourceEn.Contains(search)) 
                    || (x.Name != null && x.Name.Contains(search)) 
                    || (x.Description != null && x.Description.Contains(search))
                    || (x.ThemeStory.ThemeEn != null && x.ThemeStory.ThemeEn.Contains(search)) 
                    || (x.ThemeStory.ThemeFr != null && x.ThemeStory.ThemeFr.Contains(search)) 
                    || (x.ThemeStory.ThemeZn != null && x.ThemeStory.ThemeZn.Contains(search)));
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("TochLanguage").Include("WordClass").Include("WordSubClass").Where(x => x.Word.Contains(search) 
                    || (x.English != null && x.English.Contains(search)) 
                    || (x.Francaise != null && x.Francaise.Contains(search))
                    || (x.Chinese != null && x.Chinese.Contains(search)) 
                    || (x.German != null && x.German.Contains(search)) 
                    || (x.Latin != null && x.Latin.Contains(search)));
            IEnumerable<TochPhrase> tochPhrases = db.TochPhrases.Include("TochLanguage").Where(x => x.Phrase.Contains(search) 
                    || (x.English != null && x.English.Contains(search)) 
                    || (x.Francaise != null && x.Francaise.Contains(search)));
            IEnumerable<Manuscript> manuscripts = db.Manuscripts.Include("Catalogie").Include("TochLanguage").Where(x => x.Index.Contains(search) 
                    || x.Catalogie.Name.Contains(search) 
                    || (x.Title != null && x.Title.Contains(search)) 
                    || (x.Transcription != null && x.Transcription.Contains(search)) 
                    || x.TochLanguage.Language.Contains(search));
            IEnumerable<Bibliography> bibliographys = db.Bibliographys.Where(x => x.Title.Contains(search) 
                    || x.Journal.Contains(search) || x.Author.Contains(search));
            IEnumerable<NamePlace> namePlaces = db.NamePlaces.Where(x => x.Place.Contains(search));
            IEnumerable<ProperNoun> properNouns = db.ProperNouns.Where(x => (x.Name != null && x.Name.Contains(search)));
            IEnumerable<SearchResult> results = db.SearchResults;
            List<SearchResult> searchResults = new List<SearchResult>();
           
                if (tochStories.Count() != 0) {

                    foreach (var item in tochStories)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "TochStorys", IdResult = item.Id, Summary = item.Name.Substring(0,Math.Min(40,item.Name.Length)) });
                    }
                }
                if (properNouns.Count() != 0)
                {
                    foreach (var item in properNouns)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "ProperNouns", IdResult = item.Id, Summary = item.Name });
                    }
                }
                if (namePlaces.Count() != 0)
                {
                    foreach (var item in namePlaces)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "NamePlaces", IdResult = item.Id, Summary = string.IsNullOrEmpty(item.DescriptionEn) ? item.Place : item.Place + " - " + item.DescriptionEn });
                    }
                }
                if (dictionaryTocharians.Count() != 0)
                {
                    foreach (var item in dictionaryTocharians)
                    {
                        string[] myStrings = new string[] { item.Word, item.TochLanguage.Language, item.WordClass.ClassEn, item.WordSubClass.SubClassEn, item.English, item.Francaise, item.German, item.Latin, item.Chinese };
                        searchResults.Add(new SearchResult() { NameTable = "DictionaryTocharians", IdResult = item.Id, Summary = string.Join(" - ", myStrings.Where(str => !string.IsNullOrEmpty(str)))});
                    }
                }
                if (tochPhrases.Count() != 0)
                {
                    foreach (var item in tochPhrases)
                    {
                         searchResults.Add(new SearchResult() { NameTable = "TochPhrases", IdResult = item.Id, Summary = item.Phrase.Substring(0,Math.Min(40, item.Phrase.Length)) });
                     }
                }
                if (manuscripts.Count() != 0)
                {
                    foreach (var item in manuscripts)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Manuscripts", IdResult = item.Id, Summary = item.Transcription.Substring(0,Math.Min(40, item.Transliteration.Length)) });
                    }
                }
                if (bibliographys.Count() != 0)
                {
                    foreach (var item in bibliographys)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Bibliographys", IdResult = item.Id, Summary = item.Title.Substring(0,Math.Min(40, item.Title.Length)) });                       
                    }
                }                
                foreach (var item in searchResults)
                {
                    db.SearchResults.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.Search = search;
           return View("SearchIndex",db.SearchResults.ToList());
        }
      

        [ChildActionOnly]
        public ActionResult SearchMap(string search)
        {
            IEnumerable<Map> maps = db.Maps.Include("ImageMap");

            if (!string.IsNullOrWhiteSpace(search))
            {
                maps = maps.Where(x => x.NamePicture == search);
            }
            if (maps.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return PartialView("Map", maps.OrderBy(x => x.NamePicture).ToList());
        }
        public ActionResult SearchQuestion(string search)
        {
            IEnumerable<VisualAid> visualAids = db.VisualAids.Where(x => x.Question == true);

            if (!string.IsNullOrWhiteSpace(search))
            {
                visualAids = visualAids.Where(x => x.Aids.Contains(search));
            }
            if (visualAids.Count() == 0)
            {
                Display("Aucun résultat");
            }
         
            ViewBag.Search = search;
            return View("SearchQuestion", visualAids.ToList());
        }
       
        //Form search common
        [ChildActionOnly]
        public ActionResult SearchForm()
        {
            return PartialView();
        }
        public ActionResult PrintHistoire(int? id)
        {

            var report = new ActionAsPdf("DetailsStory", new { id = id });
            return report;
        }

        //Activity sur menu
        public ActionResult Activity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic");
            return View(activitys.OrderByDescending(x => x.Id).ToList());
        }
        //Activity Home page
        [ChildActionOnly]
        public ActionResult PageActivity()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic");
            return PartialView(activitys.OrderByDescending(x => x.Id).Take(5).ToList());
        }
        public ActionResult Symposia()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x => x.Topic.Id == 14);
            return View(activitys.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult Publications()
        {
            return View(db.Publications.OrderByDescending(x => x.Id).ToList());
        }
        [ChildActionOnly]
        public ActionResult PagePublication()
        {
            return PartialView(db.Publications.OrderByDescending(x => x.Id).Take(5).ToList());
        }
       
        public ActionResult ConferencesAndSeminar()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x => x.Topic.Id == 13 || x.Topic.Id == 9);
            return View(activitys.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult Missions()
        {
            var activitys = db.Activitys.Include("Language").Include("Topic").Where(x => x.Topic.Id == 15);
            return View(activitys.OrderByDescending(x => x.Id).ToList());
        }
        
    }
}