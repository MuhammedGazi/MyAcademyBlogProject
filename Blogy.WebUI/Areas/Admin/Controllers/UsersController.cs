using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    public class UsersController(UserManager<AppUser> _userManager, IMapper _mapper, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var mappedUsers = _mapper.Map<List<ResultUserDto>>(users);
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in mappedUsers)
                {
                    role.Roles = userRoles;
                }
            }
            return View(mappedUsers);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewBag.fullName = user.FirtName + " " + user.LastName;
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var assignRoleList = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                assignRoleList.Add(new AssignRoleDto
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                    RoleName = role.Name,
                    RoleExists = userRoles.Contains(role.Name)
                });
            }
            return View(assignRoleList);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleDtos)
        {
            var userId=assignRoleDtos.Select(x=>x.UserId).FirstOrDefault();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            foreach (var item in assignRoleDtos)
            {
                if (item.RoleExists)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
