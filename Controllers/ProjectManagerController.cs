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

    public IActionResult Details([FromRoute(Name ="id")] int id)
    {
        var manager = new ProjectManager();
        var list = manager.GetAll();
        // var project = new Project();
        // foreach (Project item in list)
        // {
        //     if (item.Id == id)
        //     {
        //         project = item;
        //         break;
        //     }
        // } 
        return View(list.SingleOrDefault(p => p.Id == id));
    }
}