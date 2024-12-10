using Connex.Business.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Authorize(Roles ="Admin")]
[Area("Admin")]
public class AboutController : Controller
{
    private readonly IAboutService _service;

    public AboutController(IAboutService service)
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
    public async Task<IActionResult> Create(AboutCreateDto dto)
    {
        var result = await _service.CreateAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _service.GetUpdatedDtoAsync(id);

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(AboutUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
