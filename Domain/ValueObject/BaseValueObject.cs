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
        /// <summary>
        /// Реализует сравнение DeepCompare
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var json = JsonSerializer.Serialize(this);
            var otherJson = JsonSerializer.Serialize(obj);

            var compare = String.Compare(json, otherJson, StringComparison.InvariantCultureIgnoreCase);

            return compare == 0;
        }

        /// <summary>
        /// Получает HashCode из сериализаованной сущности
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var json = JsonSerializer.Serialize(this);
            return json.GetHashCode();
        }
    }
}
