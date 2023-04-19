using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Portal
{
    public class Distance
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Limit uczestników")]
        public int LimitOfParticipants { get; set; } = 99999;
        public Competition Competition { get; set; }
        
        public List<EntryFeePaid> EntryFeePaid { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
