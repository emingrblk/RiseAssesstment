

using Core.DataAccess.Abstract.Interfaces;
using Entities.Concrete.Entities;
using System;

namespace DataAccess.Abstract.Interfaces
{
    public interface IContactRepository : IEntityRepository<Contact,Guid>
    {
    }
}
