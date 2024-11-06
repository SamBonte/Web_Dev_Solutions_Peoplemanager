using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController(PeopleManagerDbContext peopleManagerDbContext) : Controller
    {
        // dependency injection => in dependency readonly => vermijd fouten bv. overschrijven veld
        private readonly PeopleManagerDbContext _peopleManagerDbContext = peopleManagerDbContext;

        /*public PeopleController(PeopleManagerDbContext peopleManagerDbContext)
        {
            _peopleManagerDbContext = peopleManagerDbContext;
        }*/

        [HttpGet] //Juiste Http methodes zetten om onvoorzienigheden te vermijden
        public IActionResult Index()
        {
            var people = _peopleManagerDbContext.People.ToList();
            return View(people);
            /*
             * Probeer geen geneste methodes => voor breakpoints/debuggen zéér slecht, minder leesbaar
             * return View(GetPeople());
             */
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            /*Om nieuwe persoon toe te voegen*/
            _peopleManagerDbContext.People.Add(person);
            /*Toevoegen aan EntityFramework sqlserver*/
            _peopleManagerDbContext.SaveChanges();
            /*NIET return View("Index") -> zal in url nog steeds ../Create en om index te renderen lijst nodig zie Index-action PeopleController*/
            return RedirectToAction("Index");
        }
    }
}
