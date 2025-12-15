using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBannerComponent(IBlogService _service) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var last5Blogs = await _service.GetLast5BlogsAsync();
            return View(last5Blogs);
        }
    }
}
