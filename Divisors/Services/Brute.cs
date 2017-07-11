using System;
using System.Collections.Generic;
using System.Text;

namespace Divisors.Services
{
    public class Brute
    {
        public IList<long> Calculate(long a, long b)
        {
            var output = new List<long>();
            output.Add(1);
            for(long i = 2; i <= a && i <= b; i++)
            {
                if(a%i==0 && b % i == 0)
                {
                    Console.WriteLine("{0}", i);
                    output.Add(i);
                }
            }
            return output;
        }
    }
}
