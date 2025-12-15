using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.BlogTagServices;
using Blogy.Business.Services.TagServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class BlogTagController(IBlogTagService _service,
                                   ITagService _tagService,
                                   IBlogService _blogService) : Controller
    {
        public async Task GetWithTagAndBlog()
        {
            var tags = await _tagService.GetAllAsync();
            ViewBag.Tags = (from tag in tags
                            select new SelectListItem
                            {
                                Value = tag.Id.ToString(),
                                Text = tag.Name
                            }).ToList();

            var blogs = await _blogService.GetAllAsync();
            ViewBag.Blogs = (from blog in blogs
                             select new SelectListItem
                             {
                                 Value = blog.Id.ToString(),
                                 Text = blog.Title
                             }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            //var response = await _service.GetAllAsync();
            var response = await _service.TGetWithTagAndBlogAll();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlogTag()
        {
            await GetWithTagAndBlog();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogTag(CreateBlogTagDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetWithTagAndBlog();
                return View(dto);
            }
            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlogTag(int id)
        {
            var response = await _service.GetByIdAsync(id);
            await GetWithTagAndBlog();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlogTag(UpdateBlogTagDto dto)
        {
            if (!ModelState.IsValid)
            {
                await GetWithTagAndBlog();
                return View(dto);
            }
            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBlogTag(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
