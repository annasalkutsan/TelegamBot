using System;
using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IRepository <TEntity>
    {
        public TEntity GetById(Guid id);
        public List<TEntity> GetAll();
        TEntity Create(TEntity person);
        public TEntity Update(TEntity person);
        public bool Delete(Guid id);
    }
}