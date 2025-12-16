using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Business.Services.UserServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area(Roles.Writer)]
    public class ProfileController(IUserService _userService,
                                    UserManager<AppUser> _userManager,
                                    IMapper _mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ProfileDetails()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _mapper.Map<EditProfileDto>(user);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileDetails(EditProfileDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            dto.UserId = user.Id;
            if (dto.ImageFile == null)
            {
                dto.ImageUrl = user.ImageUrl;
            }
            var isSuccess = await _userService.EditProfile(dto);
            if (!isSuccess)
            {
                ModelState.AddModelError("", "Güncelleme başarısız oldu.");
                return View(user);
            }
            return RedirectToAction("ProfileDetails");

        }

        [HttpGet]
        public async Task<IActionResult> ChangePass()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new ChangePasswordDto
            {
                UserId = user.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePass(ChangePasswordDto dto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var isSuccess = await _userService.ChangePassword(dto);
            if (!isSuccess)
            {
                return View();
            }
            return RedirectToAction("ProfileDetails");
        }
    }
}
