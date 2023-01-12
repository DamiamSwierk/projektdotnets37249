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
    public class SpeciesController : Controller
    {
        private readonly prkontekt _context;

        public SpeciesController(prkontekt context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
              return _context.Gatunek != null ? 
                          View(await _context.Gatunek.ToListAsync()) :
                          Problem("Entity set 'prkontekt.Gatunek'  is null.");
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gatunek == null)
            {
                return NotFound();
            }

            var specie = await _context.Gatunek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Gatuenk")] Specie specie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specie);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gatunek == null)
            {
                return NotFound();
            }

            var specie = await _context.Gatunek.FindAsync(id);
            if (specie == null)
            {
                return NotFound();
            }
            return View(specie);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Gatuenk")] Specie specie)
        {
            if (id != specie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecieExists(specie.Id))
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
            return View(specie);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gatunek == null)
            {
                return NotFound();
            }

            var specie = await _context.Gatunek
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gatunek == null)
            {
                return Problem("Entity set 'prkontekt.Gatunek'  is null.");
            }
            var specie = await _context.Gatunek.FindAsync(id);
            if (specie != null)
            {
                _context.Gatunek.Remove(specie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecieExists(int id)
        {
          return (_context.Gatunek?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
