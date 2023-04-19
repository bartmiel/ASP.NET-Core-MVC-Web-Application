using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Shop
{
    public class Cattegory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(20, ErrorMessage = "Tytuł powinien zawierać max 20 znaków")]
        [Display(Name="Nazwa")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Opis powinien zawierać max 100 znaków")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public List<Product> Product { get; set; }
    }
}
