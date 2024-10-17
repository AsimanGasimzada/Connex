using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
