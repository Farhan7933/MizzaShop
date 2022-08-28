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
    public class MizzaStyleController : ApiController
    {
        private BunchMizza _bunchMizza;
        public MizzaStyleController()
        {
            _bunchMizza = new BunchMizza();
        }
        // GET: api/MizzaStyle
        public IEnumerable<MizzaStyle> Get()
        {
            ModelState.Clear();
            var records = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaStyle");
            var record = _bunchMizza.mizzaStyles.GetDatas(records);
            return record;
        }

        // GET: api/MizzaStyle/5
        public MizzaStyle Get(string id)
        {
            ModelState.Clear();
            var datas = new SqlCommandViewModel("MizzaNextItems").GetRecords("GetMizzaStyle", id);

            var records = _bunchMizza.mizzaStyles.GetDatas(datas);

            return records.First();
        }

        // POST: api/MizzaStyle
        public void Post(string mizzaStyleId, string mizzaStyleName)
        {
            if (ModelState.IsValid)
            {
                SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");
                MizzaStyle mizzaStyle = new MizzaStyle() { MizzaStyleID = mizzaStyleId, MizzaStyleName = mizzaStyleName };
                if (cvm.ExecCRUD(mizzaStyle, "AddMizzaStyle"))
                {
                    // Created
                }
            }
        }

        // PUT: api/MizzaStyle/5
        public void Put(string id, MizzaStyle mizzaStyle)
        {
            if (ModelState.IsValid)
            {
                SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");

                if (cvm.ExecCRUD(mizzaStyle, "UpdateMizzaStyle"))
                {
                    // Updated
                }
            }
        }

        // DELETE: api/MizzaStyle/5
        public void Delete(string id)
        {
            MizzaStyle mizzaStyle = new MizzaStyle() { MizzaStyleID = id };
            ModelState.Clear();
            SqlCommandViewModel cvm = new SqlCommandViewModel("MizzaNextItems");

            if (cvm.ExecCRUD(mizzaStyle, "DeleteMizzaSize"))
            {
                // Deleted
            }
        }
    }
}
