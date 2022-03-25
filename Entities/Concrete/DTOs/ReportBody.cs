using Entities.Abstract.Interface;


namespace Entities.Concrete.DTOs
{
    public class ReportBody: IDto
    {
        public string Location { get; set; }
        public int ContactCount { get; set; }
        public int PhoneNumberCount { get; set; }
    }
}
