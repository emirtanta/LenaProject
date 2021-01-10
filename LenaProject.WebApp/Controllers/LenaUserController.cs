using LenaProject.BusinessLayer;
using LenaProject.Entities;
using LenaProject.WebApp.Filters;
using MyEvernote.BusinessLayer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LenaProject.WebApp.Controllers
{
    [Auth]
    [AuthAdmin]
    [Exc]
    public class LenaUserController : Controller
    {
        private LenaUserManager lenaUserManager = new LenaUserManager();


        public ActionResult Index()
        {
            return View(lenaUserManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LenaUser evernoteUser = lenaUserManager.Find(x => x.Id == id.Value);

            if (evernoteUser == null)
            {
                return HttpNotFound();
            }

            return View(evernoteUser);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LenaUser lenaUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<LenaUser> res = lenaUserManager.Insert(lenaUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(lenaUser);
                }

                return RedirectToAction("Index");
            }

            return View(lenaUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LenaUser lenaUser = lenaUserManager.Find(x => x.Id == id.Value);

            if (lenaUser == null)
            {
                return HttpNotFound();
            }

            return View(lenaUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LenaUser lenaUser)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                BusinessLayerResult<LenaUser> res = lenaUserManager.Update(lenaUser);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(lenaUser);
                }

                return RedirectToAction("Index");
            }
            return View(lenaUser);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LenaUser evernoteUser = lenaUserManager.Find(x => x.Id == id.Value);

            if (evernoteUser == null)
            {
                return HttpNotFound();
            }

            return View(evernoteUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LenaUser evernoteUser = lenaUserManager.Find(x => x.Id == id);
            lenaUserManager.Delete(evernoteUser);

            return RedirectToAction("Index");
        }
    }
}