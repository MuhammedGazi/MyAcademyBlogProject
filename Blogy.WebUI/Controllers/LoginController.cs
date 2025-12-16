using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class LoginController(SignInManager<AppUser> _signInManager,
                                 UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "kullanıcı adı veya şifre hatalı!");
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is not null)
            {
                if (await _userManager.IsInRoleAsync(user, Roles.Admin))
                {
                    return RedirectToAction("Index", "Blog", new { area = "Admin" });
                }
                if (await _userManager.IsInRoleAsync(user, Roles.Writer))
                {
                    return RedirectToAction("Index", "Blog", new { area = "Writer" });
                }
            }
            return RedirectToAction("Index", "Default");
        }
    }
}
