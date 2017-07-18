using System;
using System.Collections.Generic;
using System.Text;

namespace Divisors.Interfaces
{
    /// <summary>
    /// Decorator interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDecorator<T>
    {
        /// <summary>
        /// Execute the method to decorate
        /// </summary>
        /// <param name="calculate"></param>
        /// <returns></returns>
        T Run(Func<T> calculate);
    }
}
