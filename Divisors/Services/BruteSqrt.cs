// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Divisors.Interfaces;
using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Brute force using square root
    /// </summary>
    public class BruteSqrt : AbstractCalculator
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
                progress.Report((double)i / sqrt);
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
            progress.Report(1);
            return output;
        }
    }
}