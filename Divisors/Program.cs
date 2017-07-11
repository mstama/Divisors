using Divisors.Services;
using System;

namespace Divisors
{
    internal static class Program
    {
        private static readonly char[] _separators = { ' ' };
        static void Main(string[] args)
        {
            Console.WriteLine("Input numbers:");
            var input = Console.ReadLine();
            var values = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var numberA = long.Parse(values[0]);
            var numberB = long.Parse(values[1]);
            Console.WriteLine("Calculating for {0} and {1}...", numberA, numberB);
            var brute = new Brute();
            var output = brute.Calculate(numberA, numberB);
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}