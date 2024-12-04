using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024
{
	internal class _2024d4p2
	{
		public static void Run()
		{
			//string input = "....XXMAS..SAMXMS......S..A.....A.A.MS.XXMASAMX.MMX.....XA.AS.S.S.S.SS.A.A.A.A.A..M.M.M.MM.X.X.XMASX";
			string input = ".M.S........A..MSMS..M.S.MAA....A.ASMSM..M.S.M..............S.S.S.S.S..A.A.A.A..M.M.M.M.M...........";//readInput("input.txt");

			//140^2
			char[,] grid = convertToGrid(input, 10, 10);
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
						Console.Write(grid[i, j]);
					}
				}
				Console.Write('\n');
			}
			return grid;
		}
		private static void search(char[,] grid)
		{
			// M S
			//  A
			// M S
			//3*3
			int count = 0;
			for (int i = 1; i < grid.GetLength(0) - 1; i++)
			{
				for (int j = 1; j < grid.GetLength(1) - 1; j++)
				{
					if (isCorrectPattern(grid, i, j))
					{
						count++;
						//	Console.WriteLine(count);
					}
                    Console.SetCursorPosition(i, j);
                    Console.Write('+');
					Thread.Sleep(20);
				}
			}
			Console.WriteLine(count);
		}
		private static bool isCorrectPattern(char[,] grid, int row, int col)
		{
			// M S
			//  A
			// M S

			char topLeft = grid[row - 1, col - 1];
			char topRight = grid[row - 1, col + 1];
			char center = grid[row, col];

			char bottomLeft = grid[row + 1, col - 1];
			char bottomRight = grid[row + 1, col + 1];
			//Console.WriteLine("Rows: [" + (row) + "," + (row + 1) + "," + (row + 2) + "] | " + topLeft + " " + topRight + " " + center + " " + bottomLeft + "  " + bottomRight);

			if (topLeft == 'M' && center == 'A' && bottomRight == 'S' && topRight == 'S' && bottomLeft == 'M')
			{
				Console.SetCursorPosition(row, col);
				Console.Write('*');
				return true;
			}
			if (topLeft == 'S' && center == 'A' && bottomRight == 'M' && topRight == 'M' && bottomLeft == 'S')
			{
				Console.SetCursorPosition(row, col);
				Console.Write('*');
				return true;
			}
			return false;
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
