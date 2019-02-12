using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Horizone.Common;
using Horizone.Models;
using Microsoft.AspNet.Identity;

namespace Horizone.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();


        /// <summary>
        /// Affiche un message dans le layout success ou erreur avec ou sans redirection
        /// </summary>
        /// <param name="text">le text a afficher</param>
        /// <param name="type">le type de message</param>
        protected void Display(string text, MessageType type = MessageType.SUCCES)
        {
            var m = new Message(type, text);
            TempData["MESSAGE"] = m;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }

        protected int GetCurrentClientId()
        {
            var userId = User.Identity.GetUserId();
            var client = db.Clients.SingleOrDefault(x => x.UserId == userId);
            if (client != null)
            {
                return client.Id;
            }
            else
            {
                return 0;
            }
        }

        protected string GetCurrentClientName()
        {
            var userId = User.Identity.GetUserId();
            var client = db.Clients.SingleOrDefault(x => x.UserId == userId);
            if (client != null)
            {
                return client.FirstName;
            }
            else
            {
                return "";
            }
        }

        protected string GetCurrentCollaboratorName()
        {
            var userId = User.Identity.GetUserId();
            var collaborator = db.Collaborators.SingleOrDefault(x => x.UserId == userId);
            if (collaborator != null)
            {
                return collaborator.FirstName;
            }
            else
            {
                return "";
            }
        }

        protected string GetCurrentUserRoles()
        {
            var userId = User.Identity.GetUserId();           
            var client = db.Clients.SingleOrDefault(x => x.UserId == userId);
            if (client != null)
            {
                return client.FirstName;
            }
            else
            {
                return "";
            }
        }
        //initilizing culture on controller initialization
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session[CommonConstants.CurrentCulture] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
            }
            else
            {
                Session[CommonConstants.CurrentCulture] = "fr";
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            }
        }

        // changing culture
        public ActionResult ChangeCulture(string ddlCulture, string returnUrl)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);

            Session[CommonConstants.CurrentCulture] = ddlCulture;
            return Redirect(returnUrl);
        }

    }
}