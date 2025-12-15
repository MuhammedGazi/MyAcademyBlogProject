using Blogy.Business.DTOs.Common;

namespace Blogy.Business.DTOs.BlogTagDtos
{
    public class UpdateBlogTagDto : BaseDto
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
    }
}
