using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Primitives;
using Domain.ValueObject;

namespace Domain.Entities
{
    /// <summary>
    /// Класс для пользователя
    /// </summary>
    public class Person : BaseEntity
    {
        public Person(FullName fullName)
        {
           /* var fullNameValidator = new bool();
            //TODO: провалидировать все поля */
        }
        public Person(FullName fullName, DateTime birthDay, string phoneNumber, string telegram, Gender gender)
        {
            FullName = ValidateFullName(fullName);
            BirthDay = ValidateBirthDay(birthDay);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            Telegram = ValidateTelegram(telegram);
            Gender = gender;
        }
        public FullName FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public string PhoneNumber { get; set; }
        public string Telegram { get; set; }
        public Gender Gender { get; set; }

        ///TODO: Посмотреть в сторону fluenValidator, анализ Guard в чем отличие

        /// <summary>
        /// Метод для валидации ФИО
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private FullName ValidateFullName(FullName fullName)
        {
            if (string.IsNullOrEmpty(fullName.FirstName) || (string.IsNullOrEmpty(fullName.LastName))) 
                throw new ArgumentException("Эти данные обязательны для заполнения.");

            string pattern = @"^[a-zA-Zа-яА-Я]+$";

            if (!Regex.IsMatch(fullName.FirstName, pattern)) throw new ArgumentException(ValidetorsMessages.IsRight);
            
            if (!Regex.IsMatch(fullName.LastName, pattern)) throw new ArgumentException(ValidetorsMessages.IsRight);
            
            if (fullName.MiddleName is not null)
            {
                if (fullName.MiddleName == string.Empty) throw new ArgumentException(ValidetorsMessages.IsNullOrEmpty);
                
                if (!Regex.IsMatch(fullName.MiddleName, pattern)) throw new ArgumentException(ValidetorsMessages.IsRight);
            }
            return fullName;
        }

        /// <summary>
        /// Метод для валидации даты рождения
        /// </summary>
        /// <param name="birthDay"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private DateTime ValidateBirthDay(DateTime birthDay)
        {
            if (birthDay.Year<DateTime.Today.Year - 150) throw new ArgumentException(ValidetorsMessages.IsRight);
            return birthDay;
        }

        /// <summary>
        /// Метод для валидации номера телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private string ValidatePhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\+37377[4-9][0-9]{5}$";
            //^ начало строки.
            //\+373 77 обозначает первые 6 символов, которые должны быть "+373 77".
            //[4 - 9] требует, чтобы следующий символ после "+373 77" был в диапазоне от 4 до 9.
            //\d{ 5} указывает на 5 последующих цифр.
            if (!Regex.IsMatch(phoneNumber, phonePattern)) throw new ArgumentException(ValidetorsMessages.IsRight);
            return phoneNumber;
        }

        /// <summary>
        /// Метод для валидации никнейма в телеграм
        /// </summary>
        /// <param name="telegram"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private string ValidateTelegram(string telegram)
        {
            string telegramPattern = "^@";
            if (!Regex.IsMatch(telegram, telegramPattern)) throw new ArgumentException(ValidetorsMessages.IsRight);
            return telegram;
        }
    }
}
