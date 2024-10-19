using Microsoft.AspNetCore.Http;

namespace Connex.Business.Dtos;

public class ProjectCreateDto : IDto
{
    public IFormFile Image { get; set; } = null!;
    public List<ProjectDetailCreateDto> ProjectDetails { get; set; } = new();
}
