using Blogy.Business.DTOs.CommentDtos;

namespace Blogy.Business.Services.CommentServices
{
    public interface ICommentService : IGenericService<CreateCommentDto, UpdateCommentDto, ResultCommentDto>
    {
        Task<List<ResultCommentDto>> GetCommentByBlogId(int id);
    }
}
