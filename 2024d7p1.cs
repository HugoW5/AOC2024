using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AOC2024
{
	internal class _2024d7p1
	{
		public static void Run()
		{
			string input = File.ReadAllText("input.txt");
/*			string input = @"
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20
";*/

			List<(long answer, List<long> equation)> equations = new();

			foreach (string line in input.Split('\n'))
			{
				if (!string.IsNullOrWhiteSpace(line))
				{
					string[] row = line.Split(':');
					long answer = long.Parse(row[0].Trim());
					List<long> equationParts = row[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
					equations.Add((answer, equationParts));
				}
			}

			long total = 0;
			foreach (var equation in equations)
			{
				if(CheckEquation(equation.answer, equation.equation))
				{
					total += equation.answer;
				}
			}
            Console.WriteLine(total);

		}

		private static bool CheckEquation(long answer, List<long> numbers)
		{
			long combinations = (long)Math.Pow(2, numbers.Count - 1);
			for (int i = 0; i < combinations; i++)
			{
				long result = numbers[0];
				for (int j = 0; j < numbers.Count - 1; j++)
				{
					if ((i & (1 << j)) != 0)
					{
						result += numbers[j+1];
					}
					else
					{
						result *= numbers[j+1];
					}
				}
				if(result == answer)
				{
					return true;
				}
			}
			return false;
		}
	}
}
