
using Microsoft.AspNetCore.Mvc;

using System.Linq; 
using AutoMapper;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using System;

namespace ReportService.Controllers
{
    [Authorize]
    [Route("apies/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
       

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
          
        }


        [HttpGet]
        public IActionResult Get()
        {

            var result = _reportService.GetAll();
            if (result.IsSuccess)
            {

                return Ok(result.Data.ToList());
            }
            return BadRequest(new {   result.Message });
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _reportService.Get(id);
             if (result.IsSuccess)
            { 
                return Ok(result);
            }
            return BadRequest(new {   result.Message });

        }


    }
}
