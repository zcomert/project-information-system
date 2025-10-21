using Microsoft.AspNetCore.Mvc;
using PIS.Models;

namespace PIS.Controllers
{
    public class ProjectManagerController : Controller
    {
        public IActionResult Index()
        {
            var manager = new ProjectManager();
            var list1 = manager.GetAll();
            return View(list1);
        }

        public IActionResult Details([FromRoute(Name = "id")] int id)
        {
            var manager = new ProjectManager();
            var list1 = manager.GetAll();
            var project = new Project();
            foreach (var item in list1)
            {
                if (item.Id == id)
                {
                    project = item;
                    break;
                }
            }
            //var project = list1.FirstOrDefault(p => p.Id == id);
            return View(project);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Project();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            var manager = new ProjectManager();
            var created = manager.Create(project);
            return RedirectToAction(nameof(Details), new { id = created.Id });
        }
    }
}
