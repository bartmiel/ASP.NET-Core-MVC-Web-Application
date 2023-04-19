using System.ComponentModel.DataAnnotations;

namespace Data.Data.CMS
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł formularza")]
        [MaxLength(50, ErrorMessage = "Tytuł formularza powinien zawierać max 50 znaków")]
        [Display(Name = "Tytuł formularza")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł pierwszego pola")]
        [MaxLength(50, ErrorMessage = "Tytuł pola powinien zawierać max 20 znaków")]
        [Display(Name = "Etykieta pola 1")]
        public string Field1Label { get; set; }

        [Required(ErrorMessage = "Wybierz typ pola")]
        [Display(Name = "Typ pierwszego pola")]
        public string Field1Type { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł drugiego pola")]
        [MaxLength(50, ErrorMessage = "Tytuł pola powinien zawierać max 20 znaków")]
        [Display(Name = "Etykieta pola 2")]
        public string Field2Label { get; set; }

        [Required(ErrorMessage = "Wybierz typ pola")]
        [Display(Name = "Typ drugiego pola")]
        public string Field2Type { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł trzeciego pola")]
        [MaxLength(50, ErrorMessage = "Tytuł pola powinien zawierać max 20 znaków")]
        [Display(Name = "Etykieta pola 3")]
        public string Field3Label { get; set; }

        [Required(ErrorMessage = "Wybierz typ pola")]
        [Display(Name = "Typ trzeciego pola")]
        public string Field3Type { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł czwartego pola")]
        [MaxLength(50, ErrorMessage = "Tytuł pola powinien zawierać max 20 znaków")]
        [Display(Name = "Etykieta pola 4")]
        public string Field4Label { get; set; }

        [Required(ErrorMessage = "Wybierz typ pola")]
        [Display(Name = "Typ czwartego pola")]
        public string Field4Type { get; set; }

        [Required(ErrorMessage = "Wpisz tytuł piątego pola")]
        [MaxLength(50, ErrorMessage = "Tytuł pola powinien zawierać max 20 znaków")]
        [Display(Name = "Etykieta obszaru tekstowego")]
        public string Field5Label { get; set; }

        [Required(ErrorMessage = "Wpisz nazwę wyświetlaną na przycisku")]
        [MaxLength(50, ErrorMessage = "Nazwa przycisku powinien zawierać max 15 znaków")]
        [Display(Name = "Nazwa wyświetlana na przycisku")]
        public string SubmitButtonTitle { get; set; }
    }
}