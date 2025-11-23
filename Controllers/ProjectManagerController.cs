using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PIS.Models;
using PIS.Services.Contracts;
using System.Linq;

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
            var list = _serviceManager.ProjectService.GetAll();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var project = _serviceManager.ProjectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            var assignments = _serviceManager.ProjectPersonService.GetByProjectId(id).ToList();

            var viewModel = new ProjectDetailsViewModel
            {
                Project = project,
                Assignments = assignments
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProjectCreateViewModel
            {
                Project = new Project(),
                AllPersons = _serviceManager.PersonService.GetAll()
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" })
                    .ToList(),
                AllRoles = _serviceManager.ProjectRoleService.GetAll()
                    .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name })
                    .ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate lists if model validation fails
                viewModel.AllPersons = _serviceManager.PersonService.GetAll()
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" })
                    .ToList();
                viewModel.AllRoles = _serviceManager.ProjectRoleService.GetAll()
                    .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name })
                    .ToList();
                return View(viewModel);
            }

            // 1. Create the project
            var createdProject = _serviceManager.ProjectService.Create(viewModel.Project);

            // 2. Create the assignments
            if (viewModel.SelectedPersonIds != null && viewModel.SelectedPersonIds.Any())
            {
                foreach (var personId in viewModel.SelectedPersonIds)
                {
                    var projectPerson = new ProjectPerson
                    {
                        ProjectId = createdProject.Id,
                        PersonId = personId,
                        RoleId = viewModel.SelectedRoleId,
                        StartDate = System.DateTime.Now
                    };
                    _serviceManager.ProjectPersonService.Create(projectPerson);
                }
            }
            
            return RedirectToAction(nameof(Details), new { id = createdProject.Id });
        }


        // ... other actions ...
        [HttpGet]
        public IActionResult Update(int id)
        {
            var project = _serviceManager.ProjectService.GetById(id);
            if (project is null)
                return NotFound();

            var assignments = _serviceManager.ProjectPersonService.GetByProjectId(id);

            var viewModel = new ProjectUpdateViewModel
            {
                Project = project,
                AllPersons = _serviceManager.PersonService.GetAll()
                    .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" })
                    .ToList(),
                AllRoles = _serviceManager.ProjectRoleService.GetAll()
                    .Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name })
                    .ToList(),
                SelectedPersonIds = assignments.Select(a => a.PersonId).ToList()
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, ProjectUpdateViewModel viewModel)
        {
            if (id != viewModel.Project.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                // Repopulate lists if model validation fails
                viewModel.AllPersons = _serviceManager.PersonService.GetAll().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" }).ToList();
                viewModel.AllRoles = _serviceManager.ProjectRoleService.GetAll().Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Name }).ToList();
                return View(viewModel);
            }

            // 1. Update the project's scalar properties
            _serviceManager.ProjectService.Update(viewModel.Project);

            // 2. Reconcile assignments
            var existingAssignments = _serviceManager.ProjectPersonService.GetByProjectId(id).ToList();
            var existingPersonIds = existingAssignments.Select(a => a.PersonId).ToList();
            var selectedPersonIds = viewModel.SelectedPersonIds ?? new List<int>();

            // People to remove
            var peopleToRemove = existingAssignments.Where(a => !selectedPersonIds.Contains(a.PersonId)).ToList();
            foreach (var assignment in peopleToRemove)
            {
                _serviceManager.ProjectPersonService.Delete(assignment.Id);
            }

            // People to add
            var personIdsToAdd = selectedPersonIds.Where(pid => !existingPersonIds.Contains(pid)).ToList();
            foreach (var personId in personIdsToAdd)
            {
                var newAssignment = new ProjectPerson
                {
                    ProjectId = (short)id,
                    PersonId = personId,
                    RoleId = viewModel.SelectedRoleId, // Simplified: new people get the selected role
                    StartDate = System.DateTime.Now
                };
                _serviceManager.ProjectPersonService.Create(newAssignment);
            }

            return RedirectToAction(nameof(Details), new { id = viewModel.Project.Id });
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
