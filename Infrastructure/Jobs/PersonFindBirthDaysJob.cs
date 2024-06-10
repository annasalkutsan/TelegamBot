using Application.Interfaces;
using Quartz;
using Quartz.Logging;

namespace Infrastructure.Jobs;

public class PersonFindBirthDaysJob: IJob
{
    private readonly IPersonRepository _personRepository;

    public PersonFindBirthDaysJob(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Task Execute(IJobExecutionContext context)
    {
        var persons = _personRepository.GetPersonsByBirthday();
        
        foreach (var person in persons)
        {
            Console.WriteLine($"С днём рождения, {person.FullName.FirstName} {person.FullName.LastName}!");
        }
        
        return Task.CompletedTask;
    }
}