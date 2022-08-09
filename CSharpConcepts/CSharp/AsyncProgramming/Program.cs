using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class Repository
    {
        string[] data = { "Tom", "Sam", "Kate", "Alice", "Bob" };

        public async IAsyncEnumerable<string> GetDataAsync()
        {
            for (int i = 0; i < data.Length; i++)
            {
                await Task.Delay(500);
                yield return data[i];
            }
        }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            PrintName("A");
            PrintName("B");
            PrintName("C");
            Console.WriteLine(DateTime.Now.ToLongTimeString());

            Console.WriteLine(DateTime.Now.ToLongTimeString());
            var t1 =PrintNameAsync("A");
            var t2 = PrintNameAsync("B");
            var t3 = PrintNameAsync("C");

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine("-------------------------------");


            var tr1 = SquareAsync(2);
            var tr2 = SquareAsync(5);
            var tr3 = SquareAsync(8);



            var results = await Task.WhenAll(tr1, tr2, tr3);
            foreach (int result in results)
                Console.WriteLine(result);




            Console.WriteLine("-------------------------------");

            // Asynchronous Streams
            var rep = new Repository();
            var data = rep.GetDataAsync();
            await foreach (var item in data)
            {
                Console.WriteLine(item);
            }





            Console.ReadKey();
        }

        static void PrintName(string name)
        {
            Console.WriteLine(name);
            Thread.Sleep(3000);
            
        }


        static async Task PrintNameAsync(string name)
        {
            Console.WriteLine(name);
            await Task.Delay(3000);
           
        }

        static async Task<int> SquareAsync(int n)
        {
            await Task.Delay(1000);
            return n * n;
        }


    }
}
