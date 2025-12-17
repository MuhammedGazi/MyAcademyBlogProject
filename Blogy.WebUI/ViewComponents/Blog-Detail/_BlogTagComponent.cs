using Blogy.Business.Services.TagServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Blog_Detail
{
    public class _BlogTagComponent(ITagService _tagService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _tagService.GetAllAsync();
            return View(response);
        }
    }
}
