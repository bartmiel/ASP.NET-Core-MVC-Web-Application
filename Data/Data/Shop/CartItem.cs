using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Shop
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string CartSessionId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
