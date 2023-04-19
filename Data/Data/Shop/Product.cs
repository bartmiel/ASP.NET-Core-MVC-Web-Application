using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Shop
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kod jest wymagany")]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        public bool Discount { get; set; } = false;

        [Required(ErrorMessage = "Cena promocyjna jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Cena promocyjna")]
        public decimal DiscountPrice { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        public int CattegoryId { get; set; }
        
        public Cattegory Cattegory { get; set; }
        public List<Picture> Picture { get; set; }
    }
}
