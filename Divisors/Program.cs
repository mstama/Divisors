using Divisors.Interfaces;
using Divisors.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Divisors
{
    internal static class Program
    {
        private static readonly IList<ICalculator> _calculators = new List<ICalculator>();

        static Program()
        {
            _calculators.Add(new TimeLapseDecorator(new ProgressConsoleDecorator(new TimeoutDecorator(new Brute()))));
            _calculators.Add(new TimeLapseDecorator(new ProgressConsoleDecorator(new TimeoutDecorator(new BruteSqrt()))));
            _calculators.Add(new TimeLapseDecorator(new ProgressConsoleDecorator(new TimeoutDecorator(new CommonDivisor()))));
        }

        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Input file required!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist!");
                return;
            }
            Console.WriteLine("Processing file {0}.", args[0]);
            var _parser = new NumbersParser();
            foreach (var line in File.ReadLines(filePath))
            {
                var numbers = _parser.Parse(line);
                Console.WriteLine("A:{0:n0} B:{1:n0}", numbers[0], numbers[1]);
                foreach (var calculator in _calculators)
                {
                    var result = calculator.Calculate(numbers[0], numbers[1]);
                    Console.WriteLine("{0} - {1} numbers", calculator, result.Count);
                }
            }
            Console.WriteLine("Finished");
        }
    }
}