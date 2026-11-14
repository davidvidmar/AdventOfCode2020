using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result1 = 0;
            int result2 = 0;

            Utils.StartDay(11);
            Utils.StartPart(1);

            var lines = Utils.ReadInputAsLines("input.txt");

            var floor = lines.Select(l => l.ToArray()).ToArray();

            var round = 0;
            var end = false;
            while (!end)
            {                
                //Visualize(floor);
                //Console.WriteLine(round);
                //Console.ReadKey();

                round++;
                var newFloor = Process(floor, lines.Select(l => l.ToArray()).ToArray());
                
                end = Equal(floor, newFloor);
                floor = newFloor;                
            }
            //Visualize(floor);
            Console.WriteLine(round + ". Stable.");

            result1 = CountChars(floor, '#');

            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            // ...

            Utils.EndPart(2, result2);
        }

        private static bool Equal(char[][] floor, char[][] newFloor)
        {
            var e = true;
            for (int row = 0; row < floor.Length; row++)
            {
                e &= new string(floor[row]) == new string(newFloor[row]);
            }
            return e;
        }

        private static int CountChars(char[][] floor, char c)
        {
            var r = 0;
            for (int row = 0; row < floor.Length; row++)
            {
                r += floor[row].Count(f => f == c);
            }
            return r;
        }

        private static char[][] Process(char[][] floor, char[][] empty)
        {
            var newFloor = empty;
            for (int row = 0; row < floor.Length; row++)
            {
                for (int col = 0; col < floor[row].Length; col++)
                {
                    if (floor[row][col] == 'L' && CountChairs(floor, row, col, '#') == 0) newFloor[row][col] = '#';
                    else if (floor[row][col] == '#')
                    {
                        int count = CountChairs(floor, row, col, '#');

                        if (count < 4) newFloor[row][col] = '#';
                    }
                }
            }
            return newFloor;
        }

        private static int CountChairs(char[][] floor, int row, int col, char c)
        {
            var count = 0;

            count += IsSeat(row + 1, col, floor, c);
            count += IsSeat(row + 1, col + 1, floor, c);
            count += IsSeat(row, col + 1, floor, c);
            count += IsSeat(row - 1, col + 1, floor, c);
            count += IsSeat(row - 1, col, floor, c);
            count += IsSeat(row - 1, col - 1, floor, c);
            count += IsSeat(row, col - 1, floor, c);
            count += IsSeat(row + 1, col - 1, floor, c);
            return count;
        }

        private static int IsSeat(int row, int col, char[][] floor, char v)
        {
            if (row < 0 || col < 0 || row >= floor.Length || col >= floor[0].Length) return 0;
            return floor[row][col] == v ? 1 : 0;            
        }

        private static void Visualize(char[][] floor)
        {
            Console.Clear();
            for (int i = 0; i < floor.Length; i++)
                Console.WriteLine(floor[i]);
        }
    }
}
