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
        private readonly ILogger<AccountController> _logger;
        
        // can do the same for the logger in others controllers/action/function
        public AccountController(IAuthManager authManager, ILogger<AccountController> logger)
        {
            _authManager = authManager;
            _logger = logger;
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
            _logger.LogInformation($"Registration Attempt for {userDTO.Email}");
            try {
                var result = await _authManager.Register(userDTO);
                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Ok(result);
            }
            catch(Exception ex) {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something went wrong in the {nameof(Register)}.", statusCode: 500);
            }
        }

        // api/account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
         //   _logger.LogInformation($"Login Attempt for {loginDTO.Email}");
        //    try
        //    {
                var result = await _authManager.Login(loginDTO);
                if (result == null)
                {
                    return Unauthorized();
                }
                return Ok(result);

         //   }
         //   catch (Exception ex)
        //    {
         //       _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
        //        return Problem($"Something went wrong in the {nameof(Login)}.", statusCode: 500);
         //   }
         
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
