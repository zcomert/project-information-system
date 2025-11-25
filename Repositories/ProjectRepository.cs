using PIS.Models;
using PIS.Repositories.Contracts;

namespace PIS.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly RepositoryContext _context;

    public ProjectRepository(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<Project> GetAll()
    {
        return _context.Projects;
    }

    public Project? GetById(int id)
    {
        return _context.Projects.Find(id);
    }

    public void Create(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }

    public void Update(Project project)
    {
        _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var project = GetById(id);
        if (project is not null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}

