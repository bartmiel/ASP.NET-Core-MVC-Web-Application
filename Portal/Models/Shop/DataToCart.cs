using Data.Data.Shop;

namespace Portal.Models.Shop
{
    public class DataToCart
    {
        public List<CartItem> CartItem { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
