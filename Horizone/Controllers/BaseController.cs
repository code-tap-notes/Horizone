using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                return client.FisrtName;
            }
            else
            {
                return "";
            }
        }

        protected string GetCurrentCommercialName()
        {
            var userId = User.Identity.GetUserId();
            var commercial = db.Colaborateurs.SingleOrDefault(x => x.UserId == userId);
            if (commercial != null)
            {
                return commercial.FisrtName;
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
                return client.FisrtName;
            }
            else
            {
                return "";
            }
        }

    }
}