using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace APIConsumingIntoMVC.Repository
{
    public static class APIRequests
    {
        static String _baseurl = "https://localhost:44331/api/";
        public static async Task<List<T>> GetRecords<T>(this T item, string request)
        {
            List<T> itemList = new List<T>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                HttpResponseMessage Res = await client.GetAsync(request);
                if (Res.IsSuccessStatusCode)
                {
                    itemList = Res.Content.ReadAsAsync<List<T>>().Result;
                }
            }

            return itemList;
        }

        public static async Task<T> GetRecord<T>(this T item, string request)  where T : new()
        {
            T record = new T();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                HttpResponseMessage Res = await client.GetAsync(request);
                if (Res.IsSuccessStatusCode)
                {
                    var mizzaResult = Res.Content.ReadAsAsync<T>();
                    record = mizzaResult.Result;
                }
            }

            return record;
        }

        public static async Task CreateRecord<T>(T record, string request)
        {
            var datas = JsonConvert.SerializeObject(record);
            StringContent stringContent = new StringContent(datas, UnicodeEncoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                HttpResponseMessage Res = await client.PostAsync(request, stringContent);
                if (Res.IsSuccessStatusCode)
                {
                    // Created
                }
            }
        }

        public static async void UpdateRecord<T>(T record, string request)
        {
            var datas = JsonConvert.SerializeObject(record);
            StringContent stringContent = new StringContent(datas, UnicodeEncoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                HttpResponseMessage Res = await client.PutAsync(request, stringContent);
                if (Res.IsSuccessStatusCode)
                {
                    // Updated
                }
            }
        }

        public static async void DeleteRecord(string request)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseurl);
                HttpResponseMessage Res = await client.DeleteAsync(request);
                if (Res.IsSuccessStatusCode)
                {
                    // Deleted
                }
            }
        }
    }
}