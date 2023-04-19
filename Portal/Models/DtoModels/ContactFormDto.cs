using Data.Data.CMS;
using Data.Data.Portal;

namespace Portal.Models.DtoModels
{
    public class ContactFormDto
    {
        public ContactForm ContactForm { get; set; }
        public Message Message { get; set; }
    }
}