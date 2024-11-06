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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // FirstOrDefault() gaat er van uit dat id kan bestaan of niet
            var person = _peopleManagerDbContext.People.FirstOrDefault(p => p.Id == id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }
            
            return View(person);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, [FromForm]Person person)
        // in Controller hebben we Routing ingesteld: "{controller=Home}/{action=Index}/{id?}" 
        // ook krijgt hij de url binnen met Home/Edit/{id}
        // Beter om te scheiden voor duidelijkheid = veiligheid. Id = om te zoeken, person = blokje met veranderingen

        {
            var dbPerson = _peopleManagerDbContext.People.FirstOrDefault(p => p.Id == id);
            if (dbPerson is null)
            {
                return RedirectToAction("Index");
            }

            // EntityFramework gaat kijken wat er moet veranderd worden en ENKEL dat loggen als changed
            // enkel de dbPerson heeft tracking om veranderingen op te merken en toe te passen op database
            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;
            // Ons werk opslaan
            _peopleManagerDbContext.SaveChanges();
            // Na aanpassing terug naar Index pagina
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Person person) 
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
