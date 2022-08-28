using APIConsumingIntoMVC.Models;
using APIConsumingIntoMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APIConsumingIntoMVC.Controllers
{
    public class MizzaSKUController : Controller
    {
        private BunchMizza _bunchMizza;
        public MizzaSKUController()
        {
            _bunchMizza = new BunchMizza();
        }
        // GET: MizzaSKU
        public async Task<ActionResult> Index()
        {
            List<MizzaSKU> mizzaSKUs = await Task.Run(() => _bunchMizza.mizzaSKUs.GetRecords("MizzaSKU"));
            return View(mizzaSKUs);
        }

        // GET: MizzaSKU/Details/5
        public async Task<ActionResult> Details(string id)
        {
            MizzaSKU mizzaSKU = await Task.Run(() => _bunchMizza.mizzaSKUs.GetRecord($"MizzaSKU/{id}"));
            return View(mizzaSKU);
        }

        // GET: MizzaSKU/Create
        public async Task<ActionResult> Create()
        {
            var mizzaSizes = await _bunchMizza.mizzaSizes.GetRecords("MizzaSize");
            var mizzaStyles = await _bunchMizza.mizzaStyles.GetRecords("MizzaStyle");

            ViewData["MizzaSizes"] = new SelectList(mizzaSizes, "MizzaSizeID", "MizzaSizeName");
            ViewData["MizzaStyles"] = new SelectList(mizzaStyles, "MizzaStyleID", "MizzaStyleName");
            return View();
        }

        // POST: MizzaSKU/Create
        [HttpPost]
        public async Task<ActionResult> Create(MizzaSKU mizzaSKU)
        {
            try
            {
                // TODO: Add insert logic here
                await Task.Run(() => APIRequests.CreateRecord(mizzaSKU, "MizzaSKU"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSKU/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            MizzaSKU mizzaSKU = await Task.Run(() => _bunchMizza.mizzaSKUs.GetRecord($"MizzaSKU/{id}"));
            return View(mizzaSKU);
        }

        // POST: MizzaSKU/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MizzaSKU mizzaSKU)
        {
            try
            {
                await Task.Run(() => APIRequests.UpdateRecord(mizzaSKU, "MizzaSKU"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSKU/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            MizzaSKU mizzaSKU = await Task.Run(() => _bunchMizza.mizzaSKUs.GetRecord($"MizzaSKU/{id}"));
            return View(mizzaSKU);
        }

        // POST: MizzaSKU/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, bool aiseHi = false)
        {
            try
            {
                await Task.Run(() => APIRequests.DeleteRecord($"MizzaSKU/{id}"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
