using PIS.Models;
using System.Collections.Generic;

namespace PIS.Services.Contracts
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        Person Create(Person person);
        bool Update(Person person);
        bool Delete(int id);
        IEnumerable<Person> Search(string query); 
    }
}
