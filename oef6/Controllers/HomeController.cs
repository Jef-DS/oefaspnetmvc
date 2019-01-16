using Microsoft.AspNetCore.Mvc;
using oef6.Model;
using oef6.Services;
using oef6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef6.Controllers
{
    public class HomeController : Controller
    {
        private PersoonRepository _repo;
        public HomeController(PersoonRepository repo)
        {
            this._repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List()
        {
            PersoonViewModel vm = new PersoonViewModel();
            vm.Persoon = new Persoon();
            vm.Personen = new List<Persoon>(_repo);
            return View(vm);
        }

        public IActionResult Create(PersoonViewModel vm)
        {
            Persoon nieuwePersoon = vm.Persoon;
            _repo.Add(nieuwePersoon);
            return RedirectToAction(nameof(List));
        }
    }
}
