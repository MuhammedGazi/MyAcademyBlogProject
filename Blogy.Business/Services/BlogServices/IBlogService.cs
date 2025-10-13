using Blogy.Business.DTOs.BlogDtos;

namespace Blogy.Business.Services.BlogServices
{
    public interface IBlogService:IGenericService<CreateBlogDto,UpdateBlogDto,ResultBlogDto>
    {
        Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync();
    }
}
