namespace PIS.Models;

public class ProjectRole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<ProjectPerson> ProjectPersons { get; set; }
}
