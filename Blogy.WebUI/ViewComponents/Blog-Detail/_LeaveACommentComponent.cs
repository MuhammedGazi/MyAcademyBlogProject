using Blogy.Business.DTOs.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Blog_Detail
{
    public class _LeaveACommentComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var model = new CreateCommentDto
            {
                BlogId = id
            };
            return View(model);
        }
    }
}
