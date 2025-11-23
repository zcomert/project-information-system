using Microsoft.AspNetCore.Mvc;
using PIS.Models;
using PIS.Services.Contracts;

namespace PIS.Controllers
{
    public class ProjectRoleController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProjectRoleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var roles = _serviceManager.ProjectRoleService.GetAll();
            return View(roles);
        }

        public IActionResult Details(int id)
        {
            var role = _serviceManager.ProjectRoleService.GetById(id);
            if (role is null)
                return NotFound();
            return View(role);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectRole projectRole)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ProjectRoleService.Create(projectRole);
                return RedirectToAction(nameof(Index));
            }
            return View(projectRole);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var role = _serviceManager.ProjectRoleService.GetById(id);
            if (role is null)
                return NotFound();
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, ProjectRole projectRole)
        {
            if (id != projectRole.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var ok = _serviceManager.ProjectRoleService.Update(projectRole);
                if (!ok)
                    return NotFound();
                return RedirectToAction(nameof(Index));
            }
            return View(projectRole);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var role = _serviceManager.ProjectRoleService.GetById(id);
            if (role is null)
                return NotFound();
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ok = _serviceManager.ProjectRoleService.Delete(id);
            if (!ok)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
