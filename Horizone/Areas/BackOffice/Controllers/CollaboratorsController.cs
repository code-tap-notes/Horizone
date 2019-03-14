using Horizone.Controllers;
using Horizone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CollaboratorsController : BaseController
    {

        // GET: BackOffice/Collaborators
        public ActionResult Index()
        {
            List<Collaborator> clients = db.Collaborators.ToList();
            return View(clients);
        }
        // GET: BackOffice/Collaborators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaborator collaborator = db.Collaborators.Find(id);
            if (collaborator == null)
            {
                return HttpNotFound();
            }
            return View(collaborator);
        }
    }
}