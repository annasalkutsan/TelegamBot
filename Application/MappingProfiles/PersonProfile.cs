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
            
            //Person в PersonGetAllResponse 
            CreateMap<Person,PersonGetAllResponse>();
            
            //PersonCreateRequest в Person
            CreateMap<PersonCreateRequest, Person>();

            //PersonUpdateRequest в PersonUpdateResponse
            CreateMap<PersonUpdateRequest, PersonUpdateResponse>();

            //Person в PersonUpdateResponse
            CreateMap<Person, PersonUpdateResponse>();
            
            //Person в список пользовательских полей
            //ConvertUsing -- для явного указания способа преобразования одного объекта в другой при маппинге
            CreateMap<Person, List<CustomField<string>>>().ConvertUsing<CustomFieldListConverter>();

            //PersonCreateResponse в Person
            CreateMap<Person, PersonCreateResponse>();
        }
    }
}