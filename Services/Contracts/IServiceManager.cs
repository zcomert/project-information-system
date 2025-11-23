namespace PIS.Services.Contracts
{
    public interface IServiceManager
    {
        IPersonService PersonService { get; }
        IProjectService ProjectService { get; }
        IProjectRoleService ProjectRoleService { get; }
        IProjectPersonService ProjectPersonService { get; }
    }
}
