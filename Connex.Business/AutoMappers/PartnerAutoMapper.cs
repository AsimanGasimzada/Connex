using AutoMapper;

namespace Connex.Business.AutoMappers;

public class PartnerAutoMapper : Profile
{
    public PartnerAutoMapper()
    {
        CreateMap<Partner, PartnerCreateDto>().ReverseMap();
        CreateMap<Partner, PartnerUpdateDto>().ReverseMap().ForMember(x => x.ImagePath, x => x.Ignore());
        CreateMap<Partner, PartnerGetDto>().ReverseMap();
    }
}
