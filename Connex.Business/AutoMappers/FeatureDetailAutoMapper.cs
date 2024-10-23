using AutoMapper;

namespace Connex.Business.AutoMappers;

public class FeatureDetailAutoMapper : Profile
{
    public FeatureDetailAutoMapper()
    {
        CreateMap<FeatureDetail, FeatureDetailCreateDto>().ReverseMap();
        CreateMap<FeatureDetail, FeatureDetailUpdateDto>().ReverseMap();
    }
}