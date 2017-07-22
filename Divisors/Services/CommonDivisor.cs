using Divisors.Interfaces;
using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Using the greater common divisor
    /// </summary>
    public class CommonDivisor : AbstractCalculator
    {
        /// <summary>
        /// Calculate the common divisors
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public override IList<long> Calculate(long numberA, long numberB, IProgress<double> progress)
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
                progress.Report((double)i / sqrt);
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
            progress.Report(1);
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