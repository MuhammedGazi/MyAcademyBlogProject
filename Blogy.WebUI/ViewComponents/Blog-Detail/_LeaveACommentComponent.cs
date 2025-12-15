using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Blog_Detail
{
    public class _LeaveACommentComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
