using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Ui.Mvc.Models
{
    [Table(nameof(Person))] // om in PeopleManagerDbContext aan te geven db tabelnaam waarin zoeken = Person NIET People

    public class Person
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public required string FirstName {get; set; }
        [DisplayName("Last Name")]
        public required string LastName {get; set; }
        [EmailAddress] // zeggen dat input type="email"
        public string? Email {get; set; }

    }
}
