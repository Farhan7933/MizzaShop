﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace APIConsumingIntoMVC.Repository
{
    public class GlobalContext
    {
        public static HttpClient WeClient = new HttpClient();

        static GlobalContext()
        {
            //Put your API URL here(For it Rightclick on API Project -> properties -> web -> Copy the projectURL)
            WeClient.BaseAddress = new Uri("https://localhost:44331/api/");
            WeClient.DefaultRequestHeaders.Clear();
            WeClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            WeClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        }
    }
}