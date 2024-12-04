using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024
{
	internal class _2024d4p1
	{
		public static void Run()
		{
			string input = readInput("input.txt");

			char[,] grid = convertToGrid(input, 140, 140);
			search(grid);
		}
		private static char[,] convertToGrid(string inp, int rows, int cols)
		{
			char[,] grid = new char[rows, cols];

			int count = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (count < inp.Length)
					{
						grid[i, j] = inp[count];
						count++;
					}
				}
			}
			return grid;
		}
		private static void search(char[,] grid)
		{
			//388 is too low
			//389 too low
			int count = 0;

			int[][] dirs =
			{
		new int[]{ 0, 1 },
		new int[]{ 0, -1 },
		new int[]{ 1, 0 },
		new int[]{ -1, 0 },
		new int[]{ 1, 1 },
		new int[]{ 1, -1 },
		new int[]{ -1, 1 },
		new int[]{ -1, -1 }
	};

			string word = "XMAS";

			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					foreach (var dir in dirs)
					{
						string tmp = "";

						for (int k = 0; k < word.Length; k++)
						{
							int newRow = i + k * dir[0];
							int newCol = j + k * dir[1];

							if (newRow < 0 || newRow >= grid.GetLength(0) || newCol < 0 || newCol >= grid.GetLength(1))
							{
								break;
							}

							if (grid[newRow, newCol] != word[k])
							{
								break;
							}
							tmp += grid[newRow, newCol];
						}

						if (tmp == word)
						{
							count++;
							Console.WriteLine(count);
						}
					}
				}
			}
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
