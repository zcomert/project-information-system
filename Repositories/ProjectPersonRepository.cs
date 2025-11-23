using PIS.Models;
using PIS.Repositories.Contracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PIS.Repositories
{
    public class ProjectPersonRepository : RepositoryBase<ProjectPerson>, IProjectPersonRepository
    {
        public ProjectPersonRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<ProjectPerson> GetByProjectId(int projectId)
        {
            return _context.ProjectPersons
                .Where(pp => pp.ProjectId == projectId)
                .Include(pp => pp.Person)
                .Include(pp => pp.Role);
        }
    }
}
