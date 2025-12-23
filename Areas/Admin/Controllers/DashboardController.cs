using Microsoft.AspNetCore.Mvc;
using PIS.Areas.Admin.Models;
using PIS.Services.Contracts;

namespace PIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICategoryService _categoryService;

        public DashboardController(IProjectService projectService, ICategoryService categoryService)
        {
            _projectService = projectService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var projects = _projectService.GetAll().ToList();
            var categories = _categoryService.GetAll().ToList();

            var totalProjects = projects.Count;
            var totalCategories = categories.Count;
            var totalBudget = projects.Sum(p => p.Budget);
            var averageBudget = totalProjects > 0 ? totalBudget / totalProjects : 0;

            var model = new DashboardViewModel
            {
                TotalProjects = totalProjects,
                TotalCategories = totalCategories,
                TotalBudget = totalBudget,
                AverageBudget = averageBudget,
                RecentProjects = projects
                    .OrderByDescending(p => p.Id)
                    .Take(5)
                    .Select(p => new ProjectSummary
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Budget = p.Budget,
                        CategoryName = p.Category?.CategoryName
                    })
                    .ToList(),
                TopCategories = categories
                    .Select(c => new CategorySummary
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        ProjectCount = c.Projects?.Count ?? projects.Count(p => p.CategoryId == c.CategoryId)
                    })
                    .OrderByDescending(c => c.ProjectCount)
                    .Take(5)
                    .ToList()
            };

            return View(model);
        }
    }
}
