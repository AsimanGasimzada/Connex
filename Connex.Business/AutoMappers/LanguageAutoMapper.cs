using AutoMapper;

namespace Connex.Business.AutoMappers;

public class LanguageAutoMapper : Profile
{
    public LanguageAutoMapper()
    {
        CreateMap<Language, LanguageCreateDto>().ReverseMap();
        CreateMap<Language, LanguageUpdateDto>().ReverseMap().ForMember(x => x.ImagePath, x => x.Ignore());
        CreateMap<Language, LanguageGetDto>().ReverseMap();
    }
}
