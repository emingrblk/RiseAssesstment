using Entities.Abstract.Interface;
using System;

namespace Entities.DTOs
{
    public class ContactListDto:IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public ContactInformationDto[] ContactInformation { get; set; }
       
    }
}
