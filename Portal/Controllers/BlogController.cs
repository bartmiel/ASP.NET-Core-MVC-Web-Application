using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Models.DtoModels;
using Portal.Services;

namespace Portal.Controllers
{
    public class BlogController : BaseController
    {
        public BlogController(ApplicationDbContext context, IParameterService parameterService)
            : base(context, parameterService)
        {
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Parameters = base.GetParameters();
            return View(await _context.Blog.OrderBy(cd => cd.CreationDate).ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Parameters = base.GetParameters();
            return View(await _context.Blog.Where(b => b.Id == id).FirstOrDefaultAsync());
        }
    }
}
