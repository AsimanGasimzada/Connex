using AutoMapper;

namespace Connex.Business.AutoMappers;

public class AboutDetailAutoMapper : Profile
{
    public AboutDetailAutoMapper()
    {
            CreateMap<AboutDetail,AboutDetailCreateDto>().ReverseMap();  
            CreateMap<AboutDetail,AboutDetailUpdateDto>().ReverseMap();  
    }
}