using Entities.Abstract.Interface;
using System; 

namespace Entities.DTOs
{
    public class ContactInformationDto:IDto
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
