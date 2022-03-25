using Entities.Abstract.Interface;
 

namespace Entities.Concrete.Entities
{
   public class ReportStatus :IEntity
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
    }
}
