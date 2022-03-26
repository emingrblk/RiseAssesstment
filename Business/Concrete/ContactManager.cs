using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;  
using Core.Utilities.Results;
using DataAccess.Abstract.Interfaces;
using Entities.Concrete.Entities;
using Core.Utilities.Constants;
using Business.Abstract;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactRepository _contactRepository;

        private readonly IContactInformationRepository _contactInformationRepository;

        public ContactManager(IContactRepository contactRepository, IContactInformationRepository contactInformationRepository)
        {
            _contactRepository = contactRepository;
            _contactInformationRepository = contactInformationRepository;
        }

        public async Task<IDataResult<IList<Contact>>> GetAllAsync()
        {
            var query = await _contactRepository.GetAllAsync("ContactInformations");
            return new SuccessDataResult<IList<Contact>>(query.ToList(), Messages.ContactsGet);
        }

        public async Task<IDataResult<Contact>> GetAsync(Guid id)
        {
            var query = await _contactRepository.GetAsync(q => q.Id == id, "ContactInformations");
            return new SuccessDataResult<Contact>(query, Messages.ContactGet);
        }

        public async Task<IResult> AddAsync(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
            return new SuccessResult(Messages.ContactAdded);
        }

        public async Task<IResult> UpdateAsync(Contact contact)
        {
            await _contactRepository.UpdateAsync(contact, contact.Id);
            return new SuccessResult(Messages.ContactUpdated);
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var contactInformations = _contactInformationRepository.GetAllAsync().Result.Where(x => x.ContactId == id).ToList();
            if (!contactInformations.Any())
            {
                foreach (var item in contactInformations)
                {
                    await  _contactInformationRepository.DeleteAsync(item.Id);
                }
            }

            await _contactRepository.DeleteAsync(id);
            return new SuccessResult(Messages.ContactDeleted);
        }


    }
}

