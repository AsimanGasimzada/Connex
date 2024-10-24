using Connex.Business.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Connex.Presentation.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Index()
    {
        var result=await _contactService.GetContactDtoAsync();

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactDto dto)
    {
        var result = await _contactService.SendEmailAsync(dto, ModelState);

        return RedirectToAction(nameof(Index)); 
            
    }
}
