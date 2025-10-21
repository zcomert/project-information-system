using Microsoft.AspNetCore.Mvc;
using PIS.Models;

namespace PIS.Controllers
{
    public class ProjectManagerController : Controller
    {
        private readonly ProjectManager _manager;

        public ProjectManagerController(ProjectManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var list1 = _manager.GetAll();
            return View(list1);
        }

        public IActionResult Details([FromRoute(Name = "id")] int id)
        {
            var list1 = _manager.GetAll();
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

            var created = _manager.Create(project);
            return RedirectToAction(nameof(Details), new { id = created.Id });
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var project = _manager.GetById(id);
            if (project is null)
                return NotFound();
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            var ok = _manager.Update(project);
            if (!ok)
                return NotFound();

            return RedirectToAction(nameof(Details), new { id = project.Id });
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var project = _manager.GetById(id);
            if (project is null)
                return NotFound();
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromForm] int id)
        {
            var ok = _manager.Delete(id);
            if (!ok)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
