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
    public class UniversityInfoesController : Controller
    {
        private readonly uniPlannerContext _context;

        public UniversityInfoesController(uniPlannerContext context)
        {
            _context = context;
        }

        // GET: UniversityInfoes
        public async Task<IActionResult> Index()
        {
              return _context.UniversityInfo != null ? 
                          View(await _context.UniversityInfo.ToListAsync()) :
                          Problem("Entity set 'uniPlannerContext.UniversityInfo'  is null.");
        }

        // GET: UniversityInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UniversityInfo == null)
            {
                return NotFound();
            }

            var universityInfo = await _context.UniversityInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universityInfo == null)
            {
                return NotFound();
            }

            return View(universityInfo);
        }

        // GET: UniversityInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniversityInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,City,Region,THErank,QSrank,ARWUrank")] UniversityInfo universityInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universityInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universityInfo);
        }

        // GET: UniversityInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UniversityInfo == null)
            {
                return NotFound();
            }

            var universityInfo = await _context.UniversityInfo.FindAsync(id);
            if (universityInfo == null)
            {
                return NotFound();
            }
            return View(universityInfo);
        }

        // POST: UniversityInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,City,Region,THErank,QSrank,ARWUrank")] UniversityInfo universityInfo)
        {
            if (id != universityInfo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universityInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityInfoExists(universityInfo.ID))
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
            return View(universityInfo);
        }

        // GET: UniversityInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UniversityInfo == null)
            {
                return NotFound();
            }

            var universityInfo = await _context.UniversityInfo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universityInfo == null)
            {
                return NotFound();
            }

            return View(universityInfo);
        }

        // POST: UniversityInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UniversityInfo == null)
            {
                return Problem("Entity set 'uniPlannerContext.UniversityInfo'  is null.");
            }
            var universityInfo = await _context.UniversityInfo.FindAsync(id);
            if (universityInfo != null)
            {
                _context.UniversityInfo.Remove(universityInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityInfoExists(int id)
        {
          return (_context.UniversityInfo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
