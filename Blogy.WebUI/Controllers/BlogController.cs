using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.AiServices;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blogy.WebUI.Controllers
{
    public class BlogController(IBlogService _blogService, ICategoryService _categoryService,
                                IMapper _mapper,
                                ICommentService _commentService,
                                IGeminiAiService _aiService,
                                UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
        {
            var blogs = await _blogService.GetAllAsync();
            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);
            return View(values);
        }

        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            ViewBag.categoryName = category.Name;
            var blogs = await _blogService.GetBlogsByCategoryIdAsync(id);
            return View(blogs);
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _blogService.GetSingleByIdAsync(id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> SendComment(CreateCommentDto dto)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Yorum yapmak için giriş yapmalısınız." });
            }

            bool isSafe = await _aiService.IsCommentSafeAsync(dto.Content);

            if (!isSafe)
            {
                return Json(new { success = false, message = "Yorumunuz topluluk kurallarına aykırı olduğu için reddedildi." });
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                dto.UserId = user.Id;

                await _commentService.CreateAsync(dto);

                return Json(new { success = true, message = "Yorumunuz başarıyla kaydedildi." });
            }

            return Json(new { success = false, message = "Kullanıcı bulunamadı." });
        }
    }
}
