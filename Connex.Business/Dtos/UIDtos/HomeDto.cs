namespace Connex.Business.Dtos;

public class HomeDto
{
    public List<SliderGetDto> Sliders { get; set; } = [];
    public List<ServiceGetDto> Services { get; set; } = [];
    public List<ProjectGetDto> Projects { get; set; } = [];
    public AboutGetDto? About { get; set; }
    public List<FeatureGetDto> Features { get; set; } = [];
    public List<CertificateGetDto> Certificates { get; set; } = [];
}
