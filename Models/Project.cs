namespace PIS.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public Decimal Budget { get; set; }

        public int CategoryId { get; set; } // foreign key: navigational property
        public Category? Category { get; set; } // navigation property
        
    }
}
