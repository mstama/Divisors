using System;
using System.Collections.Generic;
using System.Text;

namespace Divisors.Services
{
    /// <summary>
    /// Null progress
    /// </summary>
    public class ProgressEmpty : IProgress<double>
    {
        /// <summary>
        /// Update progress
        /// </summary>
        /// <param name="value"></param>
        public void Report(double value)
        {
            // Empty pattern
        }
    }
}
