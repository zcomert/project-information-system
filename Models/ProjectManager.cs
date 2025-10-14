namespace PIS.Models;

public class ProjectManager
{
    private List<Project> _list;
    public ProjectManager()
    {
        _list = new List<Project>()
        {
            new Project()
            {
                Id=1,
                Title = "Hyperloop",
                Budget = 100_000m
            },
            new Project()
            {
                Id=2,
                Title = "Mars Colonization",
                Budget = 1_000_000m
            },
            new Project()
            {
                Id=3,
                Title = "Time Machine",
                Budget = 10_000_000m
            }
        };
    }

    public List<Project> GetAll() => _list;
   

}