using AutoMapper;

namespace Connex.Business.AutoMappers;

public class ServiceAutoMapper : Profile
{
    public ServiceAutoMapper()
    {
        CreateMap<Service, ServiceCreateDto>().ReverseMap();
        CreateMap<Service, ServiceUpdateDto>().ReverseMap();
        CreateMap<Service, ServiceGetDto>()
                         .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ServiceDetails.FirstOrDefault()!.Name))
                         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ServiceDetails.FirstOrDefault()!.Description));
    }
}
