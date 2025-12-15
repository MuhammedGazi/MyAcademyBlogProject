using Blogy.Business.DTOs.BlogTagDtos;

namespace Blogy.Business.Services.BlogTagServices
{
    public interface IBlogTagService : IGenericService<CreateBlogTagDto, UpdateBlogTagDto, ResultBlogTagDto>
    {
        Task<List<ResultBlogTagDto>> TGetWithTagAndBlogAll();
    }
}
