using Divisors.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Divisors.Services
{
    public class TimeoutDecorator<T>
    {
        public static T Run(Func<T> calculate)
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
