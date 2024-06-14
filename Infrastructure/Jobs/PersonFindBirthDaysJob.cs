using Application.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Logging;
using Telegram.Bot;

namespace Infrastructure.Jobs;

public class PersonFindBirthDaysJob: IJob
{
    private readonly IPersonRepository _personRepository;
    private readonly TelegramSettings _telegramSettings;
    private readonly TelegramBotClient _telegramBotClient;
    public PersonFindBirthDaysJob(IPersonRepository personRepository, IOptions<TelegramSettings> telegramSettings)
    {
        _personRepository = personRepository;
        _telegramSettings = telegramSettings.Value;
        _telegramBotClient = new TelegramBotClient(_telegramSettings.BotTocken);
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await SendMessageAsync(DateTime.Now.ToString());
        
        /*var persons = _personRepository.GetPersonsByBirthday();

        foreach (var person in persons)
        {
            Console.WriteLine($"С днём рождения, {person.FullName.FirstName} {person.FullName.LastName}!");
        }

        return Task.CompletedTask;*/
    }

    public async Task SendMessageAsync(string mesage)
    {
        try
        {
            var birthdayPersons = await _personRepository.GetBirthdayPersons(DateTime.Now);
            foreach (var birthdayPerson in birthdayPersons)
            {
                await _telegramBotClient.SendTextMessageAsync(_telegramSettings.ChatId, $"С днём рождения, {birthdayPerson.FullName.FirstName} {birthdayPerson.FullName.LastName} ({birthdayPerson.Telegram}), расти большой не будь лапшой!\"");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($@"Error sending message: {e.Message}");
            throw;
        }
    }
}