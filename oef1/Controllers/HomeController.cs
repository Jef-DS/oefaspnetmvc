using Microsoft.AspNetCore.Mvc;
using oef1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef1.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(int getal1, int getal2)
        {
            Rekenmachine rekenmachine = new Rekenmachine { Getal1 = getal1, Getal2 = getal2};
            return View("resultaat", rekenmachine);
        }
    }
}
