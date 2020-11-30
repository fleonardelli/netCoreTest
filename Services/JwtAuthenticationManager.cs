using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Dtos.Login;
using api.Exceptions;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class JwtAuthenticationManager : IAuthenticationManager
    {
        private readonly IotHomeControlContext _dbContext;
        private readonly IExternalTokenValidator _externalTokenValidator;
        private readonly IMapper _mapper;

        private readonly IConfiguration _config;
        public JwtAuthenticationManager(
            IotHomeControlContext dbContext,
            IExternalTokenValidator externalTokenValidator,
            IMapper mapper,
            IConfiguration config
        )
        {
            _dbContext = dbContext;
            _externalTokenValidator = externalTokenValidator;
            _mapper = mapper;
            _config = config.GetSection("Jwt");
        }
        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto requestLogin)
        {
            User user = await _dbContext.User
            .Include(u => u.Rol)
            .FirstOrDefaultAsync(u => u.Email == requestLogin.email);

            ServiceResponse<LoginResponseDto> serviceResponse = new ServiceResponse<LoginResponseDto>();

            if (user == null) {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";

                return serviceResponse;
            }

            try {
                _externalTokenValidator.validateToken(requestLogin.externalToken);
            } catch (InvalidExternalTokenException ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

                return serviceResponse;
            }

            user.token = this.generateJwtToken(user);

            serviceResponse.Data = _mapper.Map<LoginResponseDto>(user);

            return serviceResponse;
        }

        private string generateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Issuer"],
                audience: _config["Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }
    }
}