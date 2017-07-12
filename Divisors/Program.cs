using Divisors.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Divisors
{
    internal static class Program
    {
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
            var brute = new Brute();
            foreach (var line in File.ReadLines(filePath))
            {
                var numbers = _parser.Parse(line);
                Console.WriteLine("A:{0:n0} B:{1:n0}", numbers[0], numbers[1]);
                var result = TimeLapseDecorator<IList<long>>.Run(() => brute.Calculate(numbers[0], numbers[1]));
                Console.WriteLine("{0} numbers", result.Count);
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}