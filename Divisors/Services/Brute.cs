// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Divisors.Interfaces;
using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Brute force finding the divisors
    /// </summary>
    public class Brute : AbstractCalculator
    {
        /// <summary>
        /// Calculate the common divisors
        /// </summary>
        /// <remarks>This can take a long time...</remarks>
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
            // restart report
            long limit = Math.Min(numberA, numberB);
            for (long i = 2; i <= limit; i++)
            {
                progress.Report((double)i / limit);
                if (numberA % i == 0 && numberB % i == 0)
                {
                    output.Add(i);
                }
            }
            return output;
        }
    }
}