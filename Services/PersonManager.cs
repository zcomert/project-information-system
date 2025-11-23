using PIS.Models;
using PIS.Repositories.Contracts;
using PIS.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PIS.Services
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Person Create(Person person)
        {
            if (person is null)
                throw new System.ArgumentNullException(nameof(person));

            _repository.Create(person);
            return person;
        }

        public Person? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(Person person)
        {
            if (person is null)
                throw new System.ArgumentNullException(nameof(person));
            
            var entity = _repository.GetById(person.Id);
            if (entity is null)
                return false;

            _repository.Update(person);
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
                return false;

            _repository.Delete(id);
            return true;
        }

        public IEnumerable<Person> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _repository.GetAll().ToList();

            return _repository.GetAll().Where(p => 
                p.FirstName.Contains(query, System.StringComparison.OrdinalIgnoreCase) || 
                p.LastName.Contains(query, System.StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}
