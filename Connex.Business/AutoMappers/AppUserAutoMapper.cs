using AutoMapper;

namespace Connex.Business.AutoMappers;

public class AppUserAutoMapper:Profile
{
    public AppUserAutoMapper()
    {
        CreateMap<AppUser,RegisterDto>().ReverseMap();
        CreateMap<AppUser,UserGetDto>().ReverseMap();
    }
}
