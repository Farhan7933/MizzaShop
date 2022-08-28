using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIConsumingIntoMVC.Controllers
{
    public class MizzaSkuBasePriceController : Controller
    {
        // GET: MizzaSkuBasePrice
        public ActionResult Index()
        {
            return View();
        }

        // GET: MizzaSkuBasePrice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MizzaSkuBasePrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSkuBasePrice/Create
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

        // GET: MizzaSkuBasePrice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MizzaSkuBasePrice/Edit/5
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

        // GET: MizzaSkuBasePrice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSkuBasePrice/Delete/5
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
