using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    /// <summary>
    /// Базовый класс для объектов-значений
    /// </summary>
    public abstract class BaseValueObject
    {
        public override bool Equals(object? obj)
        {
            if (obj is not BaseValueObject entity || entity == null)
                return false;

            var serialEnti = Serialize(entity);
            var serialThis = Serialize(this);

            ///TODO: Разобраться в String.Compare
            if (String.Compare(serialEnti, serialThis) != 0)
                return false;

            return true;
        }

        /// <summary>
        /// Переопределение метода для получения хэш-кода объекта.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            //TODO:Реализовать getHashCode
            //У string получать код легче + 
            return Serialize(this).GetHashCode();
        }

        /// <summary>
        /// Сериализация данных в json
        /// </summary>
        /// <param name="valueObjects"></param>
        /// <returns></returns>
        private string Serialize(BaseValueObject valueObjects)
        {
            var serializedObjects = JsonSerializer.Serialize(valueObjects);
            return serializedObjects;
        }
        
    }
}
