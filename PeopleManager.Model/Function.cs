using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Model
{
    [Table(nameof(Function))]
    public class Function
    {
        public int id { get; set; }
        public string Name { get; set; }

        // Steek er maar direct een lege lijst in, maakt het makkelijker
        public IList<Person> People { get; set; } = new List<Person>();


    }
}
