using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject boş geçilemez");
        }
    }
}
