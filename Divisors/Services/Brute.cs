using Divisors.Interfaces;
using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Brute force finding the divisors
    /// </summary>
    public class Brute : ICalculator
    {
        private readonly IProgress<double> _progress;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="progress"></param>
        public Brute(IProgress<double> progress)
        {
            _progress = progress;
        }

        /// <summary>
        /// Calculate the common divisors
        /// </summary>
        /// <remarks>This can take a long time...</remarks>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        public IList<long> Calculate(long numberA, long numberB)
        {
            var output = new List<long>
            {
                1
            };
            // restart report
            long limit = Math.Min(numberA, numberB);
            for (long i = 2; i <= limit; i++)
            {
                _progress.Report((double)i / limit);
                if (numberA % i == 0 && numberB % i == 0)
                {
                    output.Add(i);
                }
            }
            return output;
        }
    }
}