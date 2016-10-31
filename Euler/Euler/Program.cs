using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euler.Problems;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MultiplesOf3And5.GetResult(1000));
            Console.WriteLine(EvenFibonacciNumbers.GetResult((int)Math.Pow(10, 6) * 4));
            Console.WriteLine(LargestPrimeFactor.GetResult(600851475143));
        }
    }
}
