using System.ComponentModel.DataAnnotations;

namespace Data.Data.Portal
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public bool IsNew { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}