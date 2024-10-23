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
        public IActionResult Index()
        {
            var people = _peopleManagerDbContext.People.ToList();
            return View(people);
            /*
             * Probeer geen geneste methodes => voor breakpoints/debuggen zéér slecht, minder leesbaar
             * return View(GetPeople());
             */
        }
    }
}
