using Horizone.Controllers;
using Horizone.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

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
            var aboutProjets = db.AboutProjets.Include("Language").Include("ImageProjects");
            return View(aboutProjets.ToList());
        }
       
        //Presentation pour homepage
        [ChildActionOnly]
        public ActionResult PresenteProject()
        {
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

        [ChildActionOnly]
        public ActionResult Address()
        {
            var aboutProjets = db.AboutProjets.Include("Language");
            return PartialView(aboutProjets.ToList());
        }
        public ActionResult AboutUs()
        {
            var collaborations = db.Collaborations;
            foreach (var item in collaborations)
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
            if (news.Count() != 0)
            {
                ViewBag.NewsIdFr = news.OrderByDescending(x => x.Id).First().Id;
            }
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }
        [ChildActionOnly]
        public ActionResult LatestNewsEn()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses").Where(x => x.LanguageId == 2);
            if (news.Count() != 0)
            {
                ViewBag.NewsIdEn = news.OrderByDescending(x => x.Id).First().Id;
            }
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }
        [ChildActionOnly]
        public ActionResult LatestNewsZh()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses").Where(x => x.LanguageId == 3);
            if (news.Count() != 0)
            {
                ViewBag.NewsIdZh = news.OrderByDescending(x => x.Id).First().Id;
            }
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult Help()
        {
            var visualAids = db.VisualAids.Include(v => v.Language);
            var question = db.VisualAids.Include(v => v.Language).Where(x => x.Question == true);

            ViewBag.Aide = new SelectList(question, "Id", "Aids");

            return View(visualAids.ToList());
        }
        [ChildActionOnly]
        public ActionResult Map()
        {
            ViewBag.Place = new SelectList(db.ImageMaps, "Id", "NamePicture");
            return PartialView(db.Maps.Include("ImageMaps").OrderBy(x => x.NamePicture).ToList());
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
        public ActionResult SearchBibliography(string search)
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
            return View("SearchBibliography", bibliographies.ToList());
        }
        //For vocabularies
        public ActionResult SearchWord(string search)
        {
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("WordClass").Include("WordSubClass");
            IEnumerable<Verb> verbs = db.Verbs.Include("WordClass").Include("WordSubClass").Include("Voice").Include("Valency").Include("TenseAndAspect").Include(" Mood").Include("Persons");
            IEnumerable<NounAdjective> nounAdjectives = db.NounAdjectives.Include("WordClass").Include("WordSubClass").Include("Genders").Include("Cases");
            IEnumerable<Pronoun> pronouns = db.Pronouns.Include("WordClass").Include("WordSubClass").Include("Genders").Include("Cases").Include("Persons");
            IEnumerable<OtherWord> otherWords = db.OtherWords.Include("WordClass").Include("WordSubClass");
            IEnumerable<NamePlace> namePlaces = db.NamePlaces;
            IEnumerable<ProperNoun> properNouns = db.ProperNouns;
            List<SearchResult> searchResults = new List<SearchResult>();
            foreach (var item in db.SearchResults)
            {
                db.SearchResults.Remove(item);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {

                properNouns = db.ProperNouns.Where(x => x.Name.Contains(search));
                if (properNouns.Count() != 0)
                {
                    foreach (var item in properNouns)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "ProperNouns", IdResult = item.Id, Summary = item.Name });
                    }
                }
                verbs = verbs.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
                );
                if (verbs.Count() != 0)
                {
                    foreach (var item in verbs)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Verbs", IdResult = item.Id, Summary = (item.TochWord + " - " + item.TochLanguage.Language + " - " + item.WordClass.ClassEn + " - " + item.WordSubClass.SubClassEn + " - " + item.English + " - " + item.Francaise + " - " + item.German + " - " + item.Latin + " - " + item.Sanskrit) });
                    }
                }
                nounAdjectives = nounAdjectives.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
                );
                if (nounAdjectives.Count() != 0)
                {
                    foreach (var item in nounAdjectives)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "NounAdjectives", IdResult = item.Id, Summary = (item.TochWord + " - " + item.TochLanguage.Language + " - " + item.WordClass.ClassEn + " - " + item.WordSubClass.SubClassEn + " - " + item.English + " - " + item.Francaise + " - " + item.German + " - " + item.Latin + " - " + item.Sanskrit) });
                    }
                }
                pronouns = pronouns.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
              );
                if (pronouns.Count() != 0)
                {
                    foreach (var item in pronouns)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Pronouns", IdResult = item.Id, Summary = (item.TochWord + " - " + item.TochLanguage.Language + " - " + item.WordClass.ClassEn + " - " + item.WordSubClass.SubClassEn + " - " + item.English + " - " + item.Francaise + " - " + item.German + " - " + item.Latin + " - " + item.Sanskrit) });
                    }
                }
                otherWords = otherWords.Where(x => x.TochWord.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search))
              );
                if (otherWords.Count() != 0)
                {
                    foreach (var item in otherWords)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "OtherWords", IdResult = item.Id, Summary = (item.TochWord + " - " + item.TochLanguage.Language + " - " + item.WordClass.ClassEn + " - " + item.WordSubClass.SubClassEn + " - " + item.English + " - " + item.Francaise + " - " + item.German + " - " + item.Latin + " - " + item.Sanskrit) });
                    }
                }
                namePlaces = db.NamePlaces.Where(x => x.Place.Contains(search));
                if (namePlaces.Count() != 0)
                {
                    foreach (var item in namePlaces)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "NamePlaces", IdResult = item.Id, Summary = item.Place + " " + item.DescriptionEn });
                    }
                }
                dictionaryTocharians = dictionaryTocharians.Where(x => x.Word.Contains(search)
                || (x.Sanskrit != null && x.Sanskrit.Contains(search))
                || (x.English != null && x.English.Contains(search))
                || (x.Francaise != null && x.Francaise.Contains(search))
                || (x.German != null && x.German.Contains(search))
                || (x.Latin != null && x.Latin.Contains(search))
                || (x.Chinese != null && x.Chinese.Contains(search)));
                if (dictionaryTocharians.Count() != 0)
                {
                    foreach (var item in dictionaryTocharians)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "DictionaryTocharians", IdResult = item.Id, Summary = (item.Word + " - " + item.TochLanguage.Language + " - " + item.WordClass.ClassEn + " - " + item.WordSubClass.SubClassEn + " - " + item.English + " - " + item.Francaise + " - " + item.German + " - " + item.Latin + " - " + item.Sanskrit) });
                    }
                }

                foreach (var item in searchResults)
                {
                    db.SearchResults.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.Search = search;
            return View("SearchWord", db.SearchResults.ToList());

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
            IEnumerable<TochStory> tochStories = db.TochStorys.Include("SourceStory").Include("ThemeStory");
            IEnumerable<DictionaryTocharian> dictionaryTocharians = db.DictionaryTocharians.Include("WordClass").Include("WordSubClass");
            IEnumerable<TochPhrase> tochPhrases = db.TochPhrases;
            IEnumerable<Manuscript> manuscripts = db.Manuscripts.Include("Catalogie").Include("TochLanguage");
            IEnumerable<Bibliography> bibliographys = db.Bibliographys;
            IEnumerable<NamePlace> namePlaces = db.NamePlaces;
            IEnumerable<ProperNoun> properNouns = db.ProperNouns;
            List<SearchResult> searchResults = new List<SearchResult>();
            
            if (!string.IsNullOrWhiteSpace(search))
            {
                tochStories = db.TochStorys.Include("SourceStory").Include("ThemeStory").Where(x => x.Content.Contains(search) || x.English.Contains(search) || x.Francaise.Contains(search)
                    || x.Content.Contains(search) || x.SourceStory.SourceEn.Contains(search) || x.Name.Contains(search) || x.Description.Contains(search)
                    || x.ThemeStory.ThemeEn.Contains(search) || x.ThemeStory.ThemeFr.Contains(search) || x.ThemeStory.ThemeZn.Contains(search));
                if (tochStories.Count() != 0)
                {

                    foreach (var item in tochStories)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "TochStories", IdResult = item.Id, Summary = item.Name.Substring(0, Math.Min(60, item.Name.Length)) });
                    }
                }
                properNouns = db.ProperNouns.Where(x => x.Name.Contains(search));
                if (properNouns.Count() != 0)
                {
                    foreach (var item in properNouns)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "ProperNouns", IdResult = item.Id, Summary = item.Name });
                    }
                }
                namePlaces = db.NamePlaces.Where(x => x.Place.Contains(search));
                if (namePlaces.Count() != 0)
                {
                    foreach (var item in namePlaces)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "NamePlaces", IdResult = item.Id, Summary = item.Place + " " + item.DescriptionEn });
                    }
                }
                dictionaryTocharians = db.DictionaryTocharians.Include("WordClass").Where(x => x.Word.Contains(search) || x.English.Contains(search) || x.Francaise.Contains(search)
                    || x.Chinese.Contains(search) || x.German.Contains(search) || x.Latin.Contains(search));
                if (dictionaryTocharians.Count() != 0)
                {
                    foreach (var item in dictionaryTocharians)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "DictionaryTocharians", IdResult = item.Id, Summary = item.Word + " - " + item.TochLanguage.Language + " - " + item.WordClass.ClassEn + " - " + item.WordSubClass.SubClassEn + " - " + item.English + " - " + item.Francaise + " - " + item.German + " - " + item.Latin + " - " + item.Sanskrit });
                    }
                }
                tochPhrases = db.TochPhrases.Where(x => x.Phrase.Contains(search) || x.English.Contains(search) || x.Francaise.Contains(search));
                if (tochPhrases.Count() != 0)
                {
                    foreach (var item in tochPhrases)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "TochPhrases", IdResult = item.Id, Summary = item.Phrase.Substring(0, Math.Min(40, item.Phrase.Length)) });
                    }
                }
                manuscripts = db.Manuscripts.Where(x => x.Index.Contains(search) || x.Catalogie.Name.Contains(search) || x.Title.Contains(search) || x.Transcription.Contains(search) || x.TochLanguage.Language.Contains(search));
                if (manuscripts.Count() != 0)
                {
                    foreach (var item in manuscripts)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Manuscripts", IdResult = item.Id, Summary = item.Transcription.Substring(0, Math.Min(40, item.Transliteration.Length)) });
                    }
                }
                bibliographys = db.Bibliographys.Where(x => x.Title.Contains(search) || x.Journal.Contains(search) || x.Author.Contains(search));
                if (bibliographys.Count() != 0)
                {
                    foreach (var item in bibliographys)
                    {
                        searchResults.Add(new SearchResult() { NameTable = "Bibliographies", IdResult = item.Id, Summary = item.Title.Substring(0, Math.Min(40, item.Title.Length)) });
                    }
                }
                foreach (var item in searchResults)
                {
                    db.SearchResults.Add(item);
                    db.SaveChanges();
                }
            }
            ViewBag.Search = search;
            return View("SearchIndex", db.SearchResults.ToList());
        }
        //For edit and create
        [ChildActionOnly]
        public ActionResult SpecialCharacter()
        {
            return PartialView();
        }
        //Form search common
        [ChildActionOnly]
        public ActionResult SearchForm()
        {
            return PartialView();
        }
    }
}
