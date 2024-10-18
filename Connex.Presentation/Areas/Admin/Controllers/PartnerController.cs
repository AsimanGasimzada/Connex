using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class PartnerController : Controller
{
    private readonly IPartnerService _partnerService;

    public PartnerController(IPartnerService partnerService)
    {
        _partnerService = partnerService;
    }

    public async Task<IActionResult> Index()
    {
        var partners = await _partnerService.GetAllAsync();

        return View(partners);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(PartnerCreateDto dto)
    {
        var result = await _partnerService.CreateAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Update(int id)
    {
        var result = await _partnerService.GetUpdatedPartnerAsync(id);

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(PartnerUpdateDto dto)
    {
        var result=await _partnerService.UpdateAsync(dto,ModelState);

        if(result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _partnerService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
