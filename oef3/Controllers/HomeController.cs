using Microsoft.AspNetCore.Mvc;
using oef3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef3.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            Reis reis = new Reis
            {
                StartDatum = DateTime.Today,
                EindDatum = DateTime.Today
            };
            return View(reis);
        }
        [HttpPost]
        public ViewResult Index(Reis reis)
        {
            return View("resultaat", reis);
        }
    }
}
