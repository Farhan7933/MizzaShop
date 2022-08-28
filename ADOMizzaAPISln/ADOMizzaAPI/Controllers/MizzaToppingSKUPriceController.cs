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
    public class MizzaToppingSKUPriceController : ApiController
    {
        private BunchMizza _bunchMizza;
        public MizzaToppingSKUPriceController()
        {
            _bunchMizza = new BunchMizza();
        }
        // GET: api/MizzaToppingSKUPrice
        public IEnumerable<MizzaToppingSKUPrice> Get()
        {
            ModelState.Clear();
            var records = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaToppingSKUPrice");
            var record = _bunchMizza.mizzaToppingSKUPrices.GetDatas(records);
            return record;
        }

        // GET: api/MizzaToppingSKUPrice/5
        public MizzaToppingSKUPrice Get(string skuId, string toppingStyleId)
        {
            ModelState.Clear();
            var datas = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaSize", skuId);

            var records = _bunchMizza.mizzaToppingSKUPrices.GetDatas(datas);

            return records.First();
        }

        // POST: api/MizzaToppingSKUPrice
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MizzaToppingSKUPrice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MizzaToppingSKUPrice/5
        public void Delete(int id)
        {
        }
    }
}
