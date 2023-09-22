using AutoMapper;
using picpay_desafio_backend.Data.DTOs;
using picpay_desafio_backend.Models;

namespace picpay_desafio_backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, ReadUserDTO>();
        }

    }
}
