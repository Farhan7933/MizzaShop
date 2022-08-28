using Mizza.DataRepo;
using ADOMizzaAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ADOMizzaAPI.Repositories;

namespace ADOMizzaAPI.Controllers
{
    public class MizzaSizeController : ApiController
    {
        private IGenericRepository<MizzaSize> mizzaSizeRepository;
        public MizzaSizeController()
        {
            mizzaSizeRepository = new MizzaSizeRepostory();
        }
        // GET: api/MizzaSize
        public IEnumerable<MizzaSize> Get(int page, int limit)
        {
            var records = mizzaSizeRepository.FetchAllRecord(page, limit);
            return records;
        }

        // GET: api/MizzaSize/5
        public MizzaSize Get(string id)
        {
            var record = mizzaSizeRepository.FetchSingleRecord(id);
            return record;
        }

        // POST: api/MizzaSize
        public void Post(MizzaSize mizzaSize)
        {
            mizzaSizeRepository.CreateRecord(mizzaSize);
        }

        // PUT: api/MizzaSize/5
        public void Put(MizzaSize mizzaSize)
        {
            mizzaSizeRepository.UpdateRecord(mizzaSize);
        }

        // DELETE: api/MizzaSize/5
        public void Delete(string id)
        {
            mizzaSizeRepository.DeleteRecord(id);
        }
    }
}
