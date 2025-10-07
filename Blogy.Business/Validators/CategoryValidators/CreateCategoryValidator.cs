using Blogy.Business.DTOs.CategoryDtos;
using FluentValidation;

namespace Blogy.Business.Validators.CategoryValidators
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(RuleFor => RuleFor.Name).NotEmpty().WithMessage("Category ismi boş geçilemez");
            RuleFor(RuleFor => RuleFor.Name).MaximumLength(50).WithMessage("Category ismi en fazla 50 karakter olabilir");
        }
    }
}
