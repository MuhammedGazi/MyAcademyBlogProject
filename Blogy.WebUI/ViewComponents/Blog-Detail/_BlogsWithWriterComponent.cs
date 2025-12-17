using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Blog_Detail
{
    public class _BlogsWithWriterComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var response = await _userManager.FindByIdAsync(id.ToString());
            var model = new ResultUserDto
            {
                FullName = response.FirtName + " " + response.LastName,
                ImageUrl = response.ImageUrl,
                Email = response.Email
            };
            return View(model);
        }
    }
}
