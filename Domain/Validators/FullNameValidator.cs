using Domain.ValueObject;
using FluentValidation;
using Domain.Primitives;

namespace Domain.Validators
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        public FullNameValidator()
        {
            RuleFor(expression: x => x.FirstName)
                .NotNull().WithMessage(x => ValidationMessages.IsNull)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);
              
            RuleFor(expression: x => x.LastName)
                .NotNull().WithMessage(x => ValidationMessages.IsNull)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);

            RuleFor(expression: x => x.MiddleName)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);
        }
    }
}