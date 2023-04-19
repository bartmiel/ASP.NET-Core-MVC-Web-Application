using Data.Data;
using Data.Data.Portal;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using Portal.Services;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext context, IParameterService parameterService)
            : base(context, parameterService)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Parameters = base.GetParameters();
            ViewBag.BlogSection = base.GetBlogSection();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage([Bind("Id, Field1, Field2, Field3, Field4, Field5, IsActive, CreationDate")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                TempData["success"] = "Dziękujemy za twoją wiadomość. Odpowiemy najszybciej jak to możliwe.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}