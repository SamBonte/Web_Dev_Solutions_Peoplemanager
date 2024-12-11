using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleManager.Model
{
    [Table(nameof(Person))] // om in PeopleManagerDbContext aan te geven db tabelnaam waarin zoeken = Person NIET People

    public class Person
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        //[Required(ErrorMessage = "Je moet dit invullen")] // zegt aan gebruiker, voornaam moet meegeven worden
        [Required] // voor ons dit genoeg
        public required string FirstName {get; set; }
        [DisplayName("Last Name")]
        [Required]
        public required string LastName {get; set; }
        [EmailAddress] // zeggen dat input type="email"
        public string? Email {get; set; }

    }
}
