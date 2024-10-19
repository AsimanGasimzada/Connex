using AutoMapper;

namespace Connex.Business.AutoMappers;

public class SliderAutoMapper:Profile
{
    public SliderAutoMapper()
    {
        CreateMap<Slider, SliderCreateDto>().ReverseMap();
        CreateMap<Slider, SliderUpdateDto>().ReverseMap().ForMember(x=>x.ImagePath,x=>x.Ignore());

        CreateMap<Slider, SliderGetDto>()
              .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.SliderDetails.FirstOrDefault()!.Title))
              .ForMember(dest => dest.Subtitle, opt => opt.MapFrom(src => src.SliderDetails.FirstOrDefault()!.Subtitle))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.SliderDetails.FirstOrDefault()!.Description))
              .ForMember(dest => dest.ButtonTitle, opt => opt.MapFrom(src => src.SliderDetails.FirstOrDefault()!.ButtonTitle));
    }
}
