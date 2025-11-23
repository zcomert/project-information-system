using PIS.Models;
using System.Collections.Generic;

namespace PIS.Services.Contracts
{
    public interface IProjectPersonService
    {
        IEnumerable<ProjectPerson> GetByProjectId(int projectId);
        ProjectPerson Create(ProjectPerson projectPerson);
        bool Delete(int id);
    }
}
