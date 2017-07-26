// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;

namespace Divisors.Interfaces
{
    /// <summary>
    /// Calculator interface
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Do the math!
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        IList<long> Calculate(long numberA, long numberB);

        /// <summary>
        /// Do the math and report progress
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        IList<long> Calculate(long numberA, long numberB, IProgress<double> progress);
    }
}