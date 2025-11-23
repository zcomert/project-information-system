namespace PIS.Models;

public class ProjectRole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<ProjectPerson> ProjectPersons { get; set; } = new HashSet<ProjectPerson>();
}
