using System;

namespace MemoryManagement
{
    class Test
    {
        public string Name { get; set; }
        public Test(string name) => Name = name;

        ~Test()
        {
            Console.WriteLine($"{Name} - deleted");
        }

        /*
         * The destructor should only be implemented on objects that really need it, as the Finalize method has a strong performance impact.         *
         *
         */
    }


    public class Person : IDisposable
    {
        public Person(string title) => Title = title;
        public string Title { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"Person {Title} disposed");
        }

    }

    public class Employee : Person
    {
        public int ID { get; set; }
        public Employee(string title, int id) : base(title) => ID = id;
        public void Dispose()
        {
            Console.WriteLine($"Employee {Title} disposed");
            base.Dispose();
        }
    }
}