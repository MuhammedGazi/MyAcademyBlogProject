using AutoMapper;
using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.DataAccess.Repositories.BlogTagRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.BlogTagServices
{
    public class BlogTagService(IBlogTagRepository _repository,
                                IMapper _mapper,
                                IValidator<BlogTag> _validator) : IBlogTagService
    {
        public async Task CreateAsync(CreateBlogTagDto dto)
        {
            var blogTag = _mapper.Map<BlogTag>(dto);
            var result = await _validator.ValidateAsync(blogTag);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.CreateAsync(blogTag);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ResultBlogTagDto>> GetAllAsync()
        {
            var blogTags = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultBlogTagDto>>(blogTags);
        }

        public async Task<UpdateBlogTagDto> GetByIdAsync(int id)
        {
            var blogTag = await _repository.GetByIdAsync(id);
            return _mapper.Map<UpdateBlogTagDto>(blogTag);
        }

        public async Task<ResultBlogTagDto> GetSingleByIdAsync(int id)
        {
            var blogTag = await _repository.GetByIdAsync(id);
            return _mapper.Map<ResultBlogTagDto>(blogTag);
        }

        public async Task<List<ResultBlogTagDto>> TGetWithTagAndBlogAll()
        {
            var blogTags = await _repository.GetWithTagAndBlogAll();
            return _mapper.Map<List<ResultBlogTagDto>>(blogTags);
        }

        public async Task UpdateAsync(UpdateBlogTagDto dto)
        {
            var blogTag = _mapper.Map<BlogTag>(dto);
            var result = await _validator.ValidateAsync(blogTag);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.UpdateAsync(blogTag);
        }
    }
}
