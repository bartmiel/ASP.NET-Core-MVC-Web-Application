using Data.Data.CMS;
using Data.Data.Portal;

namespace Intranet.Models.DtoModels
{
    public class MessagesContactFormDto
    {
        public List<Message> Messages { get; set; }
        public ContactForm ContactForm { get; set; }
    }
}
