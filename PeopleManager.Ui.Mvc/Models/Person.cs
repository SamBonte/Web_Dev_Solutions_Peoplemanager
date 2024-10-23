using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Ui.Mvc.Models
{
    [Table(nameof(Person))] // om in PeopleManagerDbContext aan te geven db tabelnaam waarin zoeken = Person NIET People

    public class Person
    {
        public int Id { get; set; }
        public required string FirstName {get; set; }
        public required string LastName {get; set; }
        public string? Email {get; set; }

    }
}
