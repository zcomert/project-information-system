using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class PersonRepository : RepositoryBase<Person>, IPersonRepository

{

    public PersonRepository(RepositoryContext context) : base(context)

    {

    }

}
