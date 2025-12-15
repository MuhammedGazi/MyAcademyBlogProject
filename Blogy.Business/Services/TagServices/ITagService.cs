using Blogy.Business.DTOs.TagDtos;

namespace Blogy.Business.Services.TagServices
{
    public interface ITagService : IGenericService<CreateTagDto, UpdateTagDto, ResultTagDto>
    {
    }
}
