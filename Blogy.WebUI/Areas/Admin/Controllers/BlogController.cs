using System.Threading.Tasks;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =$"{Roles.Admin}")]
    public class BlogController(IBlogService _blogService, ICategoryService _categoryService) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.CategoryName,
                                      Value = category.Id.ToString()
                                  }).ToList();
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithCategoriesAsync();
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await GetCategoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(blogDto);
            }
            await _blogService.CreateAsync(blogDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            await GetCategoriesAsync();
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(blogDto);
            }
            await _blogService.UpdateAsync(blogDto);
            return RedirectToAction("Index");
        }
    }
}
