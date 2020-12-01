using System;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result;

            Utils.StartDay(1);

            // part 1
            Utils.StartPart(1);

            var input = Utils.ReadInputAsIntLines().ToArray();

            int first = 0;
            int second = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        first = input[i];
                        second = input[j];
                        continue;
                    }
                }
            }

            if (first == 0 || second == 0)
            {
                Console.WriteLine("Hm...");
                return;
            }
            result = first * second;

            Utils.EndPart(1, result);

            // part 2

            Utils.StartPart(2);

            int third = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    for (int k = j + 1; k < input.Length; k++)
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            first = input[i];
                            second = input[j];
                            third = input[k];
                            continue;
                        }
                }
            }

            if (first == 0 || second == 0 || third == 0)
            {
                Console.WriteLine("Hm...");
                return;
            }
            result = first * second * third;

            //

            Utils.EndPart(2, result);

            Utils.Wait();
        }

    }
}