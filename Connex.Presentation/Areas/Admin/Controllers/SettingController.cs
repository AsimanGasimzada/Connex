﻿using Connex.Business.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
[AutoValidateAntiforgeryToken]
public class SettingController : Controller
{
    private readonly ISettingService _service;

    public SettingController(ISettingService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _service.GetAllAsync();

        return View(result);
    }

    public async Task<IActionResult> Update(int id)
    {
        var result = await _service.GetUpdatedDtoAsync(id);

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SettingUpdateDto dto)
    {
        var result = await _service.UpdateAsync(dto, ModelState);

        if(result is false)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }
}
