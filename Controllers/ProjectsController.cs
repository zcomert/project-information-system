using Microsoft.AspNetCore.Mvc;
using PIS.Services.Contracts;

namespace PIS.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            var projects = _projectService.GetAll().ToList();
            return View(projects);
        }

        public IActionResult Details(int id)
        {
            var project = _projectService.GetById(id);
            if (project is null)
            {
                return NotFound();
            }

            return View(project);
        }
    }
}
