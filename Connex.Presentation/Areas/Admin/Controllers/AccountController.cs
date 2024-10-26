using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Areas.Admin.Controllers;
[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class AccountController : Controller
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _service.LoginAsync(dto, ModelState);

        if (result is false)
            return View(dto);

        if (dto.ReturnUrl is not null)
            return Redirect(dto.ReturnUrl);

        return RedirectToAction("Index", "Dashboard");
    }

    public async Task<IActionResult> Logout()
    {
        var result=await _service.LogoutAsync();

        if(result is false)
            return RedirectToAction(nameof(Login));

        return RedirectToAction("Index", "Home", new { area = "null" });
    }
}
