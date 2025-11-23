using System.ComponentModel.DataAnnotations;

namespace PIS.Models;

public class Person
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    public string StudentNumber { get; set; }
    public string StaffNumber { get; set; }

    public string PersonType { get; set; }  // Student, Academic, Researcher vb.

    public bool IsActive { get; set; } = true;

    public ICollection<ProjectPerson> ProjectPersons { get; set; } = new HashSet<ProjectPerson>();
}
