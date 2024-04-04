using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    /// <summary>
    /// Класс для ФИО 
    /// </summary>
    public class FullName : BaseValueObject
    {
        public FullName(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // может быть отчеством
        // ? -- может быть null
        public string? MiddleName { get; set; } = null;
        /// <summary>
        /// Реализация DeepCompare с рефлексией
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool DeepCompare(FullName other)
        {
            if (other == null)
                return false;

            // получаем все свойства объекта текущего экземпляра 
            PropertyInfo[] properties = typeof(FullName).GetProperties();

            // проходимся по каждому свойству
            foreach (var property in properties)
            {
                // получаем значения свойств для текущего экземпляра (this) и для другого объекта (other)
                var thisValue = property.GetValue(this);
                var otherValue = property.GetValue(other);

                // сравниваем значения свойств
                if (!Equals(thisValue, otherValue))
                    return false;
            }

            // если все свойства эквивалентны
            return true;
        }
        /// <summary>
        /// Реализация DeepClone для FullName
        /// </summary>
        /// <returns></returns>
        public FullName DeepClone()
        {
            return new FullName(FirstName, LastName, MiddleName);
        }
    }
}
