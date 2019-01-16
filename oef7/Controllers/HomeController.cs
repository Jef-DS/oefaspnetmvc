using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oef7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Controllers
{
    public class HomeController:Controller
    {
        private readonly SchoolDbContext _context;
        public HomeController(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<ViewResult> Index()
        {
            ViewBag.AantalCursisten = await _context.Cursisten.CountAsync();
            ViewBag.AantalCursussen = await _context.Cursussen.CountAsync();
            ViewBag.AantalInschrijvingen = await _context.Inschrijvingen.CountAsync();
            return View();
        }
    }
}
