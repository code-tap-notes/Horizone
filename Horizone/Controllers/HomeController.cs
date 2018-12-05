using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Controllers
{
    public class HomeController : Controller
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
            ViewBag.Message = "Bibliography";

            return View();
        }

    }
}