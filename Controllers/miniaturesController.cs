using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.databaseClasses;

namespace MVC.Controllers
{
    public class miniaturesController : Controller
    {
        private readonly applicationDbContext _context;

        public miniaturesController(applicationDbContext context)
        {
            _context = context;
        }

        // GET: miniatures
        public async Task<IActionResult> Index()
        {
              return _context.Miniatures != null ? 
                          View(await _context.Miniatures.ToListAsync()) :
                          Problem("Entity set 'applicationDbContext.Miniatures'  is null.");
        }

        // GET: miniatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Miniatures == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniature == null)
            {
                return NotFound();
            }

            return View(miniature);
        }

        // GET: miniatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: miniatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,databaseReady,Temp,Pressure,Humidity,TempMin,TempMax")] miniature miniature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miniature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miniature);
        }

        // GET: miniatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Miniatures == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures.FindAsync(id);
            if (miniature == null)
            {
                return NotFound();
            }
            return View(miniature);
        }

        // POST: miniatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,databaseReady,Temp,Pressure,Humidity,TempMin,TempMax")] miniature miniature)
        {
            if (id != miniature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miniature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!miniatureExists(miniature.Id))
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
            return View(miniature);
        }

        // GET: miniatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Miniatures == null)
            {
                return NotFound();
            }

            var miniature = await _context.Miniatures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miniature == null)
            {
                return NotFound();
            }

            return View(miniature);
        }

        // POST: miniatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Miniatures == null)
            {
                return Problem("Entity set 'applicationDbContext.Miniatures'  is null.");
            }
            var miniature = await _context.Miniatures.FindAsync(id);
            if (miniature != null)
            {
                _context.Miniatures.Remove(miniature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool miniatureExists(int id)
        {
          return (_context.Miniatures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
