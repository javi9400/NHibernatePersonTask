using ExampleNhibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleNhibernate.Services
{
    public class PersonService
    {
        public static void GetPerson(Person person)
        {
            Console.WriteLine(person.Name);
            Console.WriteLine();
        }
    }
}
