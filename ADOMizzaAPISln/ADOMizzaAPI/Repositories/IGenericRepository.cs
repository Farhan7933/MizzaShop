using ADOMizzaAPI.Models;
using Mizza.DataRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADOMizzaAPI.Repositories
{
    public interface IGenericRepository<T>
    {
        T FetchSingleRecord(string id);
        //List<T> FetchAllRecord();
        List<T> FetchAllRecord(int limit, int offset);
        void CreateRecord(T record);
        void UpdateRecord(T record);
        void DeleteRecord(string id);
    }

    public class MizzaSizeRepostory : IGenericRepository<MizzaSize>
    {
        private SqlCommandViewModel _sqlCommandViewModel;
        private BunchMizza _bunchMizza;
        public MizzaSizeRepostory()
        {
            _bunchMizza = new BunchMizza();
            _sqlCommandViewModel = new SqlCommandViewModel("MizzaNextItems");
        }
        public MizzaSize FetchSingleRecord(string id)
        {
            var datas = _sqlCommandViewModel.GetRecords("GetMizzaSize", id);
            var records = _bunchMizza.mizzaSizes.GetDatas(datas);
            return records.First();
        }
        public List<MizzaSize> FetchAllRecord(int page, int limit)
        {
            var datas = _sqlCommandViewModel.GetRecords("GetMizzaSize", page, limit);
            var records = _bunchMizza.mizzaSizes.GetDatas(datas);
            return records;
        }
        public void CreateRecord(MizzaSize mizzaSize)
        {
            _sqlCommandViewModel.ExecCRUD(mizzaSize, "AddMizzaSize");
        }

        public void UpdateRecord(MizzaSize mizzaSize)
        {
            _sqlCommandViewModel.ExecCRUD(mizzaSize, "UpdateMizzaSize");
        }

        public void DeleteRecord(string id)
        {
            MizzaSize mizzaSize = new MizzaSize() { MizzaSizeID = id };
            _sqlCommandViewModel.ExecCRUD(mizzaSize, "DeleteMizzaSize");
        }
    }
}