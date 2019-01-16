using Microsoft.AspNetCore.Mvc;
using oef5.Models;
using oef5.Services;
using oef5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef5.Controllers
{
    public class HomeController:Controller
    {
        private readonly BestellingService bestellingService;
        private readonly WinkelService winkelService;
        public HomeController(BestellingService bestellingService, WinkelService winkelService)
        {
            this.bestellingService = bestellingService;
            this.winkelService = winkelService;
        }
        public ViewResult Index()
        {
            BestellingViewModel vm = new BestellingViewModel();
            vm.Producten = new List<Product>(winkelService);
            WinkelWagen wagen = bestellingService.GetWinkelWagen();
            vm.Bestellingen = new List<BesteldProduct>(wagen.GetProducten());
            vm.TotaalPrijs = wagen.TotaalPrijs;
            return View(vm);
        }
        [HttpPost]
        public RedirectToActionResult Index(BestellingViewModel vm)
        {
            Product besteldProduct = winkelService.GetProduct(vm.BesteldProduct);
            int aantal = vm.Aantal;
            WinkelWagen wagen = bestellingService.GetWinkelWagen();
            wagen.AddProduct(besteldProduct, aantal);
            bestellingService.BewaarWinkelWagen(wagen);
            return RedirectToAction(nameof(Index));
        }
    }
}
