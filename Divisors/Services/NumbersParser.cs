using System;
using System.Collections.Generic;
using System.Text;

namespace Divisors.Services
{
    public class NumbersParser
    {
        private static readonly char[] _separators = { ' ' };

        public long[] Parse(string text)
        {
            var numbers = new long[2];
            var values = text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            numbers[0] = long.Parse(values[0]);
            numbers[1] = long.Parse(values[1]);
            return numbers;
        }
    }
}
