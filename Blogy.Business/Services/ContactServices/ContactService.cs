using AutoMapper;
using Blogy.Business.DTOs.ContactDtos;
using Blogy.DataAccess.Repositories.ContactRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.ContactServices
{
    public class ContactService(IContactRepository _repository,
                                IMapper _mapper,
                                IValidator<Contact> _validator) : IContactService
    {
        public async Task CreateAsync(CreateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            var result = await _validator.ValidateAsync(contact);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.CreateAsync(contact);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var contacts = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultContactDto>>(contacts);
        }

        public async Task<UpdateContactDto> GetByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            return _mapper.Map<UpdateContactDto>(contact);

        }

        public async Task<ResultContactDto> GetSingleByIdAsync(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            return _mapper.Map<ResultContactDto>(contact);
        }

        public async Task UpdateAsync(UpdateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            var result = await _validator.ValidateAsync(contact);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _repository.UpdateAsync(contact);
        }
    }
}
