


using Core.DataAccess.Concrete;
using DataAccess.Abstract.Interfaces;
using DataAccess.Context;
using Entities.Concrete.Entities;
using System;

namespace DataAccess.Concrete
{

    public class UserRepository : EntityRepository<User, Guid, RiseAssesstmentContext>, IUserRepository
    {
        public UserRepository(RiseAssesstmentContext context) : base(context)
        { 
             
        }
        
    }
}
