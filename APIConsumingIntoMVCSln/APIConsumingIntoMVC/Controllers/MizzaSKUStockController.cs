using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIConsumingIntoMVC.Controllers
{
    public class MizzaSKUStockController : Controller
    {
        // GET: MizzaSKUStock
        public ActionResult Index()
        {
            return View();
        }

        // GET: MizzaSKUStock/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MizzaSKUStock/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSKUStock/Create
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

        // GET: MizzaSKUStock/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MizzaSKUStock/Edit/5
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

        // GET: MizzaSKUStock/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSKUStock/Delete/5
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
