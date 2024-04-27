using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Primitives;
using Domain.Validators;
using Domain.ValueObject;
using FluentValidation;

namespace Domain.Entities
{
    /// <summary>
    /// Класс для пользователя
    /// </summary>
    public class Person : BaseEntity
    {
        //для EF 
        public Person(){}
        public Person(FullName fullName, DateTime birthDay, string phoneNumber, string telegram, Gender gender, List<CustomField<string>> customFields)
        {
            FullName = fullName;
            BirthDay = birthDay;
            PhoneNumber = phoneNumber;
            Telegram = telegram;
            Gender = gender;
            CustomFields = customFields;

            var validator = new PersonValidator();
            validator.ValidateAndThrow(this);
        }

        public FullName FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public Gender Gender { get; set; }
        public List<CustomField<string>> CustomFields { get; set; }

        public Person Update(string? fistName, string? lastName, string? middleName, string phoneNumber)
        {
            FullName.Update(fistName, lastName, middleName);
            PhoneNumber = phoneNumber;

            var validator = new PersonValidator();
            validator.ValidateAndThrow(this);

            return this;
        }
    }
}
