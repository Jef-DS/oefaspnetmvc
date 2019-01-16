using Microsoft.AspNetCore.Mvc;
using oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef2.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(String bestemming, decimal dagprijs, int aantaldagen, string heeftKorting)
        {
            Reis reis = new Reis { Bestemming = bestemming, DagPrijs = dagprijs, AantalDagen = aantaldagen, HeeftKorting = heeftKorting=="on"?true:false };
            return View("resultaat", reis);
        }
    }
}
