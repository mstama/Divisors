// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;

namespace Divisors.Exceptions
{
    /// <summary>
    /// Divisor application exception
    /// </summary>
    public class DivisorsException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DivisorsException() : base("Divisors Error") { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error description</param>
        public DivisorsException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Error description</param>
        /// <param name="innerException">Inner exception</param>
        public DivisorsException(string message, Exception innerException) : base(message, innerException) { }
    }
}