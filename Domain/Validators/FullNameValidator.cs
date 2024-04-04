using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validators
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        /// <summary>
        /// TODO прописать вадидаторы 
        /// </summary>
        public FullNameValidator()
        {
            /*RuleFor(expression: x => x.FirstName)
                .NotNull().WithMessage(x => "".notnull)
                .NotEmpty().WithMessage(x => "".notepmty)
                .Matches(expression:@)
                .WithMessan()*/
        }
    }
}