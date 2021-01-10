using Aplicacao.Api.Models;
using Aplicacao.Core.Dto;
using Aplicacao.Core.Models;
using AutoMapper;


namespace temis.Api.AutoMapper.Mapper.UserMapper
{
    public static class EnderecoMapperRequestUser
    {
        public static void Map(Profile profile)
        {
            if (profile != null)
                profile.CreateMap<Endereco, UserEnderecoDto>();
        }


    }
}