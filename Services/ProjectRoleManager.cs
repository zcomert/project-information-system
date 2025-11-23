using PIS.Models;
using PIS.Repositories.Contracts;
using PIS.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PIS.Services
{
    public class ProjectRoleManager : IProjectRoleService
    {
        private readonly IProjectRoleRepository _repository;

        public ProjectRoleManager(IProjectRoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProjectRole> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public ProjectRole? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ProjectRole Create(ProjectRole projectRole)
        {
            if (projectRole is null)
                throw new System.ArgumentNullException(nameof(projectRole));

            _repository.Create(projectRole);
            return projectRole;
        }

        public bool Update(ProjectRole projectRole)
        {
            if (projectRole is null)
                throw new System.ArgumentNullException(nameof(projectRole));
            
            var entity = _repository.GetById(projectRole.Id);
            if (entity is null)
                return false;

            _repository.Update(projectRole);
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
    }
}
