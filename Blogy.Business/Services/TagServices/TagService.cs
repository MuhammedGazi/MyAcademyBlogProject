using AutoMapper;
using Blogy.Business.DTOs.TagDtos;
using Blogy.DataAccess.Repositories.TagRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.TagServices
{
    public class TagService(ITagRepository _repository,
                            IMapper _mapper,
                            IValidator<Tag> _validator) : ITagService
    {
        public async Task CreateAsync(CreateTagDto dto)
        {
            var tag = _mapper.Map<Tag>(dto);
            var result = await _validator.ValidateAsync(tag);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.CreateAsync(tag);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ResultTagDto>> GetAllAsync()
        {
            var tags = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultTagDto>>(tags);
        }

        public async Task<UpdateTagDto> GetByIdAsync(int id)
        {
            var tag = await _repository.GetByIdAsync(id);
            return _mapper.Map<UpdateTagDto>(tag);
        }

        public async Task<ResultTagDto> GetSingleByIdAsync(int id)
        {
            var tag = await _repository.GetByIdAsync(id);
            return _mapper.Map<ResultTagDto>(tag);
        }

        public async Task UpdateAsync(UpdateTagDto dto)
        {
            var tag = _mapper.Map<Tag>(dto);
            var result = await _validator.ValidateAsync(tag);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.UpdateAsync(tag);
        }
    }
}
