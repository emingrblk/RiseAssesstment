

using Core.Utilities.Results;
using Entities.Concrete.DTOs; 
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMiddlewareLogService
    {
        Task<IResult> AddAsync(MiddlewareLogDto middlewareLogDto);
    }
}
