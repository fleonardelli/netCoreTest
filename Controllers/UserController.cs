using api.Dtos.Login;
using api.Exceptions;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using api.Models;

namespace api.Controllers
{

    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private UserService _userService;
        public UserController(IConfiguration config, UserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDto requestLogin)
        {
            ServiceResponse<LoginResponseDto> response = await _userService.Login(requestLogin);

            if (response.Data == null) {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}