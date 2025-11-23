using PIS.Models;

namespace PIS.Repositories.Contracts;

public interface IPersonRepository
{
    IQueryable<Person> GetAll();
    Person? GetById(int id);
    void Create(Person person);
    void Update(Person person);
    void Delete(int id);
}
