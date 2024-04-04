using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepository <TEntity>
    {
        public TEntity GetById(Guid id);
        public List<TEntity> Get();
        public TEntity Create(TEntity person);
        public TEntity Update(TEntity person);
        public bool Delete(Guid id);
    }
}