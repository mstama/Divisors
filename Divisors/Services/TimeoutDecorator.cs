using Divisors.Exceptions;
using Divisors.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Divisors.Services
{
    /// <summary>
    /// Provide timeout controle to a sync method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TimeoutDecorator<T> : IDecorator<T>
    {
        public T Run(Func<T> calculate)
        {
            var cts = new CancellationTokenSource();

            var inner = Task.Run<T>(calculate, cts.Token);
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
    }
}