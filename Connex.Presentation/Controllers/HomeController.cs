using Connex.Business.Dtos;
using Connex.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Connex.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IHomeService _service;
    private readonly ISubscriberService _subscriberService;

    public HomeController(IHomeService service, ISubscriberService subscriberService)
    {
        _service = service;
        _subscriberService = subscriberService;
    }

    public async Task<IActionResult> Index(string? lang)
    {
        var language = _getLangueage(lang);

        var dto = await _service.GetHomeDtoAsync(language);

        return View(dto);
    }

    public async Task<IActionResult> AddSubscriber(SubscriberCreateDto dto, string returnUrl = "")
    {
        var result = await _subscriberService.CreateAsync(dto, ModelState);

        return Redirect(returnUrl);
    }

    public IActionResult Error(string json)
    {
        if (!string.IsNullOrEmpty(json))
        {
            var dto = JsonConvert.DeserializeObject<ErrorDto>(json);
            return View(dto);
        }

        return View(new ErrorDto
        {
            StatusCode = 500,
            Message = "An unexpected error occurred."
        });
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
