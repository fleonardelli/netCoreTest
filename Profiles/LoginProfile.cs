using api.Dtos.Login;
using api.Models;
using api.Services;
using AutoMapper;

namespace api.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<User, LoginResponseDto>()
                .ForMember(u => u.rol, d => d.MapFrom(u => u.Rol.Name));
        }
    }
}