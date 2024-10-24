
using Connex.Core.Enums;

namespace Connex.Business.Services.Implementations;

public class HomeService : IHomeService
{
    private readonly ISliderService _sliderService;
    private readonly IServiceService _serviceService;
    private readonly IAboutService _aboutService;
    private readonly IProjectService _projectService;
    private readonly IFeatureService _featureService;
    private readonly ICertificateService _certificateService;
    private readonly IPartnerService _partnerService;
    public HomeService(IServiceService serviceService, ISliderService sliderService, IAboutService aboutService, IProjectService projectService, IFeatureService featureService, ICertificateService certificateService, IPartnerService partnerService)
    {
        _serviceService = serviceService;
        _sliderService = sliderService;
        _aboutService = aboutService;
        _projectService = projectService;
        _featureService = featureService;
        _certificateService = certificateService;
        _partnerService = partnerService;
    }

    public async Task<HomeDto> GetHomeDtoAsync(Languages language = Languages.Azerbaijan)
    {
        HomeDto dto = new HomeDto()
        {
            Services = (await _serviceService.GetAllAsync(language)).Take(3).ToList(),
            Sliders = await _sliderService.GetAllAsync(language),
            About = (await _aboutService.GetAllAsync(language)).FirstOrDefault(),
            Projects = (await _projectService.GetAllAsync(language)).Take(3).ToList(),
            Features = await _featureService.GetAllAsync(language),
            Certificates = await _certificateService.GetAllAsync(),
            Partners = await _partnerService.GetAllAsync()
        };

        return dto;
    }
}
