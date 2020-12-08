using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result1 = 0;
            int result2 = 0;

            Utils.StartDay(8);
            Utils.StartPart(1);

            //var lines = Utils.ReadInputAsLines("input-sample.txt");
            var lines = Utils.ReadInputAsLines("input.txt");

            var p = new Prg(lines);            
            
            Utils.EndPart(1, p.Execute());

            Utils.StartPart(2);

            p.Output = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var lines2 = (string[])lines.Clone();
                if (lines2[i].StartsWith("jmp"))
                {
                    lines2[i] = lines2[i].Replace("jmp", "nop");
                    p.Read(lines2);
                    if (p.Execute() == 0)
                    {
                        Console.WriteLine($"Line {i}: jmp -> nop, acc = {p.Acc}");
                        p.Output = false;
                        p.Execute();
                    }
                }
                else if (lines2[i].StartsWith("nop"))
                {
                    lines2[i].Replace("nop", "jmp");
                    p.Read(lines2);
                    if (p.Execute() == 0)
                    {
                        Console.WriteLine($"Line {i + 1}: nop -> jmp, acc = {p.Acc}");
                        p.Output = false;
                        p.Execute();
                    }
                }
            }

            Utils.EndPart(2, result2);

            //Utils.Wait();
        }
        
    }
}
