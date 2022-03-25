using Entities.Abstract.Interface;
using System;
 

namespace Entities.Concrete.Entities
{
    public class UserOperationClaim :IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
