using Core.DataAccess.Concrete;
using DataAccess.Abstract.Interfaces;
using DataAccess.Context;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    
    public class MiddlewareLogRepository : EntityRepository<MiddlewareLog, Guid, RiseAssesstmentContext>, IMiddlewareLogRepository
    {
        public MiddlewareLogRepository(RiseAssesstmentContext context) : base(context)
        {
        }


    }
}
