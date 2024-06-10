using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;
/// <summary>
/// Конфигурация Person для БД
/// </summary>
public class PersonsConfiguration:IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreationDate).IsRequired();
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
    }
}