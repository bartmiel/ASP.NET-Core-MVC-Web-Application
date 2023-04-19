using Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Models.BusinessLogic;
using Portal.Models.Shop;
using Portal.Services;

namespace Portal.Controllers
{
    public class CartController : BaseController
    { 
        public CartController(ApplicationDbContext context, IParameterService parameterService)
            : base(context, parameterService)
        {
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.SpecialOfferBaner = await _context.SpecialOffer.Where(so => so.IsActive == true).ToListAsync();
            ViewBag.Parameters = base.GetParameters();
            CartB cartB = new CartB(_context, this.HttpContext);
            DataToCart dataToCart = new DataToCart()
            {
                CartItem = await cartB.GetCartItems(),
                FinalPrice = await cartB.GetFinalPrice()
            };
            return View(dataToCart);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            CartB cartB = new CartB(_context, this.HttpContext);
            cartB.AddToCart(await _context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}