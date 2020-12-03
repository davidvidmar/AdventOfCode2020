using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class Utils
    {
        static readonly Stopwatch[] watches = { new Stopwatch(), new Stopwatch() };

        public static void StartDay(int day)
        {
            Console.WriteLine($"Advent of Code 2020 - Day {day}");
        }

        public static void StartPart(int part)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nPart {part}\n");
            Console.ResetColor();

            watches[part - 1].Start();
        }

        public static void EndPart(int part, long value)
        {
            EndPart(part, value.ToString());
        }

        public static void EndPart(int part, string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nResult  = {value}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Elapsed = {watches[part-1].Elapsed}\n");
            Console.ResetColor();
        }

        public static void Wait()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key...");
            Console.ResetColor();
            Console.ReadKey();        
        }

        public static string[] ReadInputAsLines(string filename = "input.txt")
        {
            return File.ReadAllLines(filename);            
        }

        public static IEnumerable<Int32> ReadInputAsIntLines(string filename = "input.txt")
        {
            return from q in File.ReadAllLines(filename) select Convert.ToInt32(q);
        }

        public static IEnumerable<Int32> ReadInputAsIntArray(string filename = "input.txt")
        {
            var inputFile = File.ReadAllText(filename);
            return from q in inputFile.Split(',') select Convert.ToInt32(q);
        }
            public static IEnumerable<string[]> ReadInputAsStringArrays(string filename = "input.txt")
        {
            return from q in File.ReadAllLines(filename) select q.Split(',');
        }
    }
}
