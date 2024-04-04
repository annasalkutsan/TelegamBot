using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class PersonService: IPersonRepository
    {
        public readonly IPersonRepository _personRepository;
        // TODO: реализовать crud
        
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetById(Guid id)
        {
            return _personRepository.GetById(id);
        }

        public List<Person> Get()
        {
            return _personRepository.Get();
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        public Person Update(Person person)
        {
            return _personRepository.Update(person);
        }

        public bool Delete(Guid id)
        {
            return _personRepository.Delete(id);
        }

        public List<CustomField<string>> GetCustomFields()
        {
            return _personRepository.GetCustomFields();
        }
    }
}