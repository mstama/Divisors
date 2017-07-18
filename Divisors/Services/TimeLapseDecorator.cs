using Divisors.Interfaces;
using System;
using System.Diagnostics;

namespace Divisors.Services
{
    /// <summary>
    /// Print time used in execution
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TimeLapseDecorator<T> : IDecorator<T>
    {
        public T Run(Func<T> calculate)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.Write(">");
            var output = calculate.Invoke();
            stopWatch.Stop();
            Console.WriteLine("> {0:n0} ms", stopWatch.Elapsed.TotalMilliseconds);
            return output;
        }
    }
}