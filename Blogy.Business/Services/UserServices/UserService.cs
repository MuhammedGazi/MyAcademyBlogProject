using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Blogy.Business.Services.UserServices
{
    public class UserService(SignInManager<AppUser> _signInManager,
                             UserManager<AppUser> _userManager,
                             IMapper _mapper) : IUserService
    {
        public async Task<bool> ChangePassword(ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user is null)
            {
                return false;
            }
            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            return result.Succeeded;
        }

        public async Task<bool> EditProfile(EditProfileDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user is null) return false;
            _mapper.Map(dto, user);
            if (dto.ImageFile != null)
            {
                var extension = Path.GetExtension(dto.ImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await dto.ImageFile.CopyToAsync(stream);
                }
                user.ImageUrl = "/images/" + newImageName;
            }
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return false;
            await _signInManager.RefreshSignInAsync(user);
            return true;
        }
    }
}
