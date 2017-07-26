// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Divisors.Interfaces;
using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    public class ProgressConsoleDecorator : ICalculator
    {
        private readonly ICalculator _calculator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calculator"></param>
        public ProgressConsoleDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Calculate providing progress console info
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public IList<long> Calculate(long numberA, long numberB, IProgress<double> progress)
        {
            return Calculate(numberA, numberB);
        }

        /// <summary>
        /// Calculate providing progress console info
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        public IList<long> Calculate(long numberA, long numberB)
        {
            using (var progress = new ProgressConsole())
            {
                return _calculator.Calculate(numberA, numberB, progress);
            }
        }

        public override string ToString()
        {
            return _calculator.ToString();
        }
    }
}