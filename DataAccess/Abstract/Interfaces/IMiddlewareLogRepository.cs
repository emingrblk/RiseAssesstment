using Core.DataAccess.Abstract.Interfaces;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Interfaces
{
   public interface IMiddlewareLogRepository : IEntityRepository<MiddlewareLog, Guid>
    {
    }
}
