using api.Dtos.Login;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private IAuthenticationManager _authenticationManager;
        public UserController(IConfiguration config, IAuthenticationManager authenticationManager)
        {
            _config = config;
            _authenticationManager = authenticationManager;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto requestLogin)
        {
            ServiceResponse<LoginResponseDto> response = await _authenticationManager.Login(requestLogin);

            if (response.Data == null) {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}