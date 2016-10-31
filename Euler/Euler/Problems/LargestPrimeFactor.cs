using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    class LargestPrimeFactor
    {
        public static long GetResult(long numm)
        {
            //const long numm = 600851475143;
            long newnumm = numm;
            long largestFact = 0;

            int counter = 2;
            while (counter * counter <= newnumm)
            {
                if (newnumm % counter == 0)
                {
                    newnumm = newnumm / counter;
                    largestFact = counter;
                }
                else
                {
                    counter++;
                }
            }
            if (newnumm > largestFact)
            { // the remainder is a prime number
                largestFact = newnumm;
            }
            return largestFact;
        }

        public static void Primes(int num)
        {
            var primes = Enumerable.Range(0, (int)Math.Floor(2.52 * Math.Sqrt(num) / Math.Log(num))).Aggregate(
                Enumerable.Range(2, num - 1).ToList(),
                (result, index) =>
                {
                    var bp = result[index];
                    var sqr = bp * bp;
                    result.RemoveAll(i => i >= sqr && i % bp == 0);
                    return result;
                });
            Console.WriteLine(String.Join(",", primes));
        }

    }
}
