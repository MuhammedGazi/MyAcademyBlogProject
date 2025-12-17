using Blogy.Business.DTOs.ContactDtos;
using Blogy.Business.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class DefaultController(IContactService _contactService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CreateContactDto dto)
        {
            await _contactService.CreateAsync(dto);
            return RedirectToAction(nameof(Contact));
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
