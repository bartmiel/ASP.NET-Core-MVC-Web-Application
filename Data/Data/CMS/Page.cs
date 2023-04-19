using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.CMS
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł odnośnika")]
        [MaxLength(20, ErrorMessage = "Tytuł powinien zawierać max 20 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public string LinkTitle { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł strony")]
        [MaxLength(50, ErrorMessage = "Tytuł strony powinien zawierać max 50 znaków")]
        [Display(Name = "Tytuł strony")]
        public string Title { get; set; }

        [Display(Name = "Link do podstrony")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Link { get; set; }

        [Display(Name = "Pozycja wyświetlania w menu")]
        [Required(ErrorMessage = "Pozycja wyświetlania jest wymagana")]
        public int Position { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
