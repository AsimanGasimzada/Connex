using Connex.Business.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
[AutoValidateAntiforgeryToken]
public class ProjectController : Controller
{
    private readonly IProjectService _service;

    public ProjectController(IProjectService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetAllAsync();

        return View(result);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectCreateDto dto)
    {
        var result = await _service.CreateAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var result = await _service.GetUpdatedDtoAsync(id);

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProjectUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult ShowPDF(string filename)
    {
        var filePath = Path.Combine("h:\\root\\home\\gadimovsabir-001\\www\\site6\\wwwroot\\documents", filename);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("PDF dosyası bulunamadı.");
        }

        return File(System.IO.File.ReadAllBytes(filePath), "application/pdf");
    }
}
