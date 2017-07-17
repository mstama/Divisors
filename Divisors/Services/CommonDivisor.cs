using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    public class CommonDivisor
    {
        private readonly IProgress<double> _progress;

        public CommonDivisor(IProgress<double> progress)
        {
            _progress = progress;
        }

        public IList<long> Calculate(long numberA, long numberB)
        {
            var output = new List<long>
            {
                1
            };
            var gcd = GCD(numberA, numberB);
            if (gcd != 1)
            {
                output.Add(gcd);
            }
            var sqrt = Math.Sqrt(gcd);
            for (long i = 2; i <= sqrt; i++)
            {
                _progress.Report((double)i / sqrt);
                if (gcd % i == 0)
                {
                    output.Add(i);
                    var divisor = gcd / i;
                    if (i != divisor)
                    {
                        output.Add(divisor);
                    }
                }
            }
            _progress.Report(1);
            return output;
        }

        private long GCD(long numberA, long numberB)
        {
            long smaller = Math.Min(numberA, numberB);
            long bigger = Math.Max(numberA, numberB);
            long remainder = bigger % smaller;
            if (remainder == 0)
            {
                return smaller;
            }
            else
            {
                return GCD(smaller, remainder);
            }
        }
    }
}