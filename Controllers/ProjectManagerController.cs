using Microsoft.AspNetCore.Mvc;
using PIS.Models;

namespace PIS.Controllers;

public class ProjectManagerController : Controller
{
    public IActionResult Index()
    {
        var manager = new ProjectManager();
        var list = manager.GetAll();
        return View(list);
    }
}