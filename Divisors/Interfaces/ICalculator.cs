using System.Collections.Generic;

namespace Divisors.Interfaces
{
    /// <summary>
    /// Calculator interface
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Do the math!
        /// </summary>
        /// <param name="numberA"></param>
        /// <param name="numberB"></param>
        /// <returns></returns>
        IList<long> Calculate(long numberA, long numberB);
    }
}