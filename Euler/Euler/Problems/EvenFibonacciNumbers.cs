using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    class EvenFibonacciNumbers
    {
        public static int GetResult(int limit)
        {
            int a = 1;
            int b = 2;
            int temp;
            int sum = b;
            while (b < limit)
            {
                temp = a + b;
                a = b;
                b = temp;
                if (temp % 2 == 0)
                    sum += temp;
            }
            return sum;
        }
    }
}
