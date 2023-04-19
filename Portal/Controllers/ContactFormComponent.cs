using Data.Data;
using Data.Data.Portal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Models.DtoModels;

namespace Portal.Controllers
{
    public class ContactFormComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ContactFormComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactFormDto = new ContactFormDto()
            {
                ContactForm = await _context.ContactForm.FirstAsync(),
                Message = new Message()
            };
            return View("ContactFormComponent", contactFormDto);
        }
    }
}