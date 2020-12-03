using System;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result = 0;

            Utils.StartDay(1);

            // part 1
            Utils.StartPart(1);

            var input = Utils.ReadInputAsLines();
            
            foreach (var line in input)
            {
                int policyMin, policyMax;
                char policyLetter;
                string password;

                (policyMin, policyMax, policyLetter, password) = SplitInput(line);

                if (CheckPassword(policyMin, policyMax, policyLetter, password))
                    result++;

            }

            Utils.EndPart(1, result);

            // part 2

            

            var input2 = new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            foreach (var line in input2)
            {
                int policyMin, policyMax;
                char policyLetter;
                string password;

                (policyMin, policyMax, policyLetter, password) = SplitInput(line);

                if (CheckPassword2(policyMin, policyMax, policyLetter, password))
                    Console.WriteLine(password);
                    result++;
            }

            Utils.StartPart(2);
            
            result = 0;
            foreach (var line in input)
            {
                int policyMin, policyMax;
                char policyLetter;
                string password;

                (policyMin, policyMax, policyLetter, password) = SplitInput(line);

                if (CheckPassword2(policyMin, policyMax, policyLetter, password))
                    result++;

            }

            Utils.EndPart(2, result);

            Utils.Wait();
        }

        private static bool CheckPassword(int policyMin, int policyMax, char policyLetter, string password)
        {
            var count = CountLetter(policyLetter, password);
            return count >= policyMin && count <= policyMax;
        }

        private static bool CheckPassword2(int policyMin, int policyMax, char policyLetter, string password)
        {
            var a = password[policyMin - 1] == policyLetter;
            var b = password[policyMax - 1] == policyLetter;
            return a ^ b;
        }

        private static (int, int, char, string) SplitInput(string input)
        {
            var split1 = input.Split(':');
            var split2 = split1[0].Split(' ');
            var split3 = split2[0].Split('-');

            var policyMin = Convert.ToInt32(split3[0]);
            var policyMax = Convert.ToInt32(split3[1]);
            var policyLetter = split2[1][0];
            var password = split1[1].Trim();

            return (policyMin, policyMax, policyLetter, password);
        }

        private static int CountLetter(char c, string s)
        {
            return s.Count(t => t == c);
        }
    }
}