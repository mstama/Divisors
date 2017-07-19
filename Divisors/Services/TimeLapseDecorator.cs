using Divisors.Interfaces;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Print time used in execution
    /// </summary>
    public class TimeLapseDecorator :ICalculator
    {
        private readonly ICalculator _calculator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calculator"></param>
        public TimeLapseDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Calculate 
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        public IList<long> Calculate(long numberA, long numberB)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.Write(">");
            var output = _calculator.Calculate(numberA, numberB);
            stopWatch.Stop();
            Console.WriteLine("> {0:n0} ms", stopWatch.Elapsed.TotalMilliseconds);
            return output;
        }

        public override string ToString()
        {
            return _calculator.ToString();
        }
    }
}