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
    public class MizzaToppingStyleController : ApiController
    {
        private BunchMizza _bunchMizza;
        public MizzaToppingStyleController()
        {
            _bunchMizza = new BunchMizza();
        }
        // GET: api/MizzaToppingStyle
        public IEnumerable<MizzaToppingStyle> Get()
        {
            ModelState.Clear();
            var records = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaToppingStyle");
            var record = _bunchMizza.mizzaToppingStyles.GetDatas(records);
            return record;
        }

        // GET: api/MizzaToppingStyle/5
        public MizzaToppingStyle Get(string id)
        {
            ModelState.Clear();
            var datas = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaToppingStyle", id);

            var records = _bunchMizza.mizzaToppingStyles.GetDatas(datas);

            return records.First();
        }

        // POST: api/MizzaToppingStyle
        public void Post(string toppingStyleId, string toppingName)
        {
            if (ModelState.IsValid)
            {
                SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");
                MizzaToppingStyle mizzaToppingStyle = new MizzaToppingStyle() { ToppingStyleID = toppingStyleId,  ToppingName = toppingName };
                if (cvm.ExecCRUD(mizzaToppingStyle, "AddMizzaToppingStyle"))
                {
                    // Created
                }
            }
        }

        // PUT: api/MizzaToppingStyle/5
        public void Put(string id, MizzaToppingStyle mizzaToppingStyle)
        {
            if (ModelState.IsValid)
            {
                SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");

                if (cvm.ExecCRUD(mizzaToppingStyle, "UpdateMizzaToppingStyle"))
                {
                    // Updated
                }
            }
        }

        // DELETE: api/MizzaToppingStyle/5
        public void Delete(string id)
        {
            MizzaToppingStyle mizzaToppingStyle = new MizzaToppingStyle() { ToppingStyleID = id };
            ModelState.Clear();
            SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");

            if (cvm.ExecCRUD(mizzaToppingStyle, "DeleteMizzaToppingStyle"))
            {
                // Deleted
            }
        }
    }
}
