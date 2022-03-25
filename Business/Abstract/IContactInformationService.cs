 
using Core.Utilities.Results;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks; 
namespace  Business.Abstract
{
    public interface IContactInformationService
    {
        Task<IDataResult<IList<ContactInformation>>> GetContactDetailsAsync();
        Task<IResult> AddAsync(ContactInformation contactDetail);
        Task<IResult> UpdateAsync(ContactInformation contactDetail);
        Task<IResult> DeleteAsync(Guid id);
    }
}
