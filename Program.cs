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

            Console.WriteLine("Find developers older than X.");
            
            var minAge = AskMinAge();

            var agedDevs = people.Where(x => x.Age >= minAge && x.Occupation == "Dev");

            Console.WriteLine();
            Console.WriteLine("Found {0} Developers of at least {1} years of age.", agedDevs.Count(), minAge);
            foreach(Person dev in agedDevs)
            {
                Console.WriteLine($"\t{dev.FullName} is {dev.Age} years old.");
            }
        }

        private static int AskMinAge()
        {
            Console.Write("Enter minimum age (numbers only): ");
            string str = Console.ReadLine();
            int min;
            if (Int32.TryParse(str, out min))
            {
                return min;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invalid min-age, must be an integer.");
            Console.ResetColor();
            return AskMinAge();
        }
        public static List<Person> GenerateListOfPeople()
        {
            var people = new List<Person>();

            people.Add(new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24 });
            people.Add(new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40 });
            people.Add(new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30 });
            people.Add(new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35 });
            people.Add(new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24 });

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
