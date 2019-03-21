using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Controllers;
using Horizone.Models;

namespace Horizone.Areas.BackOffice.Controllers
{
    public class CollaborationsController : BaseController
    {       

        // GET: BackOffice/Collaborations
        public ActionResult Index()
        {
            return View(db.Collaborations.OrderBy(x=>x.Order).ToList());
        }
       
        // GET: BackOffice/Collaborations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaboration collaboration = db.Collaborations.Include("Publications").SingleOrDefault(x => x.Id == id);
            if (collaboration.Publications.Count() == 0)
                collaboration.Publications = db.Publications.Where(x => x.Title == "No visible").ToList();
            if (collaboration == null)
            {
                return HttpNotFound();
            }
            return View(collaboration);
        }
       
       
        // GET: BackOffice/Collaborations/Create
        public ActionResult Create()
        {

            MultiSelectList PValues = new MultiSelectList(db.Publications, "Id", "Title");
            ViewBag.Publications = PValues;
            return View();
        }
        
        // POST: BackOffice/Collaborations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,LastName,FirstName,Summary,CV,Email,Team,Visible,Order")] Collaboration collaboration, int[] PublicationId)
        {
            if (ModelState.IsValid)
            {
                if (PublicationId.Count() > 0)
                    collaboration.Publications = db.Publications.Where(x => PublicationId.Contains(x.Id)).ToList();
 
                if (PublicationId.Count() == 0)
                    collaboration.Publications = db.Publications.Where(x => x.Title == "No visible").ToList();
                db.Collaborations.Add(collaboration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            MultiSelectList PValues = new MultiSelectList(db.Publications, "Id", "Title");
            ViewBag.Publications = PValues;
                return View(collaboration);
        }               

        // GET: BackOffice/Collaborations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaboration collaboration = db.Collaborations.Include("ImageCollaborations").Include("Publications").SingleOrDefault(x => x.Id == id);
            if (collaboration == null)
            {
                return HttpNotFound();
            }           
            MultiSelectList PValues = new MultiSelectList(db.Publications, "Id", "Title", collaboration.Publications.Select(x => x.Id));           
            ViewBag.Publications = PValues;
            return View(collaboration);
        }
        

        // POST: BackOffice/Collaborations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,LastName,FirstName,Summary,CV,Email,Team,Visible,Order")] Collaboration collaboration, int[] PublicationId)
        {
            db.Entry(collaboration).State = EntityState.Modified;           
            db.Collaborations.Include("ImageCollaborations").Include("Publications").SingleOrDefault(x => x.Id == collaboration.Id);
            if (ModelState.IsValid)
            {
                if (PublicationId != null)
                     collaboration.Publications = db.Publications.Where(x => PublicationId.Contains(x.Id)).ToList();
                else
                    collaboration.Publications = db.Publications.Where(x => x.Title == "No visible").ToList();
                db.SaveChanges();
                return RedirectToAction("Index");                                                 
            }

            ViewBag.Publications = new MultiSelectList(db.Publications, "Id", "Title");
            return View(collaboration);
        }
        // GET: BackOffice/Collaborations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collaboration collaboration = db.Collaborations.Find(id);
            if (collaboration == null)
            {
                return HttpNotFound();
            }
            return View(collaboration);
        }

        // POST: BackOffice/Collaborations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Collaboration collaboration = db.Collaborations.Find(id);
            db.Collaborations.Remove(collaboration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Team()
        {
            var collaborations = db.Collaborations;

            foreach (var item in collaborations)                                       
                if (item.Team) collaborations.Add(item);
            
            return View(collaborations.Include("Publications").ToList());
        }
        public ActionResult Collaboration()
        {
            var collaborations = db.Collaborations;
            foreach (var item in collaborations)           
                if (!item.Team) collaborations.Add(item);            
            return View(collaborations.Include("Publications").ToList());
        }

        [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase picture, int id)
        {
            if (picture?.ContentLength > 0)
            {
                var tp = new ImageCollaboration();
                tp.ContentType = picture.ContentType;
                tp.Name = picture.FileName;
                tp.CollaborationId = id;

                using (var reader = new BinaryReader(picture.InputStream))
                {
                    tp.Content = reader.ReadBytes(picture.ContentLength);
                }
                db.ImageCollaborations.Add(tp);
                db.SaveChanges();
                return RedirectToAction("edit", "Collaborations", new { id = id });
            }
            Display("une image doit être séléctionnée");
           // return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("edit", "Collaborations", new { id = id });
        }
        [HttpPost]
        public ActionResult UpLoadCv(HttpPostedFileBase file,int id)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    fileName = id + "-" + fileName;
                    string filePath = Path.Combine(Server.MapPath("~/Equipe"), fileName);
                    file.SaveAs(filePath);
                }
                Display( "Upload file successfully");                               
                return RedirectToAction("edit", "Collaborations", new { id = id });
            }
            catch
            {
                Display(" File is not saved");
                return RedirectToAction("edit", "Collaborations", new { id = id });
            }
        }
        private List<string> GetFiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/ "));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return items;
        }
        public FileResult DownLoad(string cvName, int id)
        {
            var fullPath = "~/Equipe/" +id+"-"+ cvName;
            return File(fullPath, "application/CV-Download", Path.GetFileName(fullPath));
        }


        // GET
        public ActionResult DeletePicture(int id, int idcollaboration)
        {
            ImageCollaboration image = db.ImageCollaborations.Find(id);
            db.ImageCollaborations.Remove(image);
            db.Entry(image).State = EntityState.Deleted;
            db.SaveChanges();
            // return Json(image);
            return RedirectToAction("Edit", "Collaborations", new { id = idcollaboration });
        }
        
    }
}
