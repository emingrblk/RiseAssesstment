
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Business.MessageBrokers.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Business.Abstract;
using Core.Utilities.ViewModels;
using Core.Utilities.Constants;

namespace SeturAssessment.ContactService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportRequestsController : ControllerBase
    {
        private readonly IMessageBrokerHelper _messageBrokerHelper;
        private readonly IContactInformationService _contactInformationService;
        public ReportRequestsController(IMessageBrokerHelper messageBrokerHelper, IContactInformationService contactInformationService)
        {
            _messageBrokerHelper = messageBrokerHelper;
            _contactInformationService = contactInformationService;
        }


        [HttpPost("RequestReport/{location}")]
        public async Task<IActionResult> RequestReportWithLocation(string location)
        {
            var result = await _contactInformationService.GetContactDetailsAsync();
            if (result.IsSuccess)
            {
                ReportRequestModelWithLocation reportRequestModel = new ReportRequestModelWithLocation();
                reportRequestModel.ContactInformations = result.Data.ToList();
                reportRequestModel.location = location;
                _messageBrokerHelper.QueueMessage(reportRequestModel);
                return Ok($"{location} {Messages.ReportRequestCreatedForLocation}");
            }
            return BadRequest(new { result.Message });

        }
    }
}
