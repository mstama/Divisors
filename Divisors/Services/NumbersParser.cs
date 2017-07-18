using System;

namespace Divisors.Services
{
    /// <summary>
    /// Parse text service
    /// </summary>
    public class NumbersParser
    {
        private static readonly char[] _separators = { ' ' };

        /// <summary>
        /// Parse the text to find 2 numbers
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Numbers found</returns>
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