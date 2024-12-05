using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024
{
 internal class _2024d5p1
 {
     public static void Run()
     {
         string input = File.ReadAllText("input.txt");

         string[] blocks = input.Split(new string[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
         var tmpRules = blocks[0].Split('\n');
         var tmpUpdates = blocks[1].Split('\n');

         List<List<int>> updates = new();
         List<(int, int)> rules = new();

         int total = 0;

         foreach (var rule in tmpRules)
         {
             var tmpr = rule.Split('|');
             rules.Add((int.Parse(tmpr[0]), int.Parse(tmpr[1])));
         }
         foreach (var line in tmpUpdates)
         {
             var updateLine = line.Split(',').Select(int.Parse).ToList();
             updates.Add(updateLine);
         }

         foreach (var update in updates)
         {
             if (IsValidUpdate(update, rules))
             {
                 total += middleNum(update);
             }
         }

         Console.WriteLine(total);

     }

     private static int middleNum(List<int> updates)
     {
         return updates[updates.Count / 2];
     }

     private static bool IsValidUpdate(List<int> update, List<(int X, int Y)> rules)
     {

         Dictionary<int, int> postions = new Dictionary<int, int>();
         for (int i = 0; i < update.Count; i++)
         {
             postions.Add(update[i], i);
         }

         foreach (var rule in rules)
         {
             if (postions.ContainsKey(rule.X) && postions.ContainsKey(rule.Y))
             {
                 if (postions[rule.X] > postions[rule.Y])
                 {
                     return false;
                 }
             }
             Console.WriteLine(rule);
         }
         return true;
     }
 }
}
