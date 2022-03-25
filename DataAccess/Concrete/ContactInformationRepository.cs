using Core.DataAccess.Concrete;
using DataAccess.Abstract.Interfaces;
using DataAccess.Context;
using Entities.Concrete.Entities;
using System;  
 

namespace DataAccess.Concrete
{
    public class ContactInformationRepository : EntityRepository<ContactInformation, Guid, RiseAssesstmentContext>, IContactInformationRepository
    {
        public ContactInformationRepository(RiseAssesstmentContext context) : base(context)
        {
        }
    }
}
