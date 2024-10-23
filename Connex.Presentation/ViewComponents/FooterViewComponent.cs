using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    private readonly ISettingService _settingService;

    public FooterViewComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var settings = await _settingService.GetAllWithDictionaryAsync();

        return View(settings);
    }
}
