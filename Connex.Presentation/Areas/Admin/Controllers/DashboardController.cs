using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles ="Admin")]
[AutoValidateAntiforgeryToken]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
