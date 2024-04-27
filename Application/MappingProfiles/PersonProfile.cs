using System.Collections.Generic;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            //Person в PersonGetByResponse
            CreateMap<Person, PersonGetByResponse>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id));

            //PersonGetAllResponse в Person
            CreateMap<PersonGetAllResponse, Person>();

            //PersonCreateRequest в Person
            CreateMap<PersonCreateRequest, Person>();

            //PersonUpdateRequest в Person
            CreateMap<PersonUpdateRequest, Person>();

            //Person в список пользовательских полей
            //ConvertUsing -- для явного указания способа преобразования одного объекта в другой при маппинге
            CreateMap<Person, List<CustomField<string>>>().ConvertUsing<CustomFieldListConverter>();

            //PersonCreateResponse в Person
            CreateMap<Person, PersonCreateResponse>();
        }
    }
}