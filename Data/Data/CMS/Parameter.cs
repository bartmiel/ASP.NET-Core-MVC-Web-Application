using System.ComponentModel.DataAnnotations;

namespace Data.Data.CMS
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Kod")]
        [Required(ErrorMessage = "Kod jest wymagany")]
        [MaxLength(10, ErrorMessage = "Kod powinien zawierać max 10 znaków")]
        public string Code { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa powinna zawierać max 30 znaków")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wartość jest wymagana")]
        [Display(Name = "Wartość")]
        public string Value { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
