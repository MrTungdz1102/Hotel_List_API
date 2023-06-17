using Hotel_List_API.Contracts;
using Hotel_List_API.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AccountController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        // api/account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] ApiUserDTO userDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            // khong can check ModelState vi da co DTO check

            var result = await _authManager.Register(userDTO);
            if (result.Any())
            {
                foreach(var item in result)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        // api/account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _authManager.Login(loginDTO);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }


        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken([FromBody] AuthResponseDTO authResponse)
        {
            var result = await _authManager.VerifyRefreshToken(authResponse);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
