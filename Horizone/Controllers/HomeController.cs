using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Horizone.Models;
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
            ViewBag.Message = "Equipe HISTOCHTEXT";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nous contact:";

            return View();
        }
        public ActionResult Bibliography()
        {           
                return View(db.Bibliographys.ToList());
            
        }
        public ActionResult TochStory()
        {
            ViewBag.Message = "TochStory";
           
                return View(db.TochStorys.ToList());          
        }
        public ActionResult Tochphrase()
        {
            ViewBag.Message = "Tochphrase";

            return View(db.TochPhrases.ToList());
        }
        public ActionResult Word()
        {
            ViewBag.Message = "Word";
            var transcriptions = db.Transcriptions;
            return View(transcriptions.ToList());
           
        }
        public ActionResult News()
        {
            ViewBag.Message = "News";

            var newss = db.Newss.Include(n => n.Colaborateur).Include(n => n.Topic);
            return View(newss.ToList());
        }
        // GET: Manuscripts
        public ActionResult Manuscript()
        {
            ViewBag.Message = "Manuscript";
                       
        var manuscripts = db.Manuscripts;
        return View(manuscripts.ToList());
                       
        }
        public ActionResult Help()
        {
            ViewBag.Message = "How to use web page";

            return View();
        }
    }
}