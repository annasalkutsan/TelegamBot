using System;
using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepository <TEntity>
    {
        public TEntity GetById(Guid id);
        public List<TEntity> GetAll();
        Task<Person> Create(TEntity person);
        public TEntity Update(TEntity person);
        public bool Delete(Guid id);
        public Task SaveChanges();
    }
}