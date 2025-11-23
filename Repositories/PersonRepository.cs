using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly RepositoryContext _context;

    public PersonRepository(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<Person> GetAll()
    {
        return _context.Persons;
    }

    public Person? GetById(int id)
    {
        return _context.Persons.Find(id);
    }

    public void Create(Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
    }

    public void Update(Person person)
    {
        _context.Persons.Update(person);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var person = GetById(id);
        if (person is not null)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}
