using System;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class PersonService
    {
        public readonly IPersonRepository _personRepository;
        public Person GetById(Guid id)
        {
            var person = _personRepository.GetById(id);
            return person;
        }
        // реализовать crud
    }
}