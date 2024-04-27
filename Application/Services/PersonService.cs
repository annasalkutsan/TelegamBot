using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Application.DTOs;
using Application.MappingProfiles;
using AutoMapper;

namespace Application.Services
{
    public class PersonService<PersonCreateResponse>
    {
        public readonly IPersonRepository _personRepository;
        public readonly IMapper _mapper;
        // TODO: реализовать crud
        
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public PersonGetByResponse GetById(Guid id)
        {
            var person = _personRepository.GetById(id);
            var model = _mapper.Map<PersonGetByResponse>(person);

            return model;
        }

        public List<PersonGetAllResponse> Get()
        {
            var persons = _personRepository.GetAll();
            var model = _mapper.Map<List<PersonGetAllResponse>>(persons);
            return model;
        }
//TODO resp req для каждого dto
        public PersonCreateResponse Create(PersonCreateRequest personDto)
        {
            var person = _mapper.Map<Person>(personDto); // Преобразуем DTO в сущность Person
            var createdPerson = _personRepository.Create(person); // Создаем пользователя, используя репозиторий
            var createdDto = _mapper.Map<PersonCreateResponse>(createdPerson); // Преобразуем созданную сущность Person в DTO
            return createdDto; // Возвращаем DTO
        }
        
        public PersonUpdateResponse Update(PersonUpdateRequest personUpdateRequest)
        {
            var person = _personRepository.GetById(personUpdateRequest.Id);

            person.Update(personUpdateRequest.FirstName, personUpdateRequest.LastName, personUpdateRequest.MiddleName,
                personUpdateRequest.PhoneNumber);
            var personResponse = _personRepository.Update(person);
            var response = _mapper.Map<PersonUpdateResponse>(personResponse);
            return response;
            /*var existingPerson = _personRepository.GetById(id);
            if (existingPerson == null)
            {
                throw new Exception("Пользователь не найден");
            }

            _mapper.Map(personDto, existingPerson);
            _personRepository.Update(existingPerson);

            var updatedDto = _mapper.Map<PersonGetByResponse>(existingPerson);
            return updatedDto;*/
        }

        public bool Delete(Guid id)
        {
            var existingPerson = _personRepository.GetById(id);
            if (existingPerson == null)
            {
                return false;
            }

            return _personRepository.Delete(id);
        }

        public List<CustomField<string>> GetCustomFields()
        {
            return _personRepository.GetCustomFields();
        }

    }
}