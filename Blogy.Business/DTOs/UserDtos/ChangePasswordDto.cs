using System.ComponentModel.DataAnnotations;

namespace Blogy.Business.DTOs.UserDtos
{
    public class ChangePasswordDto
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword),ErrorMessage ="şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
    }
}
