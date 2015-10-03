using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageSandpit.Models;
using BookEngine;

namespace ImageSandpit.Controllers
{
    public class ImageSandpitController : Controller
    {

        public ActionResult HelloAction()
        {
            ImageCreator creator = new ImageCreator();
            ImageSandpitModel model = new ImageSandpitModel();
            model.Image1 = creator.GetImage();
            return View(model);
        }

        // GET: ImageSandpit
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageSandpit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageSandpit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageSandpit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageSandpit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImageSandpit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageSandpit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageSandpit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
