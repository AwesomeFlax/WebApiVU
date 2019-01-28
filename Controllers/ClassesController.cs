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
	public class ClassesController : ControllerBase
	{
		private IMapper _mapper;
		private readonly AppSettings _appSettings;
		private DataContext _context;

		public ClassesController(
		   IMapper mapper,
		   IOptions<AppSettings> appSettings,
		   DataContext context)
		{
			_mapper = mapper;
			_appSettings = appSettings.Value;
			_context = context;
		}

		[HttpPost("classes")]
		public ActionResult<Classes> Input([FromBody]Classes classes)
		{
			try
			{
				var result = _context.Add(classes);
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
