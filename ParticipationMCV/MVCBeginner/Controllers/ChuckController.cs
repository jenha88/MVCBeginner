﻿using MVCBeginner.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCBeginner.Controllers
{
    public class ChuckController : Controller
    {
        // GET: Chuck
        public ActionResult Index()
        {
            RandomChuckJoke joke;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;

                joke = JsonConvert.DeserializeObject<RandomChuckJoke>(json);
            }

            return View(joke);
        }
    }
}