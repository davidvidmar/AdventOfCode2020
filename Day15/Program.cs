using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {        

        static void Main()
        {
            int result1 = 0;
            long result2 = 0;

            Utils.StartDay(15);
            Utils.StartPart(1);

            //var input = new List<int>(new[] { 0, 3, 6 });
            var input = new List<int>(new[] { 20, 9, 11, 0, 1, 2 });

            for (int i = input.Count; i < 2020; i++)
            {
                var last = input[i - 1];
                if (input.GetRange(0, i - 1).LastIndexOf(last) == -1)
                {
                    input.Add(0);
                    //Console.WriteLine($"Turn {i + 1}: 0");
                }
                else
                {
                    var lastSpoken = input.LastIndexOf(last);
                    var prevSpoken = input.GetRange(0, lastSpoken).LastIndexOf(last);
                    input.Add(lastSpoken - prevSpoken);
                    //Console.WriteLine($"Turn {i + 1}: {input[i]} = {lastSpoken + 1} - {prevSpoken + 1}");
                }
            }

            result1 = input.Last();
            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            var input2 = new List<int>(new[] { 20, 9, 11, 0, 1, 2 });

            var list = new List<int>[30000000];

            var num = 0;
            int x = 0;
            foreach (var item in input2)
            {
                AddToList(list, x, item);
                num = item;
                x++;
            }

            for (int i = input2.Count; i < list.Length; i++)
            {
                if (list[num].Count > 1)
                {
                    num = list[num][^1] - list[num][^2];
                }                
                else
                {
                    num = 0;
                }
                AddToList(list, i, num);                
                if (i % 100000 == 0)
                {
                    Console.CursorLeft = 0;
                    Console.Write(i.ToString());
                }
            }
            Console.CursorLeft = 0;
            result2 = num;

            Utils.EndPart(2, result2);
        }

        private static void AddToList(List<int>[] list, int x, int item)
        {
            if (list[item] == null) { list[item] = new List<int>(); };
            list[item].Add(x);
        }
    }


}
