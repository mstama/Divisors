using Divisors.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Divisors.Services
{
    public abstract class AbstractCalculator : ICalculator
    {
        private readonly IProgress<double> _emptyProgress = new ProgressEmpty();

        public virtual IList<long> Calculate(long numberA, long numberB)
        {
            return Calculate(numberA, numberB, _emptyProgress);
        }

        public abstract IList<long> Calculate(long numberA, long numberB, IProgress<double> progress);
    }
}
