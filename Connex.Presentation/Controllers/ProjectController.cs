using Connex.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Controllers;

public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IActionResult> Index(string? lang)
    {
        var language = _getLangueage(lang);
        var result = await _projectService.GetAllAsync(language);

        return View(result);
    }

    public async Task<IActionResult> Detail(int id, string? lang)
    {
        var language = _getLangueage(lang);

        var result = await _projectService.GetAsync(id, language);

        return View(result);
    }


    public IActionResult ShowPDF(string filename)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents", filename);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("PDF dosyası bulunamadı.");
        }

        return File(System.IO.File.ReadAllBytes(filePath), "application/pdf");
    }
    private Languages _getLangueage(string? lang)
    {
        if (string.IsNullOrEmpty(lang))
            return Languages.Azerbaijan;

        if (lang.ToLower() == "en")
            return Languages.English;
        else if (lang.ToLower() == "ru")
            return Languages.Russian;

        return Languages.Azerbaijan;
    }
}
