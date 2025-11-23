using PIS.Models;
using System.Collections.Generic;

namespace PIS.Services.Contracts
{
    public interface IProjectRoleService
    {
        IEnumerable<ProjectRole> GetAll();
        ProjectRole? GetById(int id);
        ProjectRole Create(ProjectRole projectRole);
        bool Update(ProjectRole projectRole);
        bool Delete(int id);
    }
}
