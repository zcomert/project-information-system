using Microsoft.AspNetCore.Mvc;
using PIS.Models;
using PIS.Services.Contracts;

namespace PIS.Controllers
{
    public class ProjectManagerController : Controller
        {
            private readonly IServiceManager _serviceManager;
    
            public ProjectManagerController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }
    
            public IActionResult Index()
            {
                var list1 = _serviceManager.ProjectService.GetAll();
                return View(list1);
            }
    
            public IActionResult Details([FromRoute(Name = "id")] int id)
            {
                var project = _serviceManager.ProjectService.GetById(id);
                if (project is null)
                {
                    return NotFound();
                }
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
    
                var created = _serviceManager.ProjectService.Create(project);
                return RedirectToAction(nameof(Details), new { id = created.Id });
            }
    
            [HttpGet]
            public IActionResult Update([FromRoute(Name = "id")] int id)
            {
                var project = _serviceManager.ProjectService.GetById(id);
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
    
                var ok = _serviceManager.ProjectService.Update(project);
                if (!ok)
                    return NotFound();
    
                return RedirectToAction(nameof(Details), new { id = project.Id });
            }
    
            [HttpGet]
            public IActionResult Delete([FromRoute(Name = "id")] int id)
            {
                var project = _serviceManager.ProjectService.GetById(id);
                if (project is null)
                    return NotFound();
                return View(project);
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            [ActionName("Delete")]
            public IActionResult DeleteConfirmed([FromForm] int id)
            {
                var ok = _serviceManager.ProjectService.Delete(id);
                if (!ok)
                    return NotFound();
                return RedirectToAction(nameof(Index));
            }
        }
}
