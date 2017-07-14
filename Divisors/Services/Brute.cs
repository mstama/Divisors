using System;
using System.Collections.Generic;

namespace Divisors.Services
{
    public class Brute
    {
        private readonly IProgress<double> _progress;

        public Brute(IProgress<double> progress)
        {
            _progress = progress;
        }

        public IList<long> Calculate(long numberA, long numberB)
        {
            var output = new List<long>
            {
                1
            };
            // restart report
            _progress.Report(0);
            long limit = numberA > numberB ? numberB : numberA;
            for (long i = 2; i <= limit; i++)
            {
                _progress.Report((double)i / limit);
                if (numberA % i == 0 && numberB % i == 0)
                {
                    output.Add(i);
                }
            }
            return output;
        }
    }
}