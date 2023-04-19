using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Services;

namespace Portal.Controllers
{
    public class ShopController : BaseController
    {
        public ShopController(ApplicationDbContext context, IParameterService parameterService)
            : base(context, parameterService)
        {
        }
        //GET: Product
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.SpecialOfferBaner = await _context.SpecialOffer.Where(so => so.IsActive == true).ToListAsync();
            ViewBag.Parameters = base.GetParameters();
            if (id == null)
            {
                return View(await _context.Product.Include(p => p.Picture).Where(p => p.Discount).ToListAsync());
            }
            else
            {
                return View(await _context.Product.Include(p => p.Picture).Where(p => p.CattegoryId == id).ToListAsync());
            }
        }
        //GET: ProductDetails
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Parameters = base.GetParameters();
            ViewBag.SpecialOfferBaner = await _context.SpecialOffer.Where(so => so.IsActive == true).ToListAsync();
            return View(await _context.Product.Include(p => p.Picture).Include(p => p.Cattegory).Where(p => p.Id == id).FirstOrDefaultAsync());
        }
    }
}
