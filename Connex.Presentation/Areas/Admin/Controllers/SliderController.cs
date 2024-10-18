using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class SliderController : Controller
{
    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public async Task<IActionResult> Index()
    {
        var sliders = await _sliderService.GetAllAsync();

        return View(sliders);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderCreateDto dto)
    {
        var result = await _sliderService.CreateAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int id)
    {
        await _sliderService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var result = await _sliderService.GetUpdatedSliderAsync(id);

        if (result is null)
            return NotFound();

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SliderUpdateDto dto)
    {
        var result = await _sliderService.UpdateAsync(dto, ModelState);


        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }
}
