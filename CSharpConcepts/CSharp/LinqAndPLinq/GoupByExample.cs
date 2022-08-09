using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAndPLinq
{
    record Person2(string Name, string Company);

    public class GoupByExample
    {
        public static void Example1()
        {
            Person2[] people =
            {
                new Person2("Tom", "Microsoft"), new Person2("Sam", "Google"),
                new Person2("Bob", "JetBrains"), new Person2("Mike", "Microsoft"),
                new Person2("Kate", "JetBrains"), new Person2("Alice", "Microsoft"),
            };

            var companies = from person in people
                group person by person.Company;

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var person2 in company)
                {
                    Console.WriteLine(person2.Name);
                }
                Console.WriteLine();
            }

        }



        public static void Example2()
        {
            Person2[] people =
            {
                new Person2("Tom", "Microsoft"), new Person2("Sam", "Google"),
                new Person2("Bob", "JetBrains"), new Person2("Bob", "Microsoft"),
                new Person2("Kate", "JetBrains"), new Person2("Alice", "Microsoft"),
            };

            var companies = people.GroupBy(x => x.Company);
            var names = people.GroupBy(x => x.Company).ToList();

            //foreach (var company in companies)
            //{
            //    Console.WriteLine(company.Key);
            //    foreach (var person2 in company)
            //    {
            //        Console.WriteLine(person2.Name);
            //    }
            //    Console.WriteLine();
            //}


            foreach (var name in names)
            {
                Console.WriteLine(name.Key);
                foreach (var person2 in name)
                {
                    Console.WriteLine(person2.Company);
                }
                Console.WriteLine();
            }

        }
    }
}
