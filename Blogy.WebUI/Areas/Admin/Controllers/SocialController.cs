using Blogy.Business.DTOs.SocialDtos;
using Blogy.Business.Services.SocialServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class SocialController(ISocialService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult CreateSocial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocial(CreateSocialDto dto)
        {
            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocial(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocial(UpdateSocialDto dto)
        {
            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSocial(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
