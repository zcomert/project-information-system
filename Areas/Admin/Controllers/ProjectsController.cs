using Microsoft.AspNetCore.Mvc;
using PIS.Models;
using PIS.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICategoryService _categoryService;

        public ProjectsController(IProjectService projectService, ICategoryService categoryService)
        {
            _projectService = projectService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var list1 = _projectService.GetAll();
            var categories = _categoryService.GetAll();
            
            // Create a dictionary of CategoryId -> CategoryName for easy lookup in the view
            var categoryDict = categories.ToDictionary(c => c.CategoryId, c => c.CategoryName ?? "-");
            ViewBag.Categories = categoryDict;
            
            return View(list1);
        }

        public IActionResult Details([FromRoute(Name = "id")] int id)
        {
            var project = _projectService.GetById(id);
            if (project is null)
                return NotFound();
            string categoryName = "-";
            if (project.Id != 0)
            {
                var category = _categoryService.GetById(project.CategoryId);
                if (category != null)
                    categoryName = category.CategoryName;
            }
            ViewBag.CategoryName = categoryName;

            return View(project);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Project();
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetAll();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                return View(project);
            }

            var created = _projectService.Create(project);
            return RedirectToAction(nameof(Details), new { id = created.Id });
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var project = _projectService.GetById(id);
            if (project is null)
                return NotFound();
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Project project)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetAll();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
                return View(project);
            }

            var ok = _projectService.Update(project);
            if (!ok)
                return NotFound();

            return RedirectToAction(nameof(Details), new { id = project.Id });
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var project = _projectService.GetById(id);
            if (project is null)
                return NotFound();
            string categoryName = "-";
            if (project != null && project.Id != 0)
            {
                var category = _categoryService.GetById(project.CategoryId);
                if (category != null)
                    categoryName = category.CategoryName;
            }
            ViewBag.CategoryName = categoryName;
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromForm] int id)
        {
            var ok = _projectService.Delete(id);
            if (!ok)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
