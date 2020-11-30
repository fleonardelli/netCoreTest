using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Login;
using api.Exceptions;
using api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class UserService
    {
        private readonly IotHomeControlContext _dbContext;
        private readonly IExternalTokenValidator _externalTokenValidator;
        private readonly IMapper _mapper;
        private readonly JwtService _jwt;

        public UserService(
            IotHomeControlContext dbContext,
            IExternalTokenValidator externalTokenValidator,
            IMapper mapper,
            JwtService jwt
        )
        {
            _dbContext = dbContext;
            _externalTokenValidator = externalTokenValidator;
            _mapper = mapper;
            _jwt = jwt;
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

            user.token = _jwt.create(user);

            serviceResponse.Data = _mapper.Map<LoginResponseDto>(user);

            return serviceResponse;
        }


    }
}