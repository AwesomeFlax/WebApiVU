using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVU.Helpers;
using WebApiVU.Models;

namespace WebApiVU.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/schedule")]
	public class MarksController : ControllerBase
	{
		private IMapper _mapper;
		private readonly AppSettings _appSettings;
		private DataContext _context;

		public MarksController(
		   IMapper mapper,
		   IOptions<AppSettings> appSettings,
		   DataContext context)
		{
			_mapper = mapper;
			_appSettings = appSettings.Value;
			_context = context;
		}

		[HttpPost("marks")]
		public ActionResult<Mark> Input([FromBody]Mark mark)
		{
			try
			{
				var result = _context.Add(mark);
				_context.SaveChanges();

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest("Error: " + ex.Message);
			}
		}
	}
}
