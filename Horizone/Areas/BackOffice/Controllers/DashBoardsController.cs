using Horizone.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Colaborator,Admin")]
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
        public ActionResult About()
        {                       
                return View(db.MainContents.ToList());

        }
        public ActionResult AboutUs()
        {            
            return View(db.MainContents.ToList());
        }
        // GET: FrontContact/Create
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }

    }
}