using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Dtos.Login;
using api.Exceptions;
using api.Models;
using api.Repository;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class JwtAuthenticationManager : IAuthenticationManager
    {
        private readonly UserRepository _userRepository;
        private readonly IExternalTokenValidator _externalTokenValidator;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public JwtAuthenticationManager(
            UserRepository userRepository,
            IExternalTokenValidator externalTokenValidator,
            IMapper mapper,
            IConfiguration config
        )
        {
            _userRepository = userRepository;
            _externalTokenValidator = externalTokenValidator;
            _mapper = mapper;
            _config = config.GetSection("Jwt");
        }

        public async Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto requestLogin)
        {
            ServiceResponse<LoginResponseDto> serviceResponse = new ServiceResponse<LoginResponseDto>();

            try {
                User user = await _userRepository.findByEmail(requestLogin.email);

                try {
                    _externalTokenValidator.validateToken(requestLogin.externalToken);
                } catch (InvalidExternalTokenException ex) {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ex.Message;

                    return serviceResponse;
                }

                user.token = this.generateJwtToken(user);

                serviceResponse.Data = _mapper.Map<LoginResponseDto>(user);

            } catch (UserNotFoundException ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

                return serviceResponse;
            }

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