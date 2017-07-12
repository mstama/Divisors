using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    public class Brute2
    {
        public IList<long> Calculate(long numberA, long numberB)
        {
            var output = new List<long>
            {
                1
            };
            long smaller = numberA > numberB ? numberB : numberA;
            long bigger = numberA < numberB ? numberB : numberA;
            if (bigger % smaller == 0)
            {
                output.Add(smaller);
            }
            var sqrt = Math.Sqrt(smaller);
            for (long i = 2; i <= sqrt; i++)
            {
                if (numberA % i == 0 && numberB % i == 0)
                {
                    output.Add(i);
                    var divisor = numberA / i;
                    if (i != divisor)
                    {
                        output.Add(divisor);
                    }
                }
            }
            return output;
        }
    }
}