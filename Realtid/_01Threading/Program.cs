using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _01Threading.Comps;

namespace _01Threading
{
    class Program
    {
        static readonly object locker = new object();

        static int[] numbers = new int[50];

        static void Main(string[] args)
        {
            FirstCase();
            Console.ReadKey();
            SecondCase();
        }

        static void SecondCase()
        {
            Console.WriteLine("Second case:");

            var foo = new Foo();
            new Thread(() => foo.Fill(3)).Start();
            var thread = new Thread(foo.Fill);
            thread.Start(5);
            foo.FillInt(7);
        }

        static void FirstCase()
        {
            Console.WriteLine("First case:");
            new Thread(FillA).Start();
            for (int i = 0; i < 20; i++)
            {
                FillB(9);
            }
        }

        static void FillA()
        {
            for (int i = 0; i < 20; i++)
            {
                FillB(0);
            }
        }


        static void FillB(int n)
        {
            lock (locker)
            {
                for (int i = 0; i < 50; i++)
                {
                    numbers[i] = n;
                }
                foreach (int i in numbers)
                {
                    Console.Write(numbers[i]);
                }
                Console.WriteLine("");
            }

        }
    }
}
