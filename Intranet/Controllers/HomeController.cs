using Data.Data;
using Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intranet.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext context)
            : base(context)
        {
        }

        public IActionResult Index()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewBag.Messages = base.GetNewMessages();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}