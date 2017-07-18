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
        
        static Program()
        {
            var progress = new ProgressConsole() ;
            _calculators.Add(new Brute(progress));
            _calculators.Add(new BruteSqrt(progress));
            _calculators.Add(new CommonDivisor(progress));
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
            using (var progress = new ProgressConsole())
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var brute = new Brute(progress);
                    var numbers = _parser.Parse(line);
                    Console.WriteLine("A:{0:n0} B:{1:n0}", numbers[0], numbers[1]);
                    try
                    {
                        //var result = TimeoutDecorator<IList<long>>.Run(() => TimeLapseDecorator<IList<long>>.Run(() => brute.Calculate(numbers[0], numbers[1])));
                        //Console.WriteLine("{0} numbers", result.Count);
                    }
                    catch (AggregateException ex)
                    {
                        ex.Handle(e => {
                            if (e is DivisorsException)
                            {
                                Console.Write("Timeout occured.");
                            }
                            return e is DivisorsException;
                                });
                    }
                }

                Console.WriteLine("==============================");

                foreach (var line in File.ReadLines(filePath))
                {
                    var bruteSqrt = new BruteSqrt(progress);
                    var numbers = _parser.Parse(line);
                    Console.WriteLine("A:{0:n0} B:{1:n0}", numbers[0], numbers[1]);
                    //var result = TimeLapseDecorator<IList<long>>.Run(() => bruteSqrt.Calculate(numbers[0], numbers[1]));
                    //Console.WriteLine("{0} numbers", result.Count);
                }

                Console.WriteLine("==============================");

                foreach (var line in File.ReadLines(filePath))
                {
                    var commonDivisor = new CommonDivisor(progress);
                    var numbers = _parser.Parse(line);
                    Console.WriteLine("A:{0:n0} B:{1:n0}", numbers[0], numbers[1]);
                    //var result = TimeLapseDecorator<IList<long>>.Run(() => commonDivisor.Calculate(numbers[0], numbers[1]));
                    //Console.WriteLine("{0} numbers", result.Count);
                }
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}