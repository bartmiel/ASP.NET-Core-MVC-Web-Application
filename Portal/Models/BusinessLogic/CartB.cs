using Data.Data;
using Data.Data.Shop;
using Microsoft.EntityFrameworkCore;

namespace Portal.Models.BusinessLogic
{
    public class CartB
    {
        private readonly ApplicationDbContext _context;
        private string cartSessionId;
        public CartB(ApplicationDbContext context, HttpContext httpContext)
        {
            _context = context;
            cartSessionId = GetCartSessionId(httpContext);
        }
        private string GetCartSessionId(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("CartSessionId") == null)
            {
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("CartSessionId", httpContext.User.Identity.Name);
                }
                else
                {
                    Guid tempCartSessionId = Guid.NewGuid();
                    httpContext.Session.SetString("CartSessionId", tempCartSessionId.ToString());
                }
            }
            return httpContext.Session.GetString("CartSessionId");
        }
        public void AddToCart(Product product)
        {
            //sprawdzamy czy w elementach koszyka jest już towar dla danej sesji
            var tempCartItem =
                _context.CartItem
                .Where(c => c.CartSessionId == cartSessionId && c.Product.Id == product.Id)
                .FirstOrDefault();
            //jeżeli towar o podanym id istnieje w sesji to zwiększam jego ilość o 1
            if (tempCartItem != null)
            {
                tempCartItem.Quantity++;
            }
            //jeżeli nie ma tego towaru w sesji to go dodaję
            else
            {
                tempCartItem = new CartItem()
                {
                    CartSessionId = cartSessionId,
                    ProductId = product.Id,
                    Product = _context.Product.Find(product.Id),
                    Quantity = 1,
                    CreationDate = DateTime.Now
                };
                _context.CartItem.Add(tempCartItem);
            }
            _context.SaveChanges();
        }
        //zwracam wszystkie elementy koszyka klienta
        public async Task<List<CartItem>> GetCartItems()
        {
            return await _context.CartItem.Where(c => c.CartSessionId == this.cartSessionId).Include(c => c.Product).ToListAsync();
        }
        //zwracam sumę wartości elementów w koszyku
        public async Task<decimal> GetFinalPrice()
        {
            //iloczyn ilości towarów i liczby sztuk towaru bez promocji
            var standardItems = await
            (
                from element in _context.CartItem
                where element.CartSessionId == this.cartSessionId && element.Product.Discount == false
                select element.Product.Price * (decimal?)element.Quantity
            ).SumAsync();
            //iloczyn ilości towarów i liczby sztuk towaru w promocji
            var discountedItems = await
            (
                from element in _context.CartItem
                where element.CartSessionId == this.cartSessionId && element.Product.Discount == true
                select element.Product.DiscountPrice * (decimal?)element.Quantity
            ).SumAsync();
            //zwracam sumę wartości towarów bez promocji oraz w promocji
            return (standardItems + discountedItems) ?? 0;
        }
    }
}