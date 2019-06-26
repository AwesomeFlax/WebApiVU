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
	[Route("api/recipes")]
	public class RecipesController : ControllerBase
	{
		private IMapper _mapper;
		private readonly AppSettings _appSettings;
		private DataContext _context;
		private RecipesService RecipeService;

        public RecipesController(
		   IMapper mapper,
		   IOptions<AppSettings> appSettings,
		   DataContext context,
           RecipesService recipeService)
		{
			_mapper = mapper;
			_appSettings = appSettings.Value;
			_context = context;
            RecipeService = recipeService; 
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Recipe>> GetList()
        {
            var result = RecipeService.GetList();

            if (result != null)
            {
                foreach(var recipe in result)
                {
                    recipe.RecipeAuthor.PasswordHash = null;
                    recipe.RecipeAuthor.PasswordSalt = null;
                }
                return Ok(result);
            }
            else
                return BadRequest();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Recipe> GetById(long id)
        {
            var result = RecipeService.GetById(id);

            if (result != null)
            {
                result.RecipeAuthor.PasswordHash = null;
                result.RecipeAuthor.PasswordSalt = null;
                return Ok(result);
            }
            else
                return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Recipe> AddRecipe([FromBody]Recipe model)
		{
            var result = RecipeService.AddRecipe(model);

            if (result != null)
            {
                result.RecipeAuthor.PasswordHash = null;
                result.RecipeAuthor.PasswordSalt = null;
                return Ok(result);
            }
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
                RecipeService.Detele(id);
                return Ok("Przepis został usunięty");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Recipe> Update([FromBody]Recipe model)
        {
            var result = RecipeService.UpdateRecipe(model);

            if (result != null)
            {
                result.RecipeAuthor.PasswordHash = null;
                result.RecipeAuthor.PasswordSalt = null;
                return Ok(result);
            }
            else
                return BadRequest();
        }
    }
}
