using System;
using System.Collections.Generic;
using System.Linq;

namespace GettingStartedTutorials.CSharp
{

    public class Program
    {
        public static void Main()
        {
            var people = GenerateListOfPeople();

            Console.WriteLine("Find People by Name.");
            
            var namePart = AskNamePart().ToLower();

            var matches = people.Where(x => x.FirstName.ToLower().StartsWith(namePart)  || x.LastName.ToLower().StartsWith(namePart));

            Console.WriteLine();
            Console.WriteLine("Found {0} Developers with a name like '{1}'", matches.Count(), namePart);
            foreach(Person dev in matches)
            {
                Console.WriteLine($"\t{dev.FullName} matches.");
            }
        }

        private static string AskNamePart()
        {
            Console.Write("Enter a first or last name (3 or more characters): ");
            string name = Console.ReadLine().Trim();
            if (name.Length > 2){
                return name;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Error: You must enter at least three letters.");
            Console.ResetColor();
            return AskNamePart();
        }

        public static List<Person> GenerateListOfPeople()
        {
            var people = new List<Person>();

            people.Add(new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24 });
            people.Add(new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40 });
            people.Add(new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30 });
            people.Add(new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35 });
            people.Add(new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24 });
            people.Add(new Person { FirstName = "Reggie", LastName = "Jones", Occupation = "Manager", Age = 27 });
            people.Add(new Person { FirstName = "Dweezil", LastName = "Zappa", Occupation = "Guitarist", Age = 46 });

            return people;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }

        public string FullName {
            get 
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
