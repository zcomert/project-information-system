using Microsoft.AspNetCore.Mvc;

namespace PIS.Controllers
{
    public class ProjectManagerController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Projects");
        }

        public IActionResult Details(int id)
        {
            return RedirectToAction("Details", "Projects", new { id });
        }
    }
}
