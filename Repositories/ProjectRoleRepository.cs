using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class ProjectRoleRepository : RepositoryBase<ProjectRole>, IProjectRoleRepository
{
    public ProjectRoleRepository(RepositoryContext context) : base(context)
    {
    }
}
