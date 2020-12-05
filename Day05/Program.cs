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

            Utils.StartDay(5);
            Utils.StartPart(1);

            Console.WriteLine(ParseBoardingPass("FBFBBFFRLR"));

            Console.WriteLine(ParseBoardingPass("BFFFBBFRRR"));
            Console.WriteLine(ParseBoardingPass("FFFBBBFRRR"));
            Console.WriteLine(ParseBoardingPass("BBFFBBFRLL"));
            
            var lines = Utils.ReadInputAsLines();
            foreach (var line in lines)
            {
                var r = ParseBoardingPass(line);
                if (r > result1) result1 = r;
            }            

            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            var seats = "".PadLeft(127*8, '.').ToCharArray();            
            foreach (var line in lines)
            {
                var r = ParseBoardingPass(line);
                seats[r] = 'X';
            }
            for (int i = 0; i < 127; i++)
            {
                Console.WriteLine(seats[(i * 8)..(i * 8 + 7)]);            
            }

            var s = new string(seats);
            result2 = s[s.IndexOf('X')..].IndexOf('.') + s.IndexOf('X');                

            Utils.EndPart(2, result2);

            Utils.Wait();
        }

        private static int ParseBoardingPass(string pass)
        {
            int low = 0;
            int high = 127;

            int left = 0;
            int right = 7;

            for (int i = 0; i < 7; i++)
            {
                if (pass[i] == 'F') high = low + (high - low + 1) / 2 - 1;
                if (pass[i] == 'B') low = low + (high - low + 1) / 2;

                //Console.WriteLine($"{i:D2}={pass[i]} => L: {low} H:{high}");
            }
            for (int j = 7; j < 10; j++)
            {
                
                
                if (pass[j] == 'L') right = left + (right - left + 1) / 2 - 1;
                if (pass[j] == 'R') left = left + (right - left + 1) / 2;

                //Console.WriteLine($"{j:D2}={pass[j]} => L: {left} H:{right}");
            }
            return low * 8 + left;
        }
    }
}
