using Blogy.Business.DTOs.BlogDtos;

namespace Blogy.Business.Services.BlogServices
{
    public interface IBlogService:IGenericService<CreateBlogDto,UpdateBlogDto,ResultBlogDto>
    {
        Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync();
        Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId);
    }
}
