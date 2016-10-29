using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    class MultiplesOf3And5
    {
        public static int GetResult(int limit)
        {
            int sum = 0;
            int current = 3;
            while (current < limit)
            {
                sum += current;
                current += 3;
            }
            current = 5;
            while (current < limit)
            {
                sum += current;
                current += 5;
            }
            return sum;
        }
    }
}
