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
            int result2 = 0;

            Utils.StartDay(7);
            Utils.StartPart(1);

            //var lines = Utils.ReadInputAsLines("input-sample.txt");
            var lines = Utils.ReadInputAsLines("input.txt");
            var rules = ParseRules(lines);

            PrintRules(rules);

            var i = 0;
            var color = "shiny gold";
            foreach (var rule in rules)
            {
                if (CanHoldBag(rule, color, rules)) i++;                
            }
            result1 = i;                     

            Utils.EndPart(1, result1);

            Utils.StartPart(2);
            
            result2 = CountBags(color, rules);
            
            //var liness2 = Utils.ReadInputAsLines("input-sample2.txt");
            //var ruless2 = ParseRules(liness2);
            //result2 = CountBags(color, ruless2);

            Utils.EndPart(2, result2);

            Utils.Wait();
        }

        private static bool CanHoldBag(KeyValuePair<string, string[]> rule, string color, RulesType rules)
        {
            if (rule.Value == null) return false;
            if (rule.Value.Any(bags => bags.Contains(color)))
                return true;
            foreach (var bag in rule.Value)
            {
                if (bag == "") continue;
                var bagColor = bag[bag.IndexOf(" ")..].Trim();
                if (CanHoldBag(rules.FirstOrDefault(r => r.Key == bagColor), color, rules))
                    return true;
            }
            return false;
        }

        private static int CountBags(string color, RulesType rules)
        {
            var r = 0;
            var rule = rules.Single(r => r.Key == color);
            foreach (var bag in rule.Value)
            {
                if (bag == "") continue;                
                var bagCount = Convert.ToInt32(bag[..bag.IndexOf(" ")]);                
                var bagColor = bag[bag.IndexOf(" ")..].Trim();
                Console.WriteLine($"{bagCount} x {bagColor}");
                r += bagCount + bagCount * CountBags(bagColor, rules);            
            }
            return r;
        }

        private static RulesType ParseRules(string[] lines)
        {
            var rules = new RulesType();
            foreach (var line in lines)
            {
                var kv = line.Split(new string[] { "bags contain" }, StringSplitOptions.None);
                var key = kv[0].Trim();
                var value = kv[1].Replace(" bags", "").Replace(" bag", "").Replace("no other", "").Replace(", ", ",").Replace(".", "").Trim();

                var values = value.Split(",");
                rules.Add(new KeyValuePair<string, string[]>(key, values));
            }
            return rules;
        }

        private static void PrintRules(RulesType rules)
        {
            foreach (var rule in rules)
            {
                Console.WriteLine($"{rule.Key.PadLeft(20)} => {string.Join('|', rule.Value)}");
            }
        }
    }

    class RulesType : List<KeyValuePair<string, string[]>>
    {

    }
}