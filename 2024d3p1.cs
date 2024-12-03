using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024
{
	public static class _2024d3p1
	{

		public static void Run()
		{
			string input = readInput("input.txt");
			List<string> nums = new();
				foreach (string inputItem2 in input.Split("mul"))
				{
					string s = "";
					bool firstP = false;
					bool secondP = false;
					foreach (char c in inputItem2)
					{
						if (c == '(')
						{
							if (firstP)
							{
								break;
							}
							firstP = true;
						}
						if (c == ')')
						{
							secondP = true;
							s = s + c;
							break;
						}
						s = s + c;
					}
					if (firstP && secondP)
					{
						nums.Add(s);
					}
					s = "";
				}
			
			//157633759 is too high
			decimal total = 0;
			foreach (string multiplication in nums)
			{
				if (multiplication.Contains(","))
				{
					string[] parts = multiplication.Split(",");
					if (parts.Length == 2)
					{
						string firstNum = new string(parts[0].Where(char.IsDigit).ToArray());
						string secondNum = new string(parts[1].Where(char.IsDigit).ToArray());
						if(int.TryParse(firstNum, out int first) && int.TryParse(secondNum, out int second))
						{
							total += first*second;
						}
					}
				}
			}
            Console.WriteLine(total);
		}
		private static string readInput(string path)
		{
			string input = "";
			using (StreamReader sr = new StreamReader(path))
			{
				while (!sr.EndOfStream)
				{
					input += sr.ReadLine();
				}
			}
			return input;
		}
	}
}
