using Aplicacao.Api.Models;
using Aplicacao.Core.Models;
using AutoMapper;


namespace temis.Api.AutoMapper.Mapper.UserMapper
{
    public static class UserMapperRequestView
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<User, UserViewModel>();
        }


    }
}