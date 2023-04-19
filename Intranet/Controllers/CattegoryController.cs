using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Data.Data.Shop;

namespace Intranet.Controllers
{
    public class CattegoryController : BaseController
    {
        public CattegoryController(ApplicationDbContext context)
            :base(context)
        {
        }

        // GET: Cattegory
        public async Task<IActionResult> Index()
        {
            ViewBag.Messages = base.GetNewMessages();
            return _context.Cattegory != null ? 
                          View(await _context.Cattegory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cattegory'  is null.");
        }

        // GET: Cattegory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Cattegory == null)
            {
                return NotFound();
            }

            var cattegory = await _context.Cattegory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattegory == null)
            {
                return NotFound();
            }

            return View(cattegory);
        }

        // GET: Cattegory/Create
        public IActionResult Create()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View();
        }

        // POST: Cattegory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreationDate,IsActive")] Cattegory cattegory)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (ModelState.IsValid)
            {
                _context.Add(cattegory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cattegory);
        }

        // GET: Cattegory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Cattegory == null)
            {
                return NotFound();
            }

            var cattegory = await _context.Cattegory.FindAsync(id);
            if (cattegory == null)
            {
                return NotFound();
            }
            return View(cattegory);
        }

        // POST: Cattegory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreationDate,IsActive")] Cattegory cattegory)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id != cattegory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cattegory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CattegoryExists(cattegory.Id))
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
            return View(cattegory);
        }

        // GET: Cattegory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Cattegory == null)
            {
                return NotFound();
            }

            var cattegory = await _context.Cattegory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cattegory == null)
            {
                return NotFound();
            }

            return View(cattegory);
        }

        // POST: Cattegory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cattegory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cattegory'  is null.");
            }
            var cattegory = await _context.Cattegory.FindAsync(id);
            if (cattegory != null)
            {
                _context.Cattegory.Remove(cattegory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CattegoryExists(int id)
        {
          return (_context.Cattegory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
