using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Data.Data.CMS;

namespace Intranet.Controllers
{
    public class ParameterController : BaseController
    {
        public ParameterController(ApplicationDbContext context)
            : base(context)
        {
        }

        // GET: Parameter
        public async Task<IActionResult> Index()
        {
            ViewBag.Messages = base.GetNewMessages();
            return _context.Parameter != null ? 
                          View(await _context.Parameter.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Parameter'  is null.");
        }

        // GET: Parameter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Parameter == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // GET: Parameter/Create
        public IActionResult Create()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View();
        }

        // POST: Parameter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Value,Description,IsActive,CreationDate")] Parameter parameter)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (ModelState.IsValid)
            {
                _context.Add(parameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parameter);
        }

        // GET: Parameter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Parameter == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameter.FindAsync(id);
            if (parameter == null)
            {
                return NotFound();
            }
            return View(parameter);
        }

        // POST: Parameter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Value,Description,IsActive,CreationDate")] Parameter parameter)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id != parameter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParameterExists(parameter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Zaktualizowano nazwę parametru"+parameter.Name;
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Parametr "+ parameter.Name + " nie został zaktualizowany. Popraw błędy.";
            return View(parameter);
        }

        // GET: Parameter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Parameter == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: Parameter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parameter == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Parameter'  is null.");
            }
            var parameter = await _context.Parameter.FindAsync(id);
            if (parameter != null)
            {
                _context.Parameter.Remove(parameter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParameterExists(int id)
        {
          return (_context.Parameter?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
