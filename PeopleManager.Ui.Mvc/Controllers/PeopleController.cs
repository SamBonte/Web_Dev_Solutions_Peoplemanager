using Microsoft.AspNetCore.Mvc;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            var people = GetPeople();
            return View(people);
            /*
             * Probeer geen geneste methodes => voor breakpoints/debuggen zéér slecht, minder leesbaar
             * return View(GetPeople());
             */
        }

        private IList<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Person { FirstName = "Jane", LastName = "Smith", Email = null },  // No email
                new Person { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" },
                new Person { FirstName = "Bob", LastName = "Williams", Email = null }, // No email
                new Person { FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com" },
                new Person { FirstName = "David", LastName = "Miller", Email = null }, // No email
                new Person { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com" },
                new Person { FirstName = "Frank", LastName = "Garcia", Email = "frank.garcia@example.com" },
                new Person { FirstName = "Grace", LastName = "Martinez", Email = null }, // No email
                new Person { FirstName = "Henry", LastName = "Rodriguez", Email = "henry.rodriguez@example.com" }
            };
        }
    }
}
