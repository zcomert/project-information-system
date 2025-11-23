namespace PIS.Models;

public class Project
{
    public Int16 Id { get; set; }
    public String Title { get; set; } = string.Empty;
    public Decimal Budget { get; set; }

    // Collection navigation property
    public ICollection<ProjectPerson> ProjectPersons { get; set; } = new HashSet<ProjectPerson>();
}
