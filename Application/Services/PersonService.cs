using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Application.DTOs;
using Application.MappingProfiles;
using AutoMapper;

namespace Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        private readonly IMapper _mapper;
        
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

        public List<PersonGetAllResponse> GetAll()
        {
            var persons = _personRepository.GetAll();
            var model = _mapper.Map<List<PersonGetAllResponse>>(persons);
            return model;
        }

        public async Task<PersonCreateResponse> Create(PersonCreateRequest personDto)
        {
            var person = _mapper.Map<Person>(personDto); // Преобразуем DTO в сущность Person
            var createdPerson = _personRepository.Create(person); // Создаем пользователя, используя репозиторий
            await _personRepository.SaveChanges();
            var createdDto = _mapper.Map<PersonCreateResponse>(createdPerson); // Преобразуем созданную сущность Person в DTO
            return createdDto; // Возвращаем DTO
        }
        //Почитать про отложенное сохранение в EF и SaveChanges
        //Разобраться с подключением маппера в целый проект
        public async Task<PersonUpdateResponse> Update(PersonUpdateRequest personUpdateRequest)
        {
            var person = _personRepository.GetById(personUpdateRequest.Id);

            person.Update(personUpdateRequest.FirstName, personUpdateRequest.LastName, personUpdateRequest.MiddleName,
                personUpdateRequest.PhoneNumber);
            var personResponse = _personRepository.Update(person);
            await _personRepository.SaveChanges();
            var response = _mapper.Map<PersonUpdateResponse>(personResponse);
            return response;
        }

        public bool Delete(Guid id)
        {
            return _personRepository.Delete(id);
        }

        public List<CustomField<string>> GetCustomFields(Guid personId)
        {
            return _personRepository.GetCustomFields(personId);
        }
    }
}