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
using Microsoft.AspNet.Identity;

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
            if(news.Count()!=0)
            { ViewBag.NewsIdZh = news.OrderByDescending(x => x.Id).First().Id;
            }
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
        
        [ChildActionOnly]
        public ActionResult ListComment(int? id)
        {
            var comments = db.Comments.Include("News").Include("Client").Where(x=>x.NewsId==id);
            ViewBag.NewsId = id;
            return PartialView(comments.OrderByDescending(x => x.Id).ToList());
        }
        
        public ActionResult NewComment(string search,int id)
        { string userId = User.Identity.GetUserId();
            var comment = new Comment();
            Client client = db.Clients.Include("ApplicationUser").SingleOrDefault(x => x.UserId == userId);
            if (id != 0)
            {
                comment.Content = search;
                comment.Date = DateTime.Now;
                comment.NewsId = id;
                comment.ClientId = client.Id;
            }
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
           
            return View(comment);
        }
    }
}
