using System;
using System.Collections.Generic;

namespace ConsoleApplication
{

    public class Address
    {
        public Address(string streetAddress, string city, string state, string postalCode, string country)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;  
        }

        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }

        public override string ToString() 
        {
            return $"{StreetAddress}\n{City}, {State}, {PostalCode}\n{Country}";
        }
    }
    public class Person
    {

        public string Name { get { return $"{FirstName} {LastName}"; } }

        public string FirstName { get; private set; }
     
        public string LastName { get; private set; }
     
        public Address ShippingAddress { get; private set; }

        public Person(string firstName, string lastName, Address shippingAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            ShippingAddress = shippingAddress;
        }

        public override string ToString()
        {
            return Name + "\n" + ShippingAddress;
        }

    }
    public class Company
    {
        public string Name { get; private set; }

        public Address ShippingAddress { get; private set; }

        public Company(string name, Address shippingAddress)
        {
            Name = name;
            ShippingAddress = shippingAddress;
        }

        public override string ToString()
        {
            return Name + "\n" + ShippingAddress;
        }
    }


    public class Program
    {
        public static void Main()
        {
            var people = new List<Person> ();
            
            people.Add(new Person("Homer", "Simpson", new Address("742 Evergreen Terrace", "Springfield", "XY", "12345", "USA")));
            people.Add(new Person("Marge", "Simpson", new Address("742 Evergreen Terrace", "Springfield", "XY", "12345", "USA")));
            people.Add(new Person("Waylon", "Smithers", new Address("100 Industrial Way", "Springfield", "XY", "12345", "USA")));
            people.Add(new Person("Charles Montgomery", "Burns", new Address("100 Industrial Way", "Springfield", "XY", "12345", "USA")));
            people.Add(new Person("Aristotle", "Amadopolis", new Address("200 Maple Ave", "Shelbyville", "XY", "12346", "USA")));
            
            var companies = new List<Company> ();

            companies.Add(new Company("Springfield Nuclear Power Plant", new Address("100 Industrial Way", "Springfield", "XY", "12345", "USA")));
            companies.Add(new Company("Moe's Tavern", new Address("125 Main St.", "Springfield", "XY", "12345", "USA")));
            companies.Add(new Company("Speed-E-Mart", new Address("234 Oak St.", "Shelbyville", "XY", "12346", "USA")));
            companies.Add(new Company("Shelbyville Nuclear Power Plant", new Address("200 Maple Ave", "Shelbyville", "XY", "12346", "USA")));

            foreach(var person in people)
            {
                Console.WriteLine(person + "\n");                
            }

            Console.WriteLine();

            foreach(var company in companies)
            {
                Console.WriteLine(company + "\n");
            }


        }
    }
}
