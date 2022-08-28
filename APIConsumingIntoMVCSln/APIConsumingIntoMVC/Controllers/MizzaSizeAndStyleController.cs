using APIConsumingIntoMVC.Models;
using APIConsumingIntoMVC.Repository;
using APIConsumingIntoMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APIConsumingIntoMVC.Controllers
{
    public class MizzaSizeAndStyleController : Controller
    {
        private BunchMizza _bunchMizza;
        public MizzaSizeAndStyleController()
        {
            _bunchMizza = new BunchMizza();
        }
        // GET: MizzaSizeAndStyle
        public async Task<ActionResult> Index()
        {
            MizzaSizeAndStyle mizzaSizeAndStyle = new MizzaSizeAndStyle();
            mizzaSizeAndStyle.mizzaSizes = await _bunchMizza.mizzaSizes.GetRecords("MizzaSize");
            mizzaSizeAndStyle.mizzaStyles = await _bunchMizza.mizzaStyles.GetRecords("MizzaStyle");

            return View(mizzaSizeAndStyle);
        }

        // GET: MizzaSizeAndStyle/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MizzaSizeAndStyle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MizzaSizeAndStyle/Create
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

        // GET: MizzaSizeAndStyle/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MizzaSizeAndStyle/Edit/5
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

        // GET: MizzaSizeAndStyle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MizzaSizeAndStyle/Delete/5
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
