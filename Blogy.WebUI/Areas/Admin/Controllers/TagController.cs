using Blogy.Business.DTOs.TagDtos;
using Blogy.Business.Services.TagServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class TagController(ITagService _service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult CreateTag()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTag(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTag(UpdateTagDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTag(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
