using Divisors.Exceptions;
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
        private static readonly ProgressConsole _progress;
        static Program()
        {
            _progress = new ProgressConsole();
            _calculators.Add(new TimeoutDecorator(new TimeLapseDecorator(new Brute(_progress))));
            _calculators.Add(new TimeoutDecorator(new TimeLapseDecorator(new BruteSqrt(_progress))));
            _calculators.Add(new TimeoutDecorator(new TimeLapseDecorator(new CommonDivisor(_progress))));
        }

        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Input file required!");
                return;
            }
            string filePath = args[0];
            if (!File.Exists(filePath)) { Console.WriteLine("File does not exist!"); }
            Console.WriteLine("Processing file {0}.", args[0]);
            var _parser = new NumbersParser();
            foreach (var line in File.ReadLines(filePath))
            {
                var numbers = _parser.Parse(line);
                Console.WriteLine("A:{0:n0} B:{1:n0}", numbers[0], numbers[1]);
                foreach (var calculator in _calculators)
                {
                    try
                    {
                        var result = calculator.Calculate(numbers[0], numbers[1]);
                        Console.WriteLine("{0} - {1} numbers", calculator, result.Count);
                    }
                    catch (AggregateException ex)
                    {
                        ex.Handle(e =>
                        {
                            if (e is DivisorsException)
                            {
                                _progress.Report(1);
                                Console.Write("Timeout occured.");
                            }
                            return e is DivisorsException;
                        });
                    }
                }
            }
            Console.WriteLine("Finished");
            _progress.Dispose();
            Console.ReadLine();
        }
    }
}