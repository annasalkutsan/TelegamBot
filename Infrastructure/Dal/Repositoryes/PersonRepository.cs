using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositoryes;

public class PersonRepository:IPersonRepository
{
    private TelegramBotDbContext _telegramBotDbContext;

    public PersonRepository(TelegramBotDbContext telegramBotDbContext)
    {
        _telegramBotDbContext = telegramBotDbContext;
    }

    public Person? GetById(Guid id)
    {
        var person = _telegramBotDbContext.Persons.FirstOrDefault((x => x.Id == id));
        return person;
    }

    public List<Person> GetAll()
    {
        var persons = _telegramBotDbContext.Persons.ToList();
        //var persons = _telegramBotDbContext.Persons.ToList();
        return persons;
    }

    public async Task<Person> Create(Person person)
    {
        await _telegramBotDbContext.Persons.AddAsync(person);
        await _telegramBotDbContext.SaveChangesAsync();
        return person;
    }

    public Person Update(Person person)
    {
        _telegramBotDbContext.Persons.Update(person);
        _telegramBotDbContext.SaveChanges();
        return person;
    }

    public bool Delete(Guid id)
    {
        var person = GetById(id);
        if (person == null)
            return false;

        _telegramBotDbContext.Persons.Remove(person);
        _telegramBotDbContext.SaveChanges();
        return true;
    }

    public async Task SaveChanges()
    {
        await _telegramBotDbContext.SaveChangesAsync();
    }

    public List<CustomField<string>> GetCustomFields(Guid personId)
    {
        // Получить персону по идентификатору вместе с ее связанными пользовательскими полями
        var personWithCustomFields = _telegramBotDbContext.Persons
            .Include(p => p.CustomFields)
            .FirstOrDefault(p => p.Id == personId);

        // Если персона не найдена, вернуть пустой список пользовательских полей
        if (personWithCustomFields == null)
        {
            return new List<CustomField<string>>();
        }

        // Вернуть пользовательские поля для найденной персоны
        return personWithCustomFields.CustomFields.ToList();
    }

    public async Task<List<Person>> GetBirthdayPersons(DateTime dateTime)
    {
        var persons = _telegramBotDbContext.Persons.Where(x => x.BirthDay.Day == dateTime.Day && x.BirthDay.Month == dateTime.Month);
        return await persons.ToListAsync();
        
        /*DateTime today = DateTime.Today;
    
        // Фильтруем персоны по совпадению месяца и дня даты рождения с текущей датой
        List<Person> persons = GetAll(); // Предположим, что у вас есть метод GetAll() для получения всех персон
        List<Person> filteredPersons = persons.Where(p => p.BirthDay.Month == today.Month && p.BirthDay.Day == today.Day).ToList();
    
        return filteredPersons;*/
    }
}