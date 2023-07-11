using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using uniPlanner.Areas.Identity.Data;
using uniPlanner.Models;

namespace uniPlanner.Controllers
{
    public class ProgrammesController : Controller
    {
        private readonly uniPlannerContext _context;

        public ProgrammesController(uniPlannerContext context)
        {
            _context = context;
        }

        // GET: Programmes
        public async Task<IActionResult> Index()
        {
              return _context.Programmes != null ? 
                          View(await _context.Programmes.ToListAsync()) :
                          Problem("Entity set 'uniPlannerContext.Programmes'  is null.");
        }

        // GET: Programmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Programmes == null)
            {
                return NotFound();
            }

            var programmes = await _context.Programmes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (programmes == null)
            {
                return NotFound();
            }

            return View(programmes);
        }

        // GET: Programmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Programmes programmes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programmes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programmes);
        }

        // GET: Programmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Programmes == null)
            {
                return NotFound();
            }

            var programmes = await _context.Programmes.FindAsync(id);
            if (programmes == null)
            {
                return NotFound();
            }
            return View(programmes);
        }

        // POST: Programmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Programmes programmes)
        {
            if (id != programmes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programmes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammesExists(programmes.ID))
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
            return View(programmes);
        }

        // GET: Programmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Programmes == null)
            {
                return NotFound();
            }

            var programmes = await _context.Programmes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (programmes == null)
            {
                return NotFound();
            }

            return View(programmes);
        }

        // POST: Programmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Programmes == null)
            {
                return Problem("Entity set 'uniPlannerContext.Programmes'  is null.");
            }
            var programmes = await _context.Programmes.FindAsync(id);
            if (programmes != null)
            {
                _context.Programmes.Remove(programmes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammesExists(int id)
        {
          return (_context.Programmes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
