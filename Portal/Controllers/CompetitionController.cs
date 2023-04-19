using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Services;

namespace Portal.Controllers
{
    public class CompetitionController : BaseController
    {
        public CompetitionController(ApplicationDbContext context, IParameterService parameterService)
            : base(context, parameterService)
        {
        }
        //GET: Competitions
        public async Task<IActionResult> Index()
        {
            ViewBag.Parameters = base.GetParameters();
            return View(await _context.Competition.ToListAsync());
        }
    }
}
