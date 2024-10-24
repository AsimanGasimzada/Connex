using Connex.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Controllers;

public class AboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IActionResult> Index(string? lang)
    {
        var langugae = _getLangueage(lang);

        var result = await _aboutService.GetAllAsync(langugae);
        return View(result);
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
