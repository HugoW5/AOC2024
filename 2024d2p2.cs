using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024
{
	public static class _2024d2p2
	{
		public static List<List<int>> levels = new();

		public static void Run()
		{

			//615 is too high
			//376 is too high
			//293 = ture

			levels = readInput("input.txt");
/*			levels.AddRange(new List<List<int>>{
		new List<int> { 7, 6, 4, 2, 1 },
		new List<int> { 1, 2, 7, 8, 9 },
		new List<int> { 1, 3, 2, 4, 5 },
		new List<int> { 8, 6, 4, 4, 1 },
		new List<int> { 1, 3, 6, 7, 9 }
	});
*/
			int safes = 0;
			foreach (var level in levels)
			{
				if (checkLine(level))
				{
					safes++;
				}
			}
			Console.WriteLine(safes);
		}
		public static bool checkLine(List<int> line)
		{
			for (int k = 0; k < line.Count; k++)
			{
				var tmpline = new List<int>(line);
				tmpline.RemoveAt(k);
				bool safe = true;
				bool increasing = true;
				bool decreasing = true;


				for (int i = 1; i < tmpline.Count; i++)
				{
					int diff = tmpline[i] - tmpline[i - 1];
					if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
					{
						safe = false;
						break;
					}
					if (diff > 0)
					{
						decreasing = false;
					}
					if (diff < 0)
					{
						increasing = false;
					}
				}
				if (safe && (increasing || decreasing))
				{
					return true;
				}
			}
			return false;
		}



		private static List<List<int>> readInput(string path)
		{
			List<string> input = new();
			List<List<int>> levels = new();
			using (StreamReader sr = new StreamReader(path))
			{
				while (!sr.EndOfStream)
				{
					input.Add(sr.ReadLine());
				}
			}
			foreach (string line in input)
			{
				List<int> tmpLvls = new();
				foreach (string lvl in line.Split(' '))
				{
					tmpLvls.Add(int.Parse(lvl));
				}
				levels.Add(tmpLvls);
			}
			return levels;
		}
	}
}
