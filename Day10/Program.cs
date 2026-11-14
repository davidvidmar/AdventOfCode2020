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

            Utils.StartDay(10);
            Utils.StartPart(1);

            // solved in Excel            

            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            var l = Utils.ReadInputAsLongLines().ToList();
            l.Add(0);
            l.Add(l.Max() + 3);
            l.Sort();

            var total = new List<long>() { 1, 1 };

            for (int i = 2; i < l.Count; i++)
            {
                var next = l.ElementAt(i);
                int start = i > 3 ? i - 3 : 0; 
                var part = l.GetRange(start, i - start);

                int count = part.Count(e => e > next - 3);
                total.Add(total.TakeLast(count).Sum());
            }

            result2 = total.Last();

            Utils.EndPart(2, result2);
        }

    }
}