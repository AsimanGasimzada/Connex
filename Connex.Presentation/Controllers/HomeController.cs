using Connex.Business.Dtos;
using Connex.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Connex.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAccountService _accountService;
    private readonly ISliderService _sliderService;
    private Languages _language;
    public HomeController(ILogger<HomeController> logger, IAccountService accountService, ISliderService sliderService)
    {
        _logger = logger;
        _accountService = accountService;
        _sliderService = sliderService;
        _language = Languages.Azerbaijan;
    }

    public async Task<IActionResult> Index()
    {
        await _sliderService.GetAllAsync(_language);
        return View();
    }


    public IActionResult ChangeLanguage(Languages language)
    {
        _language = language;

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> VerifyEmail(VerifyEmailDto dto)
    {
        await _accountService.VerifyEmailAsync(dto, ModelState);

        return Json("OK");
    }
    public IActionResult Error(string json)
    {
        var dto = JsonConvert.DeserializeObject<ErrorDto>(json);

        return View(dto);
    }
    public async Task<IActionResult> Test(int language = 1)
    {
        var result = await _sliderService.GetAllAsync((Languages)language);
        return Json(result);
    }


}
