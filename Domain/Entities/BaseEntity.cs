using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Базовый класс для сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not BaseEntity entity) return false;
            if (Id != entity.Id) return false;
            return this.GetHashCode() == entity.GetHashCode(); 
            //referencequals
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
