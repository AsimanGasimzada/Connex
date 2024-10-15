using AutoMapper;

namespace Connex.Business.AutoMappers;

public class SliderAutoMapper:Profile
{
    public SliderAutoMapper()
    {
        CreateMap<Slider, SliderCreateDto>().ReverseMap();
        CreateMap<Slider, SliderUpdateDto>().ReverseMap();
        CreateMap<Slider, SliderGetDto>().ReverseMap();
    }
}
