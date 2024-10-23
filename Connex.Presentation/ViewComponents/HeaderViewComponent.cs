using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Connex.Presentation.ViewComponents;

public class HeaderViewComponent : ViewComponent
{
    private readonly ISettingService _settingService;
    private readonly ILanguageService _languageService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HeaderViewComponent(ISettingService settingService, ILanguageService languageService, IHttpContextAccessor httpContextAccessor)
    {
        _settingService = settingService;
        _languageService = languageService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var settings = await _settingService.GetAllWithDictionaryAsync();
        var languages = await _languageService.GetAllAsync();


        string? language = _httpContextAccessor.HttpContext?.Request.Query["lang"];

        if (string.IsNullOrEmpty(language))
            language = "az";

        var selectedLanguage = await _languageService.GetWithCodeAsync(language);



        HeaderDto dto = new HeaderDto()
        {
            Settings = settings,
            Languages = languages,
            SelectedLanguage=selectedLanguage
        };

        return View(dto);
    }
}
