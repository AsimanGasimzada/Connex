using Connex.Business.Dtos;
using Connex.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Connex.Presentation.Controllers;

public class HomeController : Controller
{
    
    public async Task<IActionResult> Index()
    {
        return View();
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

}
