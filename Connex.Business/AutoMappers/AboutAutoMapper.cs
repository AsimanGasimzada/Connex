using AutoMapper;

namespace Connex.Business.AutoMappers;

public class AboutAutoMapper : Profile
{
    public AboutAutoMapper()
    {
        CreateMap<About, AboutCreateDto>().ReverseMap();
        CreateMap<About, AboutUpdateDto>().ReverseMap().ForMember(x => x.ImagePath, x => x.Ignore()).ForMember(x => x.BGImagePath, x => x.Ignore());

        CreateMap<About, AboutGetDto>().ForMember(x => x.Name, x => x.MapFrom(x => x.AboutDetails.FirstOrDefault()!.Name))
                                         .ForMember(x => x.Description, x => x.MapFrom(x => x.AboutDetails.FirstOrDefault()!.Description));

    }
}
