using PIS.Models;
using PIS.Repositories.Contracts;
using PIS.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PIS.Services
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectManager(IProjectRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Project> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Project Create(Project project)
        {
            if (project is null)
                throw new System.ArgumentNullException(nameof(project));

            _repository.Create(project);
            return project;
        }

        public Project? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(Project project)
        {
            if (project is null)
                throw new System.ArgumentNullException(nameof(project));
            
            var entity = _repository.GetById(project.Id);
            if (entity is null)
                return false;

            _repository.Update(project);
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
                return false;

            _repository.Delete(id);
            return true;
        }

        public IEnumerable<Project> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _repository.GetAll().ToList();

            return _repository.GetAll().Where(p => p.Title.Contains(query, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
