using System;
using Domain.Entities;
using Domain.Primitives;
using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.FullName.FirstName)
                .NotNull().WithMessage(x => ValidationMessages.IsNull)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);
              
            RuleFor(person => person.FullName.LastName)
                .NotNull().WithMessage(x => ValidationMessages.IsNull)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);

            RuleFor(person => person.FullName.MiddleName)
                .NotEmpty().WithMessage(x => ValidationMessages.IsEmpty)
                .Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage(ValidationMessages.IsRight);

            RuleFor(person => person.BirthDay).Must(BeAValidBirthDay).WithMessage("Дата рождения некорректна.");
            RuleFor(person => person.PhoneNumber).Matches(@"^\+37377[4-9][0-9]{5}$").WithMessage("Номер телефона некорректен.");
            RuleFor(person => person.Telegram).Matches("^@").WithMessage("Никнейм в телеграм некорректен.");
        }

        private bool BeAValidBirthDay(DateTime birthDay)
        {
            return birthDay.Year >= (DateTime.Today.Year - 150);
        }
    }
}

