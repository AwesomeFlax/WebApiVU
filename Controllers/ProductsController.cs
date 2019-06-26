using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVU.Helpers;
using WebApiVU.Models;
using WebApiVU.Services;

namespace WebApiVU.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private DataContext _context;
        private ProductsService ProductsService;

        public ProductsController(
           IMapper mapper,
           IOptions<AppSettings> appSettings,
           DataContext context,
           ProductsService productsService)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _context = context;
            ProductsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Product>> GetList()
        {
            var result = ProductsService.GetList();

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> GetById(long id)
        {
            var result = ProductsService.GetById(id);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> AddProduct([FromBody]Product model)
        {
            var result = ProductsService.AddProduct(model);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<string> Remove(long id)
        {
            try
            {
                ProductsService.Detele(id);
                return Ok("Produkt został usunięty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Update([FromBody]Product model)
        {
            var result = ProductsService.UpdateProduct(model);

            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
