using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oef7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oef7.Controllers
{
    public class CursistController:Controller
    {
        private readonly SchoolDbContext context;

        public CursistController(SchoolDbContext context)
        {
            this.context = context;
        }
        public async Task<ViewResult> Index()
        {
            return View(await context.Cursisten.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var cursist = await context.Cursisten
                .Include(c => c.Inschrijvingen)
                .ThenInclude(i => i.Cursus)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cursist == null) return NotFound();
            return View(cursist);
        }
        public ViewResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cursist cursist)
        {
            if (ModelState.IsValid)
            {
                context.Add(cursist);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursist);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var cursist = await context.Cursisten.SingleOrDefaultAsync(c => c.Id == id);
            if (cursist == null) return NotFound();
            return View(cursist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cursist cursist)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(cursist);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await CursistExists(cursist.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cursist);
        }
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null) return NotFound();
            var cursist = await context.Cursisten.SingleOrDefaultAsync(c => c.Id == id);
            if (cursist == null) return NotFound();
            return View(cursist);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BevestigDelete(int id)
        {
            var cursist = await context.Cursisten.SingleOrDefaultAsync(c => c.Id == id);
            context.Cursisten.Remove(cursist);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> CursistExists(int id) => await context.Cursisten.AnyAsync(c => c.Id == id);
    }
}
