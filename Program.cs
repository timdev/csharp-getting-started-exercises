using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Person
    {
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
        }

        protected string FirstName { get; private set; }
        protected string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

        public bool IsAnAdult()
        {
            var eighteenYearsAgo = DateTime.Today.AddYears(-18);
            return this.DateOfBirth < eighteenYearsAgo;
        }
    }

    public class Student : Person
    {
        public Student(string firstName, string lastName, DateTime dateOfBirth)
            : base(firstName, lastName, dateOfBirth)
        { }
        public string SchoolName { get; set; }

        public string RosterName { get { return $"{this.LastName}, {this.FirstName}"; } }
    }

    public class Course
    {
        public string Name { get; private set; }

        private List<Student> Students;

        public Course(string name)
        {
            Name = name;
            Students = new List<Student> ();            
        }

        public void Enroll(Student student)
        {
            if (Students.Contains(student)) return;
            Students.Add(student);
        }

        public void Withdraw(Student student)
        {
            Students.Remove(student);
        }

        public List<string> Roster() 
        {
            var roster = new List<string> ();
            foreach(Student student in Students)
            {
                roster.Add(student.RosterName);
            }
            return roster;
        }


    }
    public class Program
    {
        public static void Main()
        {
            var timdev = new Student("Tim", "Lieberman", DateTime.Parse("12/21/1975"));
            var dweez = new Student("Dweezil", "Zappa", DateTime.Parse("9/5/1969"));
            var phil = new Student("Phil", "Greenspun", DateTime.Parse("9/28/1963"));

            // Create course, and enroll three students.
            Course course = new Course("Introduction to C#");
            course.Enroll(timdev);
            course.Enroll(dweez);
            course.Enroll(phil);
            
            // Display the roster.
            Console.WriteLine(course.Name + " (Before Dweezil Quits):");
            Console.WriteLine(String.Join("\n", course.Roster()));
            
            // Dweezil couldn't hack it.  He shoudl stick to guitar.
            course.Withdraw(dweez);

            // Display updated roster.
            Console.WriteLine();
            Console.WriteLine(course.Name + " (After Dweezil Quits):");
            Console.WriteLine(String.Join("\n", course.Roster()));

        }
    }
}
