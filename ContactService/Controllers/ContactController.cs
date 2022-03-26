
using AutoMapper;
using Business.Abstract;
using Entities.Concrete.Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace ContactService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;



        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _contactService.GetAllAsync();
            if (result.IsSuccess)
            {

                return Ok(result.Data);
            }
            return BadRequest(new {result.Message });
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _contactService.GetAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(new {result.Message });

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ContactDto contactDto)
        {
            var contact = _mapper.Map<ContactDto,Contact>(contactDto);

            var result = await _contactService.AddAsync(contact);
            if (result.IsSuccess)
            {
                return Ok(new {result.Message });
            }
            return BadRequest(new {result.Message });



        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            var result = await _contactService.UpdateAsync(contact);
            if (result.IsSuccess)
            {
                return Ok(new { result.Message });
            }
            return BadRequest(new { result.Message });
        }

        [HttpPost("delete/{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _contactService.DeleteAsync(id);



            if (result.IsSuccess)
            {
                return Ok(new { result.Message });
            }
            return BadRequest(new { result.Message });
        }
    }
}
