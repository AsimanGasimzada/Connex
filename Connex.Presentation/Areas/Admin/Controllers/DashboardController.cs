using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
