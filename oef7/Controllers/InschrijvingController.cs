using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using oef7.Model;

namespace oef7.Controllers
{
    public class InschrijvingController : Controller
    {
        private readonly SchoolDbContext _context;

        public InschrijvingController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: Inschrijving
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.Inschrijvingen.Include(i => i.Cursist).Include(i => i.Cursus);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: Inschrijving/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.Cursist)
                .Include(i => i.Cursus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // GET: Inschrijving/Create
        public IActionResult Create()
        {
            ViewData["CursistId"] = new SelectList(_context.Cursisten, "Id", "Naam");
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Naam");
            return View();
        }

        // POST: Inschrijving/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CursusId,CursistId,punten")] Inschrijving inschrijving)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inschrijving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CursistId = new SelectList(_context.Cursisten, "Id", "Voornaam", inschrijving.CursistId);
            ViewBag.CursusId = new SelectList(_context.Cursussen, "Id", "Naam", inschrijving.CursusId);
            return View(inschrijving);
        }

        // GET: Inschrijving/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            if (inschrijving == null)
            {
                return NotFound();
            }
            ViewData["CursistId"] = new SelectList(_context.Cursisten, "Id", "Naam", inschrijving.CursistId);
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Naam", inschrijving.CursusId);
            return View(inschrijving);
        }

        // POST: Inschrijving/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CursusId,CursistId,punten")] Inschrijving inschrijving)
        {
            if (id != inschrijving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inschrijving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InschrijvingExists(inschrijving.Id))
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
            ViewData["CursistId"] = new SelectList(_context.Cursisten, "Id", "Achternaam", inschrijving.CursistId);
            ViewData["CursusId"] = new SelectList(_context.Cursussen, "Id", "Naam", inschrijving.CursusId);
            return View(inschrijving);
        }

        // GET: Inschrijving/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inschrijving = await _context.Inschrijvingen
                .Include(i => i.Cursist)
                .Include(i => i.Cursus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inschrijving == null)
            {
                return NotFound();
            }

            return View(inschrijving);
        }

        // POST: Inschrijving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inschrijving = await _context.Inschrijvingen.FindAsync(id);
            _context.Inschrijvingen.Remove(inschrijving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InschrijvingExists(int id)
        {
            return _context.Inschrijvingen.Any(e => e.Id == id);
        }
    }
}
