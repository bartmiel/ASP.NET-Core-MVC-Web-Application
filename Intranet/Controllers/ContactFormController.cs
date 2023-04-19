using Data.Data;
using Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Controllers
{
    public class ContactFormController : BaseController
    {
        public ContactFormController(ApplicationDbContext context)
            : base(context)
        {
        }

        // GET: ContactForm
        public async Task<IActionResult> Index()
        {
            ViewBag.Messages = base.GetNewMessages();
            var contactForm = await _context.ContactForm.FirstOrDefaultAsync();
            return View(contactForm);
        }
        // POST: ContactForm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Field1Label, Field1Type,Field2Label, Field2Type," +
            "Field3Label, Field3Type, Field4Label, Field4Type, Field5Label, SubmitButtonTitle")] ContactForm contactForm)
        {
            ViewBag.Messages = base.GetNewMessages();
            id = 1;
            if (id != contactForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactForm);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Zaktualizowano formularz kontaktowy.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactFormExists(contactForm.Id))
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
            TempData["error"] = "Formularz kontaktowy nie został zaktualizowany. Popraw błędy.";
            return View("Index", contactForm);
            
        }

        private bool ContactFormExists(int id)
        {
            return (_context.ContactForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
