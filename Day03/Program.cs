using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result1 = 0;
            long result2 = 0;

            Utils.StartDay(3);

            // part 1
            Utils.StartPart(1);

            // sample
            var linesSample = Utils.ReadInputAsLines("input-sample.txt");
            var result1Sample = RideThroghForest(linesSample, 3, 1);

            Console.WriteLine("Sample = " + result1Sample);

            var lines = Utils.ReadInputAsLines();
            result1 = RideThroghForest(lines, 3, 1);

            Utils.EndPart(1, result1);

            // part 2
            var slopes = new[]
            {
                new [] { 1, 1 },
                new [] { 3, 1 },
                new [] { 5, 1 },
                new [] { 7, 1 },
                new [] { 1, 2 },
            };

            // sample
            var result2Sample = 1;
            foreach (var slope in slopes)
            {
                var r = RideThroghForest(linesSample, slope[0], slope[1]);                
                Console.WriteLine($"{slope[0]}, {slope[1]} = {r}");
                result2Sample *= r;
            }
            Console.WriteLine("Sample = " + result2Sample);

            // part 2
            Utils.StartPart(2);

            result2 = 1;
            foreach (var slope in slopes)
            {
                var r = RideThroghForest(lines, slope[0], slope[1]);
                Console.WriteLine($"{slope[0]}, {slope[1]} = {r}");
                result2 *= r;
            }

            Utils.EndPart(2, result2);

            Utils.Wait();
        }

        private static int RideThroghForest(string[] lines, int x, int y)
        {
            var height = 0;
            var width = 0;
            var trees = 0;

            while (height < lines.Length)
            {
                if (lines[height][width] == '#')
                    trees++;
                height += y;
                width += x;
                while (width >= lines[0].Length)
                    width -= lines[0].Length;
            }

            return trees;
        }
    }
}