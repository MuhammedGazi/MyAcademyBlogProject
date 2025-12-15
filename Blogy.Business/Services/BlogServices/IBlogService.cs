using Blogy.Business.DTOs.BlogDtos;

namespace Blogy.Business.Services.BlogServices
{
    public interface IBlogService : IGenericService<CreateBlogDto, UpdateBlogDto, ResultBlogDto>
    {
        Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync();
        Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId);
        Task<List<ResultBlogDto>> GetLast3BlogsAsync();
        Task<List<ResultBlogDto>> GetLast5BlogsAsync();
    }
}
