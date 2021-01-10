using AutoMapper;
using temis.Api.AutoMapper.Mapper.UserMapper;

namespace temis.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            EnderecoMapperRequest.Map(this);
            EnderecoMapperRequestUser.Map(this);

            UserMapperRequest.Map(this);
            UserMapperResponse.Map(this);

            UserMapperResponseView.Map(this);
            UserMapperRequestView.Map(this);

            UserMapperRequestDto.Map(this);
            UserMapperResponseDto.Map(this);

        }
    }
}