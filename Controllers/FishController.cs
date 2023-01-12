using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Controllers
{
    public class FishController : Controller
    {
        private readonly prkontekt _context;

        public FishController(prkontekt context)
        {
            _context = context;
        }

        // GET: Fish
        public async Task<IActionResult> Index()
        {
            var prkontekt = _context.Ryby.Include(f => f.Gatunek).Include(f => f.Zbiornik).Include(f => f.Zbiornik.Okreg);
            return View(await prkontekt.ToListAsync());
        }

        // GET: Fish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ryby == null)
            {
                return NotFound();
            }

            var fish = await _context.Ryby
                .Include(f => f.Gatunek)
                .Include(f => f.Zbiornik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // GET: Fish/Create
        public IActionResult Create()
        {
            ViewData["GatunekId"] = new SelectList(_context.Gatunek, "Id", "Gatuenk");
            ViewData["ZbiornikId"] = new SelectList(_context.Zbiornik, "Id", "nazwa");
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data_z,Waga,Rozmiar,GatunekId,ZbiornikId")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GatunekId"] = new SelectList(_context.Gatunek, "Id", "Gatuenk", fish.GatunekId);
            ViewData["ZbiornikId"] = new SelectList(_context.Zbiornik, "Id", "nazwa", fish.ZbiornikId);
            return View(fish);
        }

        // GET: Fish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ryby == null)
            {
                return NotFound();
            }

            var fish = await _context.Ryby.FindAsync(id);
            if (fish == null)
            {
                return NotFound();
            }
            ViewData["GatunekId"] = new SelectList(_context.Gatunek, "Id", "Gatuenk", fish.GatunekId);
            ViewData["ZbiornikId"] = new SelectList(_context.Zbiornik, "Id", "nazwa", fish.ZbiornikId);
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data_z,Waga,Rozmiar,GatunekId,ZbiornikId")] Fish fish)
        {
            if (id != fish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishExists(fish.Id))
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
            ViewData["GatunekId"] = new SelectList(_context.Gatunek, "Id", "Gatuenk", fish.GatunekId);
            ViewData["ZbiornikId"] = new SelectList(_context.Zbiornik, "Id", "nazwa", fish.ZbiornikId);
            return View(fish);
        }

        // GET: Fish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ryby == null)
            {
                return NotFound();
            }

            var fish = await _context.Ryby
                .Include(f => f.Gatunek)
                .Include(f => f.Zbiornik)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }

            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ryby == null)
            {
                return Problem("Entity set 'prkontekt.Ryby'  is null.");
            }
            var fish = await _context.Ryby.FindAsync(id);
            if (fish != null)
            {
                _context.Ryby.Remove(fish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishExists(int id)
        {
          return (_context.Ryby?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
