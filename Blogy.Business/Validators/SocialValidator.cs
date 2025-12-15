using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class SocialValidator : AbstractValidator<Social>
    {
        public SocialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name boş geçilemez");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Name boş geçilemez");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Name boş geçilemez");
        }
    }
}
