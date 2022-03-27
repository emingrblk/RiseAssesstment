using Entities.Concrete.Entities;
using Entities.DTOs;
using AutoMapper;
using System.Linq;
using Entities.Concrete.DTOs;

namespace Core.Utilities.Mapping.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Contact, ContactListDto>()
                .ForMember(dest => dest.ContactInformation, opt =>
                       opt.MapFrom(a => a.ContactInformations.Select(q => new ContactInformationDto() { Id = q.Id, Phone = q.Phone, EMail = q.EMail, Location = q.Location }).ToArray()));

            CreateMap<Contact, ContactDto>().ReverseMap();
       
            CreateMap<ContactInformation, ContactInformationDto>().ReverseMap();
            CreateMap<MiddlewareLog, MiddlewareLogDto>().ReverseMap();



        }
    }
}
