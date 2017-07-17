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
            Console.Write(">");
            var output = calculate.Invoke();
            stopWatch.Stop();
            Console.WriteLine("> {0:n0} ms", stopWatch.Elapsed.TotalMilliseconds);
            return output;
        }
    }
}
