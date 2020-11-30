using System.Threading.Tasks;
using api.Dtos.Login;

namespace api.Services
{
    public interface IAuthenticationManager
    {
        public Task<ServiceResponse<LoginResponseDto>> Login(LoginRequestDto requestLogin);

    }
}