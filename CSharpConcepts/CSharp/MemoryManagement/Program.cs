using System;

namespace MemoryManagement
{
    class Program
    {

        static void Main(string[] args)
        {
            long totalMemory = GC.GetTotalMemory(false);
            //The GetTotalMemory method returns the amount of memory, in bytes, that is occupied on the managed heap

            var t = "This is test";
            var tGeneration =  GC.GetGeneration(t);
            //The GetGeneration(Object) method allows you to determine the generation number to which the object passed as a parameter belongs
            //Generation 0 refers to new objects that have never been garbage collected. Generation 1 refers to objects that have survived one collection, and generation 2 refers to objects that have gone through more than one garbage collection.


            GC.AddMemoryPressure(2048);
        
            totalMemory = GC.GetTotalMemory(false);

            Test test = new Test("John");

            GC.Collect();

            Console.WriteLine(totalMemory);


            //using Person person = new Person("Ali");
            using Employee SalesManager = new Employee("John", 1002);


            unsafe
            {
                Person person = new Person("Ali");
                int* x; // pointer definition
                int y = 10; // define variable

                x = &y; // pointer x now points to the address of variable y
                int** z = &x; // pointer z now points to the address of pointer x
                **z = **z + 40; // changing the pointer z will change the variable y
                Console.WriteLine(y); // variable y=50
                Console.WriteLine(**z); // variable **z=50
                

            }



            Console.ReadKey();
        }
    }
}
