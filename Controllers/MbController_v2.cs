using Microsoft.AspNetCore.Mvc;

namespace PIS.Controllers
{
    public class MbController_v2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
