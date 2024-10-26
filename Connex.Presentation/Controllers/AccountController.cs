using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Controllers;

public class AccountController : Controller
{
    public IActionResult Login(string? returnUrl)
    {
        return RedirectToAction("Login", "Account", new { area = "admin", returnUrl = returnUrl });
    }
}
