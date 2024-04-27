using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;
/// <summary>
/// Конфигурация Person для БД
/// </summary>
public class PersonsConfiguration:IEntityTypeConfiguration<Person>
{
    //набор персон в базу 

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasKey(x => x.CreationDate);
        builder.OwnsOne(x => x.FullName, fullName =>
        {
            fullName.Property(x => x.FirstName).IsRequired();
            fullName.Property(x => x.LastName).IsRequired();
            fullName.Property(x => x.MiddleName);
        });
        builder.Property(x => x.BirthDay).IsRequired();
        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.Property(x => x.Telegram).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        
        //новое свойство, после создаем новую миграцию, даем имя => updatedb. так после каждого обновления кода
        //TODO: дописать свойства кроме возраста

    }
}