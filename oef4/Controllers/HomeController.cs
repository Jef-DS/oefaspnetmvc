using Microsoft.AspNetCore.Mvc;
using oef4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef4.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            PersoonViewModel vm = new PersoonViewModel();
            vm.NieuwePersoon = new Persoon();
            vm.NieuwePersoon.GeboorteDatum = DateTime.Today;
            return View(vm);
        }
        [HttpPost]
        public ViewResult Index(PersoonViewModel p)
        {
            if (p.NieuwePersoon.GeboorteDatum.Date > DateTime.Today)
            {
                ModelState.AddModelError(nameof(p.NieuwePersoon.GeboorteDatum), "Men kan niet in de toekomst geboren zijn");
            }
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                p.VorigePersoon = p.NieuwePersoon;
                p.NieuwePersoon = new Persoon();
                p.NieuwePersoon.Naam = "";
                p.NieuwePersoon.GeboorteDatum = DateTime.Today;
                return View(p);
            }
            else
            {
                return View();
            }
        }
    }
}
