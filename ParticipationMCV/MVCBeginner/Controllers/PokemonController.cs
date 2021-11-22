using MVCBeginner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using static MVCBeginner.Models.PokemonInformation;

namespace MVCBeginner.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public ActionResult Index()
        {
            PokemonAPI pokie;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1100").Result;

                 pokie = JsonConvert.DeserializeObject<PokemonAPI>(json);
            }

            return View(pokie.results);
        }
        public ActionResult Info(string id)
        {
           
            PokemonInfo info;

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}").Result;
                info = JsonConvert.DeserializeObject<PokemonInfo>(jsonData);
            }

            return View(info);
        }
}