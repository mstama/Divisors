using Divisors.Exceptions;
using Divisors.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Divisors.Services
{
    /// <summary>
    /// Provide timeout controle to a sync method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TimeoutDecorator:ICalculator
    {
        private readonly ICalculator _calculator;

        public TimeoutDecorator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public IList<long> Calculate(long numberA, long numberB)
        {
            var cts = new CancellationTokenSource();

            var inner = Task.Run<IList<long>>(()=>_calculator.Calculate(numberA,numberB), cts.Token);
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