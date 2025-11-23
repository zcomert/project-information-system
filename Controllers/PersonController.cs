using Microsoft.AspNetCore.Mvc;
using PIS.Models;
using PIS.Services.Contracts;

namespace PIS.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index(string query)
        {
            var list = _personService.Search(query);
            return View(list);
        }

        public IActionResult Details([FromRoute(Name = "id")] int id)
        {
            var person = _personService.GetById(id);
            if (person is null)
                return NotFound();
            return View(person);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _personService.Create(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var person = _personService.GetById(id);
            if (person is null)
                return NotFound();
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute(Name = "id")] int id, Person person)
        {
            if (id != person.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var ok = _personService.Update(person);
                if (!ok)
                    return NotFound();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            var person = _personService.GetById(id);
            if (person is null)
                return NotFound();
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute(Name = "id")] int id)
        {
            var ok = _personService.Delete(id);
            if (!ok)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
