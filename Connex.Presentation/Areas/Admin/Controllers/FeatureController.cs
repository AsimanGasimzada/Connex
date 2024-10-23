using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class FeatureController : Controller
{
    private readonly IFeatureService _service;

    public FeatureController(IFeatureService featureService)
    {
        _service = featureService;
    }


    public async Task<IActionResult> Index()
    {
        var Features = await _service.GetAllAsync();

        return View(Features);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(FeatureCreateDto dto)
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

        if (result is null)
            return NotFound();

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(FeatureUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto, ModelState);


        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }
}
