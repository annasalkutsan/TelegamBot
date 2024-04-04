using Domain.ValueObject;
using FluentValidation;
using Domain.Primitives;

namespace Domain.Validators
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        // TODO прописать вадидаторы
        public FullNameValidator()
        {
            RuleFor(expression: x => x.FirstName)
                .NotNull().WithMessage(x => ValidationMessages.IsNull)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(expression: @"^[a-zA-Zа-яА-Я]+$")
                .WithMessage(x => ValidationMessages.IsRight);
            RuleFor(expression: x => x.LastName)
                .NotNull().WithMessage(x => ValidationMessages.IsNull)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(expression: @"^[a-zA-Zа-яА-Я]+$")
                .WithMessage(x => ValidationMessages.IsRight);
            RuleFor(expression: x => x.MiddleName)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(expression: @"^[a-zA-Zа-яА-Я]+$")
                .WithMessage(x => ValidationMessages.IsRight);
        }
    }
}