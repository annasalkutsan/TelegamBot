using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Dal.EntityFramework.Configurations;
/// <summary>
/// Конфигурация CustomField <TType> для БД
/// </summary>
public class CustomFieldConfiguration:IEntityTypeConfiguration<CustomField<string>>
{
    public void Configure(EntityTypeBuilder<CustomField<string>> builder)
    {
        builder.Property<string>(x => x.Name).IsRequired();
        builder.Property<string>(x => x.Value).IsRequired();
    }
}