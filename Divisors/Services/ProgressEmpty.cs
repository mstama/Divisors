using System;
using System.Collections.Generic;
using System.Text;

namespace Divisors.Services
{
    public class ProgressEmpty : IProgress<double>
    {
        public void Report(double value)
        {
            // Empty pattern
        }
    }
}
