using System.Collections.Generic;

namespace PIS.Models
{
    public class ProjectDetailsViewModel
    {
        public Project Project { get; set; } = new();
        public List<ProjectPerson> Assignments { get; set; } = new();
    }
}
