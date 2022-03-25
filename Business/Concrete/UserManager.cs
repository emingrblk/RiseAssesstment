using Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract.Interfaces;
using Entities.Concrete.Entities;
using Core.Utilities.Constants;
using DataAccess.Context;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly RiseAssesstmentContext _context;

        public UserManager(IUserRepository userRepository, RiseAssesstmentContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var query = await _userRepository.GetAsync(q => q.Email == email);
            return new SuccessDataResult<User>(query, Messages.ContactGet);
        }

        public async Task<IResult> AddAsync(User contact)
        {
            await _userRepository.AddAsync(contact);
            return new SuccessResult(Messages.ContactAdded);
        }


     

        public  List<OperationClaim> GetClaims(User user)
        {
 
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaims on
                                 operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

           


        }


    }
}
