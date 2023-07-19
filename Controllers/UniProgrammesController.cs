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
    public class UniProgrammesController : Controller
    {
        private readonly uniPlannerContext _context;

        public UniProgrammesController(uniPlannerContext context)
        {
            _context = context;
        }

        // GET: UniProgramme
        public async Task<IActionResult> Index()
        {
              return _context.UniProgrammes != null ? 
                          View(await _context.UniProgrammes.ToListAsync()) :
                          Problem("Entity set 'uniPlannerContext.UniProgrammes'  is null.");
        }

        // GET: UniProgramme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniProgrammes == null)
            {
                return NotFound();
            }

            var uniProgrammes = await _context.UniProgrammes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uniProgrammes == null)
            {
                return NotFound();
            }

            return View(uniProgrammes);
        }

        // GET: UniProgramme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniProgramme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Link,RankScore")] UniProgrammes uniProgrammes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uniProgrammes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uniProgrammes);
        }

        // GET: UniProgramme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniProgrammes == null)
            {
                return NotFound();
            }

            var uniProgrammes = await _context.UniProgrammes.FindAsync(id);
            if (uniProgrammes == null)
            {
                return NotFound();
            }
            return View(uniProgrammes);
        }

        // POST: UniProgramme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Link,RankScore")] UniProgrammes uniProgrammes)
        {
            if (id != uniProgrammes.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uniProgrammes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniProgrammesExists(uniProgrammes.ID))
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
            return View(uniProgrammes);
        }

        // GET: UniProgramme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniProgrammes == null)
            {
                return NotFound();
            }

            var uniProgrammes = await _context.UniProgrammes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uniProgrammes == null)
            {
                return NotFound();
            }

            return View(uniProgrammes);
        }

        // POST: UniProgramme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniProgrammes == null)
            {
                return Problem("Entity set 'uniPlannerContext.UniProgrammes'  is null.");
            }
            var uniProgrammes = await _context.UniProgrammes.FindAsync(id);
            if (uniProgrammes != null)
            {
                _context.UniProgrammes.Remove(uniProgrammes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniProgrammesExists(int id)
        {
          return (_context.UniProgrammes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
