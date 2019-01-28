using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiVU.Helpers;
using WebApiVU.Models;

namespace WebApiVU.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private DataContext _context;

        public ScheduleController(
           IMapper mapper,
           IOptions<AppSettings> appSettings,
           DataContext context)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [HttpPost("schedule")]
        public ActionResult<Schedule> Input([FromBody]Schedule schedule)
        {
            try
            {
                var result = _context.Add(schedule);
                _context.SaveChanges();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
	}
}