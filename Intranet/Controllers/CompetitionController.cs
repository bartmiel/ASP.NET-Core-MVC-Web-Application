using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Data.Data.Portal;
using System.Runtime.Serialization;

namespace Intranet.Controllers
{
    public class CompetitionController : BaseController
    {
        public CompetitionController(ApplicationDbContext context)
            : base(context)
        {
        }

        // GET: Competition
        public async Task<IActionResult> Index()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View();
        }

        // GET: Competition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Competition == null)
            {
                return NotFound();
            }

            var competition = await _context.Competition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // GET: Competition/Create
        public IActionResult Create()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View();
        }

        // POST: Competition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,City,IsActive,CreationDate")] Competition competition)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (ModelState.IsValid)
            {
                _context.Add(competition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competition);
        }

        // GET: Competition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Competition == null)
            {
                return NotFound();
            }

            var competition = await _context.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }
            return View(competition);
        }

        // POST: Competition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,City,IsActive,CreationDate")] Competition competition)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id != competition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionExists(competition.Id))
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
            return View(competition);
        }

        // GET: Competition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Competition == null)
            {
                return NotFound();
            }

            var competition = await _context.Competition
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // POST: Competition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Competition == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Competition'  is null.");
            }
            var competition = await _context.Competition.FindAsync(id);
            if (competition != null)
            {
                _context.Competition.Remove(competition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionExists(int id)
        {
            return (_context.Competition?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
