using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Data.Portal
{
    public class Competition
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Nazwa jest wymagana")]
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Data oraz godzina rozpoczęcia jest wymagana")]
        [DisplayName("Data i godzina rozpoczęcia")]
        [Range(typeof(DateTime), "1/1/2022", "31/12/2023",
            ErrorMessage ="Data musi być z przedziału {1} i {2}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Miejscowość jest wymagana")]
        [DisplayName("Miejscowość")]
        public string City { get; set; }
        //[Display(Name = "Logo zawodów")]
        //public string Logo { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public List<Distance> Distances { get; set; }
    }
}