using Blogy.Entity.Entities;
using FluentValidation;
using System.Security.Cryptography.Xml;

namespace Blogy.Business.Validators
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("kullanıcı boş bırakılamaz");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("blog boş bırakılamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("yorum  içeriği boş bırakılamaz")
                .MaximumLength(50).WithMessage("yorum içeriği 50 karakterden uzun olamaz");
        }
    }
}
