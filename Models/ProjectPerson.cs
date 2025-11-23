namespace PIS.Models;

public class ProjectPerson
    {
        public int Id { get; set; }

        public short ProjectId { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Workload { get; set; }
        public string? Note { get; set; }

        public Project Project { get; set; } = default!;
        public Person Person { get; set; } = default!;
        public ProjectRole Role { get; set; } = default!;
    }