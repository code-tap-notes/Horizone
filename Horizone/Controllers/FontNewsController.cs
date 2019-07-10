using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Common;
using Horizone.Models;

namespace Horizone.Controllers
{
    public class FontNewsController : BaseController
    {        
        // GET: FontNews
        public ActionResult Index()
        {
            var newses = db.Newses.Include(n => n.Collaborator).Include(n => n.Language).Include(n => n.Topic);
            
            return View(newses.ToList());
        }     

        public ActionResult ConferencesAndSymposia()
        {
            var newses = db.Newses.Include(n => n.Collaborator).Include(n => n.Language).Include(n => n.Topic).Where(x => x.Topic.Id == 9 || x.Topic.Id == 14);
            return View(newses.ToList());
        }
        public ActionResult ExpositionsAndMuseums()
        {
            var newses = db.Newses.Include(n => n.Collaborator).Include(n => n.Language).Include(n => n.Topic).Where(x => x.Topic.Id == 11 || x.Topic.Id == 16);
            return View(newses.ToList());
        }
        public ActionResult Media()
        {
            var newses = db.Newses.Include(n => n.Collaborator).Include(n => n.Language).Include(n => n.Topic).Where(x=>x.Topic.Id == 12);
            return View(newses.ToList());
        }

        [ChildActionOnly]
        public ActionResult ListNews()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses");
            return PartialView(news.OrderByDescending(x => x.View).Take(3).ToList());
        }

        [ChildActionOnly]
        public ActionResult LatestNewsFr()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses").Where(x=>x.LanguageId == 1);
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

        // GET: FontNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Include("Collaborator").Include("Language").Include("Topic").Include("ImageNewses").SingleOrDefault(x=>x.Id ==id);
            news.View += 1;
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        // POST: BackOffice/Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ChildActionOnly]
        public ActionResult CreateComment([Bind(Include = "Id,Content,NewsId,UserId")] Comment comment)
        {          
            ViewBag.Message = "Comment";
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("CreatComment");
            }
            return View(comment);
        }  
       }
}
