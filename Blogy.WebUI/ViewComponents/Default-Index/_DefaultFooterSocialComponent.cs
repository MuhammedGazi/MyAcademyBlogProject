using Blogy.Business.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultFooterSocialComponent(ISocialService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var social = await _service.GetAllAsync();
            return View(social);
        }
    }
}
