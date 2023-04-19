using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Data.CMS
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł aktualności")]
        [MaxLength(50, ErrorMessage = "Tytuł strony powinien zawierać max 50 znaków")]
        [Display(Name = "Tytuł aktualności")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Wpisz opis wpisu blogowego")]
        [MaxLength(100, ErrorMessage = "Opis powinien zawierać max 100 znaków")]
        [Display(Name = "Opis wpisu blogowego")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Wpisz treść bloga")]
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Contents { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Picture { get; set; }

        [Display(Name = "Pozycja wyświetlania na blogu")]
        [Required(ErrorMessage = "Pozycja wyświetlania jest wymagana")]
        public int Position { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
