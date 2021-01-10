using Aplicacao.Api.Models;
using Aplicacao.Core.Models;
using AutoMapper;


namespace temis.Api.AutoMapper.Mapper.UserMapper
{
    public static class UserMapperResponseView
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<UserViewModel, User>();
        }


    }
}