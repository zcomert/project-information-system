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
    public IActionResult PersonList()
    {
        List<Person> persons = new List<Person>()
        {
            new Person(){Id= 1,FirstName="ertu",LastName="şimşek",Salary=25000},
            new Person(){Id= 2,FirstName="baran",LastName= "filmci",Salary=35000},
            new Person(){Id=3,FirstName="batu",LastName="gelegen",Salary=50000},
            new Person(){Id= 4,FirstName="görkem",LastName="ediz",Salary=1000},


        };
        return View("PersonList",persons);
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
            "Corum",
            "Hatay"
        };
        return View(cities);
    }

}
