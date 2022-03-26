 
using Microsoft.AspNetCore.Mvc;
using System; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authorization;
using Business.Abstract;
using Entities.Concrete.Entities;
using AutoMapper;
using Entities.DTOs;

namespace ContactService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _ContactInformationManager;
        private readonly IMapper _mapper;

        public ContactInformationController(IContactInformationService ContactInformationManager, IMapper mapper)
        {
            _ContactInformationManager = ContactInformationManager;
            _mapper = mapper;
        }


        [HttpPost("add/{contactId}")]
        public async Task<IActionResult> Add(Guid contactId, ContactInformationDto contactInformationDto)
        {
            var contactInformation = _mapper.Map<ContactInformation>(contactInformationDto);

            contactInformation.ContactId = contactId;
            var result = await _ContactInformationManager.AddAsync(contactInformation);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });



        }

        [HttpPost("update/{contactId}")]
        public async Task<IActionResult> Update(Guid contactId, ContactInformationDto contactInformationDto)
        {

            var contactInformation = _mapper.Map<ContactInformation>(contactInformationDto);
            contactInformation.ContactId = contactId;
            var result = await _ContactInformationManager.UpdateAsync(contactInformation);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }


        [HttpPost("delete/{ContactInformationId}")]

        public async Task<IActionResult> Delete(Guid ContactInformationId)
        {
            var result = await _ContactInformationManager.DeleteAsync(ContactInformationId);
            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message });
            }
            return BadRequest(new { Message = result.Message });
        }

    }
}
