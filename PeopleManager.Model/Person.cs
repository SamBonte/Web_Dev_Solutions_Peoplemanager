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
        public required string FirstName { get; set; }

        [DisplayName("Last Name")] [Required] public required string LastName { get; set; }

        [EmailAddress] // zeggen dat input type="email"
        public string? Email { get; set; }

        // Zeggen in de database kan id leeg zijn. (Nog geen functie toegewezen)
        public int? FunctionId { get; set; }

        // We zeggen dat de navigatie-property in de initiële situatie null is.
        // Negeer waarschuwing voor mogelijke NullPointerExceptions.
        // Wij gaan het later wel invullen. (Zeggen tegen VS, we zorgen dat we het oplossen)

        /*public Function? Function { get; set; }; => NIET OPTIMAAL, elke keer controleren of het niet null zou zijn*/
        public Function Function { get; set; } = null!;

    }
}
