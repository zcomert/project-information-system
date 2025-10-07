using Microsoft.AspNetCore.Mvc;

namespace PIS.Controllers;

public class MbController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
