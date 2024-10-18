using AutoMapper;

namespace Connex.Business.AutoMappers;

public class SliderDetailAutoMapper : Profile
{
    public SliderDetailAutoMapper()
    {
        CreateMap<SliderDetail, SliderDetailCreateDto>().ReverseMap();
        CreateMap<SliderDetail, SliderDetailUpdateDto>().ReverseMap();
    }
}