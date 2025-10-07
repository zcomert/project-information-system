using Microsoft.AspNetCore.Mvc;

namespace PIS.Controllers;

public class MbController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Introduce()
    {
        var name = "Zafer CÖMERT";
        return View("Introduce", name);
    }
}
