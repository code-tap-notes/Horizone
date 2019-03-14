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

        [ChildActionOnly]
        public ActionResult ListNews()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses");
            return PartialView(news.OrderByDescending(x => x.View).ToList());
        }

        [ChildActionOnly]
        public ActionResult LatestNews()
        {
            var news = db.Newses.Include("Language").Include("Collaborator").Include("Topic").Include("ImageNewses");
            return PartialView(news.OrderByDescending(x => x.Id).ToList());
        }

        // GET: FontNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newses.Find(id);
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
