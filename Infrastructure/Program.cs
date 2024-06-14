using System.Reflection;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Application.MappingProfiles;
using Infrastructure.Dal.EntityFramework.Configurations;
using Infrastructure.Jobs;
using Infrastructure.Settings;
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
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddAutoMapper(typeof(CustomFieldListConverter));
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<PersonService>();

// Регистрация конфигурации CronExpressionOptions
builder.Services.Configure<CronExpression>(builder.Configuration.GetSection(nameof (CronExpressionSettings)));
builder.Services.Configure<TelegramSettings>(builder.Configuration.GetSection(nameof (TelegramSettings)));
// Чтение cron-выражения из типизированной конфигурации
builder.Services.AddQuartz(x =>
{
    var cronExpressionSettings = builder.Configuration.GetSection( nameof (CronExpressionSettings)).Get<CronExpressionSettings>();
    
    //x.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();

    var jobKey = new JobKey("PersonFindBirthDaysJob");
    
    x.AddJob<PersonFindBirthDaysJob>(opt => opt.WithIdentity(jobKey));

    var triggerKey = new TriggerKey("PersonFindBirthDaysJobTrigger");
    
    // Получение настроек cron-выражения через IOptions
    //var cronOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<CronExpressionOptions>>().Value;
    
    x.AddTrigger(opts => opts.ForJob(jobKey).WithIdentity(triggerKey)
        .WithCronSchedule(cronExpressionSettings.PersonFindBirthdaysJob));
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