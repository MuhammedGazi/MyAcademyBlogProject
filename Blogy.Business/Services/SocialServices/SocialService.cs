using AutoMapper;
using Blogy.Business.DTOs.SocialDtos;
using Blogy.DataAccess.Repositories.SocialRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.SocialServices
{
    public class SocialService(ISocialRepository _repository,
                                IMapper _mapper,
                                IValidator<Social> _validator) : ISocialService
    {
        public async Task CreateAsync(CreateSocialDto dto)
        {
            var social = _mapper.Map<Social>(dto);
            var result = await _validator.ValidateAsync(social);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.CreateAsync(social);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ResultSocialDto>> GetAllAsync()
        {
            var socials = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultSocialDto>>(socials);
        }

        public async Task<UpdateSocialDto> GetByIdAsync(int id)
        {
            var social = await _repository.GetByIdAsync(id);
            return _mapper.Map<UpdateSocialDto>(social);
        }

        public async Task<ResultSocialDto> GetSingleByIdAsync(int id)
        {
            var social = await _repository.GetByIdAsync(id);
            return _mapper.Map<ResultSocialDto>(social);
        }

        public async Task UpdateAsync(UpdateSocialDto dto)
        {
            var social = _mapper.Map<Social>(dto);
            var result = await _validator.ValidateAsync(social);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.UpdateAsync(social);
        }
    }
}
