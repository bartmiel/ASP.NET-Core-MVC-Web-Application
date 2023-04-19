using Data.Data;
using Data.Data.CMS;
using Data.Data.Portal;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    public class BaseController : Controller
    {
        private List<Message> messages;
        private ContactForm contactForm;
        public readonly ApplicationDbContext _context;
        public BaseController(ApplicationDbContext context)
        {
            _context = context;
            messages = new List<Message>();
            contactForm = new ContactForm();
        }
        public List<Message> GetNewMessages()
        {
            messages = _context.Message.Where(m => m.IsNew).ToList();
            return messages;
        }
        public List<Message> GetAllMessages()
        {
            messages = _context.Message.Where(m => m.IsActive).ToList();
            return messages;
        }
        public ContactForm GetContactForm()
        {
            contactForm = _context.ContactForm.First();
            return contactForm;
        }
    }
}