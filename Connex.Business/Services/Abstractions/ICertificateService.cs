namespace Connex.Business.Services.Abstractions;

public interface ICertificateService : IService<CertificateCreateDto, CertificateUpdateDto>, IGetService<CertificateGetDto>
{
}
