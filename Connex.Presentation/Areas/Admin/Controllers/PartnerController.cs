using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class PartnerController : Controller
{
    private readonly IPartnerService _service;

    public PartnerController(IPartnerService partnerService)
    {
        _service = partnerService;
    }

    public async Task<IActionResult> Index()
    {
        var partners = await _service.GetAllAsync();

        return View(partners);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(PartnerCreateDto dto)
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
    public async Task<IActionResult> Update(PartnerUpdateDto dto)
    {
        var result=await _service.UpdateAsync(dto,ModelState);

        if(result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
