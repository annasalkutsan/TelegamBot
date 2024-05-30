using System.Reflection;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Microsoft.EntityFrameworkCore;
using AutoMapper; 
using Application.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
//получение строки подключения из конфигурационного файла
var connectionString = builder.Configuration.GetConnectionString("TelegramBotDataBase");
builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Регистрация профиля AutoMapper
builder.Services.AddAutoMapper(typeof(Application.MappingProfiles.PersonProfile));
builder.Services.AddAutoMapper(typeof(Application.MappingProfiles.CustomFieldListConverter));
//builder.Services.AddAutoMapper(typeof(Program));
// Регистрация профилей AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

///todo разобраться с постман, протестить апи, сохраненный в колеекциях. и ее экспортировать коллекцию и прикрепить кудато файлом в инфраструктуру.
/// потом сделать предыдущую домашку
///  !!!! иии
/// попробовать отельным сайт проектом сделать прогу получение логин пароль, токен дс и делаем какое-то действие типа лайка
/// не свой аккаунт ибо могут забанить
/// не через бота *

builder.Services.AddScoped<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Этот метод определяет маршруты для контроллеров, которые вы определили в вашем приложении
});*/

app.UseHttpsRedirection();

app.Run();