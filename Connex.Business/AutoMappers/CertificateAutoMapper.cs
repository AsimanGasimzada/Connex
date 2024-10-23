using AutoMapper;

namespace Connex.Business.AutoMappers;

public class CertificateAutoMapper : Profile
{
    public CertificateAutoMapper()
    {
        CreateMap<Certificate, CertificateCreateDto>().ReverseMap();
        CreateMap<Certificate, CertificateUpdateDto>().ReverseMap().ForMember(x => x.ImagePath, x => x.Ignore());
        CreateMap<Certificate, CertificateGetDto>().ReverseMap();
    }
}
