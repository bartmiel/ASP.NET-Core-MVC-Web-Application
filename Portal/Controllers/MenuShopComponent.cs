using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portal.Controllers
{
    public class MenuShopComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public MenuShopComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Views/Shop/Components/MenuShopComponent/MenuShopComponent.cshtml", await _context.Cattegory.ToListAsync());
        }
    }
}