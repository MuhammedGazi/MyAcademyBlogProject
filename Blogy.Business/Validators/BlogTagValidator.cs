using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class BlogTagValidator : AbstractValidator<BlogTag>
    {
        public BlogTagValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("BlogId boş bırakılamaz");
            RuleFor(x => x.TagId).NotEmpty().WithMessage("BlogId boş bırakılamaz");
        }
    }
}
