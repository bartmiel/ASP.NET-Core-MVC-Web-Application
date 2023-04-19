using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Data.Portal
{
    public class EntryFeePaid
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data początku obowiązywania jest wymagana")]
        [Display(Name = "Obowiązuje od")]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Data zakończenia obowiązywania jest wymagana")]
        [Display(Name = "Obowiązuje do")]
        public DateTime ValidUntil { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Dystans jest wymagany")]
        public Distance Distance { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}