// Copyright (c) 2017 Marcos Tamashiro. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

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
