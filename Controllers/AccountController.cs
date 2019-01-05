using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiVU.Models;
using WebApiVU.Models.User;

namespace WebApiVU.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<AppUser>> Register([FromBody]CreateModel model)
        {
            AppUser user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // setting cookies
                await _signInManager.SignInAsync(user, false);
                return Ok(user);
            }

            return BadRequest();
        }
    }
}
