using Aplicacao.Api.Models;
using Aplicacao.Core.Models;
using AutoMapper;
using Aplicacao.Core.Dto;

namespace temis.Api.AutoMapper.Mapper.UserMapper
{
    public static class UserMapperResponseDto
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<User, UserDto>();
                profile.CreateMap<UserRequest, User>();
        }


    }
}