using PIS.Models;

namespace PIS.Repositories.Contracts;

public interface IProjectRepository
{
    IQueryable<Project> GetAll();
    Project? GetById(int id);
    void Create(Project project);
    void Update(Project project);
    void Delete(int id);
}
