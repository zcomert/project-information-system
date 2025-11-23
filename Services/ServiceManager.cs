using System;
using PIS.Repositories.Contracts;
using PIS.Services.Contracts;

namespace PIS.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _personService;
        private readonly Lazy<IProjectService> _projectService;
        private readonly Lazy<IProjectRoleService> _projectRoleService;
        private readonly Lazy<IProjectPersonService> _projectPersonService;

        public ServiceManager(IPersonRepository personRepository, 
            IProjectRepository projectRepository, 
            IProjectRoleRepository projectRoleRepository,
            IProjectPersonRepository projectPersonRepository)
        {
            _personService = new Lazy<IPersonService>(() => new PersonManager(personRepository));
            _projectService = new Lazy<IProjectService>(() => new ProjectManager(projectRepository));
            _projectRoleService = new Lazy<IProjectRoleService>(() => new ProjectRoleManager(projectRoleRepository));
            _projectPersonService = new Lazy<IProjectPersonService>(() => new ProjectPersonManager(projectPersonRepository));
        }

        public IPersonService PersonService => _personService.Value;
        public IProjectService ProjectService => _projectService.Value;
        public IProjectRoleService ProjectRoleService => _projectRoleService.Value;
        public IProjectPersonService ProjectPersonService => _projectPersonService.Value;
    }
}
