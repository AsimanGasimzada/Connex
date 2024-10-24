using Connex.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Controllers;

public class ServiceController : Controller
{
    private readonly IServiceService _service;

    public ServiceController(IServiceService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index(string? lang)
    {
        var language = _getLangueage(lang);

        var result = await _service.GetAllAsync(language);

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
