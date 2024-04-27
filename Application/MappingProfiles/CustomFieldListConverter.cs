using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class CustomFieldListConverter : ITypeConverter<Person, List<CustomField<string>>>
    {
        // Convert, который преобразовывает объекты типа Person в List<CustomField<string>>
        public List<CustomField<string>> Convert(Person source, List<CustomField<string>> destination, ResolutionContext context)
        {
            // source - исходный объект, который нужно преобразовать
            // destination - объект, в который будет помещен результат преобразования (может быть пустым)
            // context - контекст маппинга, предоставляющий дополнительную информацию о маппинге (например, используемые профили и настройки)

            // получаем список пользовательских полей из объекта Person и преобразуем каждое поле в объект CustomField<string>
            var customFields = source.CustomFields.Select(cf => new CustomField<string> { Name = cf.Name, Value = cf.Value.ToString() }).ToList();
        
            // возвращаем полученный список CustomField<string>
            return customFields;
        }
    }


}