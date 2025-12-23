namespace PIS.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int TotalCategories { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal AverageBudget { get; set; }
        public List<ProjectSummary> RecentProjects { get; set; } = new();
        public List<CategorySummary> TopCategories { get; set; } = new();
    }

    public class ProjectSummary
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CategoryName { get; set; }
        public decimal Budget { get; set; }
    }

    public class CategorySummary
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int ProjectCount { get; set; }
    }
}
