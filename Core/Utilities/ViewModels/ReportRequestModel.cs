
using Entities.Concrete.Entities;
using System.Collections.Generic;
namespace Core.Utilities.ViewModels { 

    public class ReportRequestModel: IRequestModel
    {
        public List<ContactInformation> ContactInformations{ get; set; }
    }
}
