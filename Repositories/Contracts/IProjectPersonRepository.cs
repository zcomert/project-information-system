using PIS.Models;

namespace PIS.Repositories.Contracts
{
    public interface IProjectPersonRepository : IRepositoryBase<ProjectPerson>
    {
        IQueryable<ProjectPerson> GetByProjectId(int projectId);
    }
}
