using AutoMapper;

namespace Connex.Business.AutoMappers;

public class ServiceDetailAutoMapper : Profile
{
    public ServiceDetailAutoMapper()
    {
        CreateMap<ServiceDetail, ServiceDetailCreateDto>().ReverseMap();
        CreateMap<ServiceDetail, ServiceDetailUpdateDto>().ReverseMap();
    }
}
