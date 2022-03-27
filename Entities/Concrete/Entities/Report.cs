using Entities.Abstract.Interface;
using System;
 
namespace Entities.Concrete.Entities
{
   public class Report: IEntity
    {
        public Guid Id { get; set; }
        public DateTime? RequestDate { get; set; }
        public int ReportStatusId { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public string Location { get; set; }

        public string FilePath { get; set; }
    }
}
