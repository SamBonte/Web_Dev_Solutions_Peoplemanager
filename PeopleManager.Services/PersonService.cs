using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Model;
using PeopleManager.Repository;

namespace PeopleManager.Services
{
    public class PersonService
    {
        private readonly PeopleManagerDbContext _dbContext;
        public PersonService(PeopleManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Find = lijst opvragen van personen
        public IList<Person> Find()
        {
            return _dbContext.People.ToList();
        }

        //Get(id) = 1 specifieke ophalen, hier op basis van id
        /*Person? = zeggen we weten niet of we een Persoon zullen vinden, nadeel: gebruiker weet niet wat er mis ging*/
        public Person? Get(int id)
        {
            return _dbContext.People.FirstOrDefault(p => p.Id == id);
        }

        //Create = 1 aanmaken met gegeven info
        /*validatie kun je hier toevoegen*/
        public Person Create(Person person)
        {
            _dbContext.People.Add(person);
            
            _dbContext.SaveChanges();

            return person;
        }

        //Update = 1 wijzigen op basis gegeven info
        /*id scheiden van de payload (= gewijzigde velden van persoon)*/
        public Person? Update(int id, Person person)
        {
            var dbPerson = _dbContext.People.FirstOrDefault(p => p.Id == id);
            if (dbPerson is null)
            {
                return null;
            }

            // EntityFramework gaat kijken wat er moet veranderd worden en ENKEL dat loggen als changed
            // enkel de dbPerson heeft tracking om veranderingen op te merken en toe te passen op database
            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;
            // Ons werk opslaan
            _dbContext.SaveChanges();
            // Na aanpassing persoon teruggeven
            return person;
        }

        //Delete
        public void Delete(int id)
        {
            var person = new Person()
            {
                Id = id,
                FirstName = string.Empty,
                LastName = string.Empty
            };

            // Attach ziet hem als een nieuwe
            // Modify ziet als verandert
            // Remove ziet id om te verwijderen
            _dbContext.People.Attach(person);

            _dbContext.People.Remove(person);
            // wijzigingen toepassen:
            _dbContext.SaveChanges();

        }


    }
}
