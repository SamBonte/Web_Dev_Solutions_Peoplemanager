using Microsoft.AspNetCore.Mvc;
using PeopleManager.Repository;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController(PersonService personService) : Controller
    {
        // dependency injection => in dependency readonly => vermijd fouten bv. overschrijven veld
        private readonly PersonService _personService = personService;

        /*public PeopleController(PeopleManagerDbContext peopleManagerDbContext)
        {
            _peopleManagerDbContext = peopleManagerDbContext;
        }*/

        [HttpGet] //Juiste Http methodes zetten om onvoorzienigheden te vermijden
        public IActionResult Index()
        {
            return View(_personService.Find());
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
            var person = _personService.Update(id, _personService.Get(id));
            if (person is null)
            {
                return RedirectToAction("Index");
            }
            
            return View(person);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // we willen vragen of men zeker is om persoon "x" te verwijderen
            var person = _personService.Get(id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }

            return View(person);
        }

        [HttpPost]
        [Route("People/Delete/{id:int?}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            /*
            OPTIE1: Meer info, eigenlijk niet nodig = 1 query meer doen, maar is oké 
            var person = _peopleManagerDbContext.People.FirstOrDefault(p => p.Id == id);
            if (person is null)
            {
                return RedirectToAction("Index");
            }*/

            /*
            OPTIE2: Query minder uitvoeren, nadeel als al gedelete = kan ie niet weten = niet erg, bestaat niet = weet hij ook niet
             */
            
            _personService.Delete(id);

            return RedirectToAction("Index");
        }



        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id, [FromForm]Person person)
        // in Controller hebben we Routing ingesteld: "{controller=Home}/{action=Index}/{id?}" 
        // ook krijgt hij de url binnen met Home/Edit/{id}
        // Beter om te scheiden voor duidelijkheid = veiligheid. Id = om te zoeken, person = blokje met veranderingen

        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _personService.Update(id, person);
            // Na aanpassing terug naar Index pagina
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        // Create([FromForm]Person person) = zeggen enkel persoon uit form accepteren als parameter
        public IActionResult Create([FromForm]Person person) 
        {
            /* Zelf een custom Error / validatie
            if (person.FirstName == "Magere" && person.LastName == "Hein")
            {
                ModelState.AddModelError(string.Empty, "We don't like your kind here...");
            }*/

            if (!ModelState.IsValid)
            {
                return View(person);
            }

            /*Om nieuwe persoon toe te voegen*/
            _personService.Create(person);
            
            /*NIET return View("Index") -> zal in url nog steeds ../Create en om index te renderen lijst nodig zie Index-action PeopleController*/
            return RedirectToAction("Index");
        }
    }
}
