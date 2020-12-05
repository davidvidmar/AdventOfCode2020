using Day04;
using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main()
        {
            int result1 = 0;
            int result2 = 0;
            int count = 0;
            
            Utils.StartDay(4);
            Utils.StartPart(1);

            var linesSample = Utils.ReadInputAsLines("input-sample.txt");
            count = CountValidPassports(linesSample);
            Console.WriteLine("Sample: " + count);

            var lines = Utils.ReadInputAsLines();
            result1 = CountValidPassports(lines);
            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            linesSample = Utils.ReadInputAsLines("input-sample2-valid.txt");
            count = CountValidPassports(linesSample, false);
            Console.WriteLine("Sample 2 - Valid: " + count);

            linesSample = Utils.ReadInputAsLines("input-sample2-invalid.txt");
            count = CountValidPassports(linesSample, false);
            Console.WriteLine("Sample 2 - Invalid: " + count);

            result2 = CountValidPassports(lines, false);

            Utils.EndPart(2, result2);

            Utils.Wait();
        }

        private static int CountValidPassports(string[] lines, bool simple = true)
        {
            var count = 0;
            var passport = new Passport();
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    if (passport.IsValid(simple)) count++;
                    passport = new Passport();
                    continue;
                }
                var fields = line.Split(' ');
                foreach (var field in fields)
                {
                    var kv = field.Split(':');
                    switch (kv[0])
                    {
                        case "byr": passport.BirthYear = Convert.ToInt32(kv[1]); break;
                        case "iyr": passport.IssueYear = Convert.ToInt32(kv[1]); break;
                        case "eyr": passport.ExpirationYear = Convert.ToInt32(kv[1]); break;
                        case "hgt": passport.Height = kv[1]; break;
                        case "hcl": passport.HairColor = kv[1]; break;
                        case "ecl": passport.EyeColor = kv[1]; break;
                        case "pid": passport.PassportID = kv[1]; break;
                        case "cid": passport.CountryID = kv[1]; break;
                        default:
                            throw new Exception($"Invalid key: {kv}!");
                    }
                }
            }
            if (passport.IsValid(simple)) count++;
            return count;
        }
    }
}