using Connex.Business.Dtos;
using Connex.Business.Services.Abstractions;
using Connex.Core.Enums;
using Connex.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Connex.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;
        private readonly ISliderService _sliderService;
        public HomeController(ILogger<HomeController> logger, IAccountService accountService, ISliderService sliderService)
        {
            _logger = logger;
            _accountService = accountService;
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VerifyEmail(VerifyEmailDto dto)
        {
            await _accountService.VerifyEmailAsync(dto, ModelState);

            return Json("OK");
        }
        public async Task<IActionResult> Test(int language=1)
        {
            var result = await _sliderService.GetAllAsync((Languages)language);
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
