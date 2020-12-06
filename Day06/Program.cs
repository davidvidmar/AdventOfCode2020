using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result1 = 0;
            int result2 = 0;

            Utils.StartDay(6);
            Utils.StartPart(1);
            
            var lines = Utils.ReadInputAsLines("input.txt");
            char[] answers = InitializeAnswers();
            foreach (var line in lines)
            {
                foreach (var c in line)
                {
                    answers[c-97] = c;
                }
                if (line.Trim().Length == 0)
                {
                    // rezultatu prištej št. unikatnih črk
                    //Console.WriteLine(new String(answers));
                    result1 += CountAnswer(answers);
                    answers = InitializeAnswers();
                }
            }
            // rezultatu prištej št. unikatnih črk
            //Console.WriteLine(new String(answers));
            result1 += CountAnswer(answers);

            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            answers = InitializeAnswers();
            foreach (var line in lines)
            {                
                if (line.Trim().Length == 0)
                {
                    // rezultatu prištej št. unikatnih črk
                    //Console.WriteLine(new String(answers));
                    result2 += CountAnswer(answers);
                    answers = InitializeAnswers();
                } 
                else             
                {
                    for (int i = 0; i < answers.Length; i++)
                    {
                        answers[i] = line.Contains((char)(97 + i)) && answers[i] != 'X' ? (char)(97 + i) : 'X';
                    }
                }
            }
            // rezultatu prištej št. unikatnih črk
            //Console.WriteLine(new String(answers));
            result2 += CountAnswer(answers);

            Utils.EndPart(2, result2);

            Utils.Wait();
        }

        private static char[] InitializeAnswers()
        {
            return "".PadRight(27, '.').ToCharArray();
        }

        private static int CountAnswer(char[] answer)
        {
            var result = 0;
            foreach (char c in answer)
            {
                if (c != '.' && c != 'X') result++;
            }
            return result;
        }
    }
}
