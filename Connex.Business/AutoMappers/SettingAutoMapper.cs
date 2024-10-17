using AutoMapper;

namespace Connex.Business.AutoMappers;

public class SettingAutoMapper : Profile
{
    public SettingAutoMapper()
    {
        CreateMap<Setting, SettingCreateDto>().ReverseMap();
        CreateMap<Setting, SettingUpdateDto>().ReverseMap();
        CreateMap<Setting, SettingGetDto>().ReverseMap();
    }
}
