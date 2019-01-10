using Horizone.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Horizone.Areas.BackOffice.Controllers
{
    //[Authorize(Roles = "Commercial,Admin")]
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
    }
}