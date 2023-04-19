using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Data.Data.Portal;
using Intranet.Models.DtoModels;

namespace Intranet.Controllers
{
    public class MessageController : BaseController
    {

        public MessageController(ApplicationDbContext context)
            : base(context)
        {
        }

        // GET: Message
        public async Task<IActionResult> Index()
        {
            ViewBag.Messages = base.GetNewMessages();
            var messagesContactFormDto = new MessagesContactFormDto()
            {
                Messages = base.GetAllMessages(),
                ContactForm = base.GetContactForm()
            };
            return View(messagesContactFormDto);
        }

        // GET: Message/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }
            var messageContactFormDto = new MessageContactFormDto()
            {
                Message = await _context.Message.FirstOrDefaultAsync(m => m.Id == id),
                ContactForm = base.GetContactForm()
            };
            if (messageContactFormDto.Message == null)
            {
                return NotFound();
            }
            try
            {
                if (messageContactFormDto.Message.IsNew == true)
                {
                    messageContactFormDto.Message.IsNew = false;
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Wiadomość została oznaczona jako przeczytana.";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(messageContactFormDto.Message.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(messageContactFormDto);
        }

        // GET: Message/Create
        public IActionResult Create()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View();
        }

        // POST: Message/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Field1,Field2,Field3,Field4,Field5,IsActive,CreationDate")] Message message)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Messages = base.GetNewMessages();
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Field1,Field2,Field3,Field4,Field5,IsActive,CreationDate,IsNew")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            return View(message);
        }

        // GET: Message/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Message == null)
            {
                return NotFound();
            }

            var message = await _context.Message
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Message == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Message'  is null.");
            }
            var message = await _context.Message.FindAsync(id);
            if (message != null)
            {
                message.IsActive = false;
                message.IsNew = false;
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "Wiadomość została usunięta";
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return (_context.Message?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Readed(int id)
        {
            var message = await _context.Message.FindAsync(id);
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    message.IsNew = false;
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Wiadomość została oznaczona jako przeczytana.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            return View(message);
        }
    }
}
