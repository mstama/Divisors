﻿using Divisors.Interfaces;
using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Brute force using square root
    /// </summary>
    public class BruteSqrt : ICalculator
    {
        private readonly IProgress<double> _progress;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="progress"></param>
        public BruteSqrt(IProgress<double> progress)
        {
            _progress = progress;
        }

        /// <summary>
        /// Calculate the common divisors
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        public IList<long> Calculate(long numberA, long numberB)
        {
            var output = new List<long>
            {
                1
            };
            long smaller = Math.Min(numberA, numberB);
            long bigger = Math.Max(numberA, numberB);
            if (bigger % smaller == 0)
            {
                output.Add(smaller);
            }
            var sqrt = Math.Sqrt(smaller);
            // restart report
            for (long i = 2; i <= sqrt; i++)
            {
                _progress.Report((double)i / sqrt);
                if (smaller % i == 0 && bigger % i == 0)
                {
                    output.Add(i);
                    var divisor = smaller / i;
                    if (i != divisor && bigger % divisor == 0)
                    {
                        output.Add(divisor);
                    }
                }
            }
            _progress.Report(1);
            return output;
        }
    }
}