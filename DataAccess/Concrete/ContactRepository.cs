
using Core.DataAccess.Concrete;
using DataAccess.Abstract.Interfaces;
using DataAccess.Context;
using Entities.Concrete.Entities;
using System;

namespace DataAccess.Concrete
{
    public class ContactRepository: EntityRepository<Contact,Guid, RiseAssesstmentContext>, IContactRepository
    {
        public ContactRepository(RiseAssesstmentContext context) : base(context)
        {
        }

     
    }
}
