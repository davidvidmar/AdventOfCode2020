using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            long result1 = 0;
            long result2 = 0;

            Utils.StartDay(9);
            Utils.StartPart(1);

            //var lines = Utils.ReadInputAsLongLines("input-sample.txt");
            //result1 = CheckNumbers(5, lines.ToList());

            var lines = Utils.ReadInputAsLongLines();
            result1 = CheckNumbers(25, lines.ToList());

            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            var (x, y) = FindWeakness(lines.ToList(), result1);

            Console.WriteLine($"{x}, {y}");
            result2 = x + y;

            Utils.EndPart(2, result2);
        }

        private static long CheckNumbers(int frameLen, List<long> nums)
        {
            int i = frameLen;
            var fail = false;
            while (!fail && i < nums.Count)
            {
                var num = nums[i];
                var j = i - frameLen;
                if (!FindPair(nums.GetRange(j, frameLen), num)) return num;
                i++;

            }
            return 0;
        }

        private static bool FindPair(List<long> range, long num)
        {
            //Console.WriteLine($"{string.Join(",", range)} => {num}");
            for (int i = 0; i < range.Count - 1; i++)
            {
                for (int j = 0; j < range.Count; j++)
                {
                    if (range[i] + range[j] == num)
                        return true;
                }
            }
            return false;
        }

        private static (long, long) FindWeakness(List<long> range, long num)
        {
            for (int i = 0; i < range.Count; i++)
            {
                long sum = 0;
                for (int j = 0; j < range.Count - i; j++)
                {
                    sum += range[i+j];
                    if (num == sum)
                        return (range.GetRange(i, j).Min(), range.GetRange(i, j).Max());
                }
            }
            return (0, 0);
        }
    }
}