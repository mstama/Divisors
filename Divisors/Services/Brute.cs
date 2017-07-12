using System.Collections.Generic;

namespace Divisors.Services
{
    public class Brute
    {
        public IList<long> Calculate(long numberA, long numberB)
        {
            var output = new List<long>
            {
                1
            };
            long limit = numberA > numberB ? numberB : numberA;
            for (long i = 2; i <= limit; i++)
            {
                if (numberA % i == 0 && numberB % i == 0)
                {
                    output.Add(i);
                }
            }
            return output;
        }
    }
}