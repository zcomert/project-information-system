using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(RepositoryContext context) : base(context)
    {
    }

    public override Project? GetById(int id)
    {
        return _context.Projects.Find((short)id);
    }
}

