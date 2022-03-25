using Entities.Abstract.Interface;
using System;
 

namespace Entities.Concrete.Entities
{
    public class OperationClaim:IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
