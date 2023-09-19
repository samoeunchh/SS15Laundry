using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS15Laundry.Data;
using SS15Laundry.Models;

namespace SS15Laundry.Controllers
{
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Position
        public async Task<IActionResult> Index()
        {
              return _context.Position != null ? 
                          View(await _context.Position.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Position'  is null.");
        }

        // GET: Position/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Position/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionId,PositionName")] Position position)
        {
            if (ModelState.IsValid)
            {
                position.PositionId = Guid.NewGuid();
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: Position/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }

            var position = await _context.Position.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PositionId,PositionName")] Position position)
        {
            if (id != position.PositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.PositionId))
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
            return View(position);
        }

        // GET: Position/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Position == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Position == null)
            {
                return Problem("Entity set 'AppDbContext.Position'  is null.");
            }
            var position = await _context.Position.FindAsync(id);
            if (position != null)
            {
                _context.Position.Remove(position);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(Guid id)
        {
          return (_context.Position?.Any(e => e.PositionId == id)).GetValueOrDefault();
        }
    }
}
