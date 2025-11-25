using PIS.Models;
using System.Collections.Generic;

namespace PIS.Services.Contracts
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        Project GetById(int id);
        Project Create(Project project);
        bool Update(Project project);
        bool Delete(int id);
        IEnumerable<Project> Search(string query); 
    }
}
