using Microsoft.AspNetCore.Mvc;
using PIS.Models;

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
    public IActionResult Person()
    {
        var person = new Person()
        {
            Id = 1,
            FirstName = "Görkem",
            LastName = "Ediz Özpekmezci",
            Salary = 100_000_000
        };
        return View(person);
    }
    public IActionResult Cities()
    {
        var cities = new List<string>()
        {
            "Samsun",
            "Sinop",
            "Şanlıurfa",
            "Ankara",
            "Tokat",
            "Çorum",
            "Hatay"
        };
        return View(cities);
    }

}
