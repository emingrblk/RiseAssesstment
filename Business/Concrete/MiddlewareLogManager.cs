using AutoMapper;
using Business.Abstract;
using Core.Utilities.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract.Interfaces;
using Entities.Concrete.DTOs;
using Entities.Concrete.Entities;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MiddlewareLogManager : IMiddlewareLogService
    {
        private readonly IMiddlewareLogRepository _middlewareLogRepository;
        private readonly IMapper _mapper;

        public MiddlewareLogManager(IMiddlewareLogRepository middlewareLogRepository, IMapper mapper)
        {
            _middlewareLogRepository = middlewareLogRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(MiddlewareLogDto middlewareLogDto)
        {
            var middlewareLog = _mapper.Map<MiddlewareLog>(middlewareLogDto);
            await _middlewareLogRepository.AddAsync(middlewareLog);
            return new SuccessResult(Messages.MiddlewareLogAdded);
        }
        
    }
}
