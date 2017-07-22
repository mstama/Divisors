using Divisors.Exceptions;
using Divisors.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Divisors.Services
{
    /// <summary>
    /// Provide timeout controle to a sync method
    /// </summary>
    public class TimeoutDecorator : AbstractCalculator
    {
        private readonly ICalculator _calculator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calculator"></param>
        public TimeoutDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Provides calculation with timeout
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public override IList<long> Calculate(long numberA, long numberB, IProgress<double> progress)
        {
            var cts = new CancellationTokenSource();

            var inner = Task.Run<IList<long>>(() => _calculator.Calculate(numberA, numberB, progress), cts.Token);
            var delay = Task.Delay(TimeSpan.FromSeconds(5), cts.Token);
            Task.WhenAny(inner, delay).ContinueWith(
                t =>
                {
                    try
                    {
                        if (!inner.IsCompleted)
                        {
                            cts.Cancel();
                            throw new DivisorsException("Timeout waiting for method after 1 min.");
                        }
                    }
                    finally
                    {
                        cts.Dispose();
                    }
                }, cts.Token

                ).Wait();
            return inner.Result;
        }

        public override string ToString()
        {
            return _calculator.ToString();
        }
    }
}