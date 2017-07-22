using Divisors.Exceptions;
using Divisors.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Divisors.Services
{
    /// <summary>
    /// Print time used in execution
    /// </summary>
    public class TimeLapseDecorator : AbstractCalculator
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
        /// Calculate providing elapsed time info
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public override IList<long> Calculate(long numberA, long numberB, IProgress<double> progress)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.Write(">");
            bool timeout = false;
            IList<long> output = null;
            try
            {
                output = _calculator.Calculate(numberA, numberB, progress);
            }
            catch (AggregateException ex)
            {
                ex.Handle(e =>
                {
                    if (e is DivisorsException)
                    {
                        timeout = true;
                        output = new List<long>();
                    }
                    return e is DivisorsException;
                });
            }
            stopWatch.Stop();
            Console.Write("> {0:n0} ms{1} ", stopWatch.Elapsed.TotalMilliseconds, timeout ? " TIMEOUT" : string.Empty);
            return output;
        }

        public override string ToString()
        {
            return _calculator.ToString();
        }
    }
}