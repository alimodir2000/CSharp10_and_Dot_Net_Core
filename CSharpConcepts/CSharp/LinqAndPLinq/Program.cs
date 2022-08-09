using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqAndPLinq
{
    record Person(string Name, int Age);


    record Course(string Title);
    record Student(string Name);
    record Company(string Name, List<Person> Staff);


    record Person1(string Name, int Age, List<string> Languages);



    class Program
    {


        static void Main(string[] args)
        {
            // The basics 

            var people = new List<Person>()
            {
                new Person("Tom", 23),
                new Person("Bob", 27),
                new Person("Sam", 29),
                new Person("Alice", 24)
            };

            var names = from p in people select (p.Name);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            var personel = from p in people
                           let name = $"Mr. {p.Name}"
                           let year = DateTime.Now.Year - p.Age
                           select new
                           {
                               Name = name,
                               Year = year
                           };

            foreach (var item in personel)
            {
                Console.WriteLine($"{item.Name} - {item.Year}");
            }



            //Sampling from multiple sources


            var courses = new List<Course> { new Course("C#"), new Course("Java") };
            var students = new List<Student> { new Student("Tom"), new Student("Bob") };

            var enrolments = from c in courses
                             from s in students
                             select new { Student = s.Name, Course = c.Title };

            foreach (var item in enrolments)
            {
                Console.WriteLine($"{item.Student} - {item.Course}");
            }


            //select many
            var companies = new List<Company>
            {
                new Company("Microsoft", new List<Person> {new Person("Tom", 30), new Person("Bob", 31) }),
                new Company("Google", new List<Person> {new Person("Sam", 30), new Person("Mike", 29) }),
            };


            var employees = companies.SelectMany(x => x.Staff,
                (x, emp) => new { Name = emp.Name, Company = x.Name });


            /*
             * Select and SelectMany are projection operators. A select operator is used to select value from a collection and SelectMany operator is used to selecting values from a collection of collection i.e. nested collection.
             */


            //filtering 

            var people1 = new List<Person1>
            {
                new Person1 ("Tom", 23, new List<string> {"english", "german"}),
                new Person1 ("Bob", 27, new List<string> {"english", "french" }),
                new Person1 ("Sam", 29, new List<string>  { "english", "spanish" }),
                new Person1 ("Alice", 24, new List<string> {"spanish", "german" })
            };

            var selectedPeople = from p in people1
                                 where p.Age > 25
                                 select p;

            var selectedPeople1 = from p in people1
                                  from lang in p.Languages
                                  where p.Age > 24
                                  where lang == "english"
                                  select new { Name = p.Name, Language = lang };


            var selectedPeople11 = people1.SelectMany(u => u.Languages,
                    (u, l) => new { Person = u, Lang = l }
                ).Where(x => x.Lang == "english" && x.Person.Age > 24)
                .Select(x => new { Name = x.Person.Name, Language = x.Lang });



            Console.WriteLine("------------------------------------");
            GoupByExample.Example1();
            Console.WriteLine("------------------------------------");
            GoupByExample.Example2();

            Console.WriteLine("Hello World!");
        }
    }
}
