using ADOMizzaAPI.Models;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace ADOMizzaAPI.CRUD
{
    public class ExecuteCRUD
    {
        private BunchMizza _bunchMizza;
        public ExecuteCRUD()
        {
            _bunchMizza = new BunchMizza();
        }

        //public IEnumerable<T> FetchAllRecord<T>(T item, string dBName, string sp)
        //{
        //    ModelState.Clear();
        //    var records = new SqlCommandViewModel(dBName).GetRecords(sp);
        //    var record = item.GetDatas(records);
        //    return record;
        //}
    }
}