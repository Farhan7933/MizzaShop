using APIConsumingIntoMVC.Models;
using APIConsumingIntoMVC.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APIConsumingIntoMVC.Controllers
{
    public class MizzaSizeController : Controller
    {
        private BunchMizza _bunchMizza;
        public MizzaSizeController()
        {
            _bunchMizza = new BunchMizza();
            ViewBag.PageNumber = 0;
        }
        // GET: MizzaSize
        public async Task<ActionResult> Index(int page = 0, int limit = 3)
        {
            List<MizzaSize> mizzaSizes =  await _bunchMizza.mizzaSizes.GetRecords($"MizzaSize?page={page}&limit={limit}");
            if(mizzaSizes.Count == limit)
            {
                ViewBag.NextPageNo = page + 1;
            }
            if(page > 0)
            {
                ViewBag.PrevPageNo = page - 1;
            }
            return View(mizzaSizes);
        }

        public async Task<ActionResult> FilteredItem(string option, string id)
        {
            List<MizzaSize> mizzaSizes = new List<MizzaSize>();
            if(id == null || id == "")
            {
                return View(mizzaSizes);
            }

            if(option == "MizzaSizeID")
            {
                MizzaSize mizzaSize = await _bunchMizza.mizzaSizes.GetRecord($"MizzaSize/{id}");
                mizzaSizes.Add(mizzaSize);
            }

            return View(mizzaSizes);
        }

        // GET: MizzaSize/Details/5
        public async Task<ActionResult> Details(string id)
        {
            MizzaSize mizzaSize = await Task.Run(() => _bunchMizza.mizzaSizes.GetRecord($"MizzaSize/{id}"));
            return View(mizzaSize);
        }

        // GET: MizzaSize/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: MizzaSize/Create
        [HttpPost]
        public async Task<ActionResult> Create(MizzaSize mizzaSize)
        {
            try
            {
                await APIRequests.CreateRecord(mizzaSize, "MizzaSize");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSize/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            MizzaSize mizzaSize = await _bunchMizza.mizzaSizes.GetRecord($"MizzaSize/{id}");
            return View(mizzaSize);
        }

        // POST: MizzaSize/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(MizzaSize mizzaSize)
        {
            try
            {
                await Task.Run(() => APIRequests.UpdateRecord(mizzaSize, "MizzaSize"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MizzaSize/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            MizzaSize mizzaSize = await Task.Run(() => _bunchMizza.mizzaSizes.GetRecord($"MizzaSize/{id}"));
            return View(mizzaSize);
        }

        // POST: MizzaSize/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id, bool aiseHi = false)
        {
            try
            {
                await Task.Run(() => APIRequests.DeleteRecord($"MizzaSize/{id}"));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
