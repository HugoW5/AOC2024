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
			string input = @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";
			string[] blocks = input.Split(new string[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

			// Output each block
			for (int i = 0; i < blocks.Length; i++)
			{
				Console.WriteLine($"Block {i + 1}:\n{blocks[i].Trim()}\n");
			}
		}
	}
}
