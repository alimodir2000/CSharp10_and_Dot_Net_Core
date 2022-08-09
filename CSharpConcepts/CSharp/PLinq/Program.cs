using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLinq
{

    internal class Program
    {
        public static int Square(int x)
        {
            Thread.Sleep(1000);
            return x * x;
        }

        static void Main(string[] args)
        {

            object[] numbers = { 1, 2, 3, 4, 5, 6 };
            //var squeres = from n in numbers.AsParallel()
            //              let x = (int)n
            //              select Square(x);


            //var squeres1 = from n in numbers.AsParallel().AsOrdered()
            //               let x = (int)n
            //               select Square(x);


            //try
            //{
            //    squeres.ForAll(x => Console.WriteLine(x));
            //    Console.WriteLine("-------------------------");
            //    squeres1.ForAll(x => Console.WriteLine(x));
            //}
            //catch (AggregateException ex)
            //{
            //    foreach (var e in ex.InnerExceptions)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}


           


            //cancelation


            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(() =>
            {
                Thread.Sleep(1100);
                cts.Cancel();
            }).Start();

            try
            {
                var squares2 = from n in numbers.AsParallel().WithCancellation(cts.Token)
                    let x = (int)n
                    select Square(x);
                squares2.ForAll(x => Console.WriteLine(x));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation Cancelled");
            }
            catch (AggregateException ex)
            {
                foreach (var item in ex.InnerExceptions)
                {
                    Console.WriteLine(item.Message);
                }
            }
            finally
            {
                cts.Dispose();
            }

            Console.ReadKey();

        }
    }
}
