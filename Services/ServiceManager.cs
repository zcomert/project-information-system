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

        public ServiceManager(IPersonRepository personRepository, 
            IProjectRepository projectRepository, 
            IProjectRoleRepository projectRoleRepository)
        {
            // artık DI kaydına gerek yok, çünkü Lazy ile sarmaladık
            _personService = new Lazy<IPersonService>(() => new PersonManager(personRepository));
            _projectService = new Lazy<IProjectService>(() => new ProjectManager(projectRepository));
            _projectRoleService = new Lazy<IProjectRoleService>(() => new ProjectRoleManager(projectRoleRepository));
        }

        public IPersonService PersonService => _personService.Value;
        public IProjectService ProjectService => _projectService.Value;
        public IProjectRoleService ProjectRoleService => _projectRoleService.Value;
    }
}
