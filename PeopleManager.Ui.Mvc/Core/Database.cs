using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Core
{
    public class Database
    {
        public IList<Person> People { get; set; } = new List<Person>();

        public void Seed()
        {
            People = new List<Person>
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Person { Id = 2, FirstName = "Jane", LastName = "Smith", Email = null },  // No email
                new Person { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com" },
                new Person { Id = 4, FirstName = "Bob", LastName = "Williams", Email = null }, // No email
                new Person { Id = 5, FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com" },
                new Person { Id = 6, FirstName = "David", LastName = "Miller", Email = null }, // No email
                new Person { Id = 7, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com" },
                new Person { Id = 8, FirstName = "Frank", LastName = "Garcia", Email = "frank.garcia@example.com" },
                new Person { Id = 9, FirstName = "Grace", LastName = "Martinez", Email = null }, // No email
                new Person { Id = 10, FirstName = "Henry", LastName = "Rodriguez", Email = "henry.rodriguez@example.com" }
            };
        }
    }
}
