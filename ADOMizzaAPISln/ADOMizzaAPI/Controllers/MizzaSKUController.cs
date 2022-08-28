using ADOMizzaAPI.Models;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADOMizzaAPI.Controllers
{
    public class MizzaSKUController : ApiController
    {
        private BunchMizza _bunchMizza;
        public MizzaSKUController()
        {
            _bunchMizza = new BunchMizza();
        }
        // GET: api/MizzaSKU
        public IEnumerable<MizzaSKU> Get()
        {
            ModelState.Clear();
            var records = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaSKU");
            var record = _bunchMizza.mizzaSKUs.GetDatas(records);
            return record;
        }

        // GET: api/MizzaSKU/5
        public MizzaSKU Get(string id)
        {
            MizzaSKU mizzaSKU = new MizzaSKU() { MizzaSKUID = id };
            ModelState.Clear();
            var datas = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaSKU", id);

            var records = _bunchMizza.mizzaSKUs.GetDatas(datas);

            return records.First();
        }

        // POST: api/MizzaSKU
        public void Post(MizzaSKU mizzaSKU)
        {
            if (ModelState.IsValid)
            {
                SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");
                if (cvm.ExecCRUD(mizzaSKU, "AddMizzaSKU"))
                {
                    // Created
                }
            }
        }

        // PUT: api/MizzaSKU/5
        public void Put(string id, MizzaSKU mizzaSKU)
        {
            if (ModelState.IsValid)
            {
                SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");

                if (cvm.ExecCRUD(mizzaSKU, "UpdateMizzaSKU"))
                {
                    // Updated
                }
            }
        }

        // DELETE: api/MizzaSKU/5
        public void Delete(string id)
        {
            MizzaSKU mizzaSize = new MizzaSKU() { MizzaSKUID = id };
            ModelState.Clear();
            SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");

            if (cvm.ExecCRUD(mizzaSize, "DeleteMizzaSKU"))
            {
                // Deleted
            }
        }
    }
}
