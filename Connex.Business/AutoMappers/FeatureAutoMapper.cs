using AutoMapper;

namespace Connex.Business.AutoMappers;

public class FeatureAutoMapper : Profile
{
    public FeatureAutoMapper()
    {
        CreateMap<Feature, FeatureCreateDto>().ReverseMap();
        CreateMap<Feature, FeatureUpdateDto>().ReverseMap().ForMember(x => x.ImagePath, x => x.Ignore());
        CreateMap<Feature, FeatureGetDto>()
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FeatureDetails.FirstOrDefault()!.Name))
                         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.FeatureDetails.FirstOrDefault()!.Description)); ;

    }
}
