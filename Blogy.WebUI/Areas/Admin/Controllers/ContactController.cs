using Blogy.Business.Services.ContactServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class ContactController(IContactService contactService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await contactService.GetAllAsync();
            return View(response);
        }
    }
}
