using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Core;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController(Database database) : Controller
    {
        // dependency injection => in dependency readonly => vermijd fouten bv. overschrijven veld
        private readonly Database _database = database;

        /*public PeopleController(Database database)
        {
            _database = database;
        }*/
        public IActionResult Index()
        {
            var people = _database.People;
            return View(people);
            /*
             * Probeer geen geneste methodes => voor breakpoints/debuggen zéér slecht, minder leesbaar
             * return View(GetPeople());
             */
        }
    }
}
