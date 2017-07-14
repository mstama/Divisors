using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Divisors.Services
{
    public class TimeLapseDecorator<T>
    {
        public static T Run(Func<T> calculate)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("Starting calculation...");
            var output = calculate.Invoke();
            stopWatch.Stop();
            Console.WriteLine("Stopped in {0:n0} ms", stopWatch.Elapsed.TotalMilliseconds);
            return output;
        }
    }
}
