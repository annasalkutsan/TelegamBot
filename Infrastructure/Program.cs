using System.Reflection;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Application.MappingProfiles;
using Infrastructure.Dal.EntityFramework.Configurations;
using Infrastructure.Jobs;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Simpl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
//получение строки подключения из конфигурационного файла
var connectionString = builder.Configuration.GetConnectionString("TelegramBotDataBase");
builder.Services.AddDbContext<TelegramBotDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Регистрация профилей AutoMapper
builder.Services.AddAutoMapper(typeof(PersonProfile));
builder.Services.AddAutoMapper(typeof(CustomFieldListConverter));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<PersonService>();

// Регистрация конфигурации CronExpressionOptions
builder.Services.Configure<CronExpressionOptions>(builder.Configuration.GetSection("CronExpression"));

// Чтение cron-выражения из типизированной конфигурации
builder.Services.AddQuartz(x =>
{
    x.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();

    var jobKey = new JobKey("PersonFindBirthDaysJob");
    x.AddJob<PersonFindBirthDaysJob>(opt => opt.WithIdentity(jobKey));

    var triggerKey = new TriggerKey("TestJobTrigger");
    // Получение настроек cron-выражения через IOptions
    var cronOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<CronExpressionOptions>>().Value;
    x.AddTrigger(opts => opts.ForJob(jobKey).WithIdentity(triggerKey)
        .WithCronSchedule(cronOptions.TestJobExpression));
});

builder.Services.AddQuartzHostedService(opts =>
{
    opts.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();