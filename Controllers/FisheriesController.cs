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
    public class FisheriesController : Controller
    {
        private readonly prkontekt _context;

        public FisheriesController(prkontekt context)
        {
            _context = context;
        }

        // GET: Fisheries
        public async Task<IActionResult> Index()
        {
            var prkontekt = _context.Zbiornik.Include(f => f.Okreg);
            return View(await prkontekt.ToListAsync());
        }

        // GET: Fisheries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zbiornik == null)
            {
                return NotFound();
            }

            var fishery = await _context.Zbiornik
                .Include(f => f.Okreg)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishery == null)
            {
                return NotFound();
            }

            return View(fishery);
        }

        // GET: Fisheries/Create
        public IActionResult Create()
        {
            ViewData["OkregId"] = new SelectList(_context.Okreg, "Id", "nazwa");
            return View();
        }

        // POST: Fisheries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nazwa,OkregId")] Fishery fishery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OkregId"] = new SelectList(_context.Okreg, "Id", "Id", fishery.OkregId);
            return View(fishery);
        }

        // GET: Fisheries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zbiornik == null)
            {
                return NotFound();
            }

            var fishery = await _context.Zbiornik.FindAsync(id);
            if (fishery == null)
            {
                return NotFound();
            }
            ViewData["OkregId"] = new SelectList(_context.Okreg, "Id", "nazwa", fishery.OkregId);
            return View(fishery);
        }

        // POST: Fisheries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nazwa,OkregId")] Fishery fishery)
        {
            if (id != fishery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FisheryExists(fishery.Id))
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
            ViewData["OkregId"] = new SelectList(_context.Okreg, "Id", "Id", fishery.OkregId);
            return View(fishery);
        }

        // GET: Fisheries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zbiornik == null)
            {
                return NotFound();
            }

            var fishery = await _context.Zbiornik
                .Include(f => f.Okreg)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fishery == null)
            {
                return NotFound();
            }

            return View(fishery);
        }

        // POST: Fisheries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zbiornik == null)
            {
                return Problem("Entity set 'prkontekt.Zbiornik'  is null.");
            }
            var fishery = await _context.Zbiornik.FindAsync(id);
            if (fishery != null)
            {
                _context.Zbiornik.Remove(fishery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FisheryExists(int id)
        {
          return (_context.Zbiornik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
