using PIS.Models;
using PIS.Repositories.Contracts;
using PIS.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PIS.Services
{
    public class ProjectPersonManager : IProjectPersonService
    {
        private readonly IProjectPersonRepository _repository;

        public ProjectPersonManager(IProjectPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProjectPerson> GetByProjectId(int projectId)
        {
            return _repository.GetByProjectId(projectId).ToList();
        }

        public ProjectPerson Create(ProjectPerson projectPerson)
        {
            if (projectPerson is null)
                throw new System.ArgumentNullException(nameof(projectPerson));

            _repository.Create(projectPerson);
            return projectPerson;
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
