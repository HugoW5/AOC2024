using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AOC2024
{
	internal class _2024d6p1
	{
		public static void Run()
		{
			/*			string input = @"....#.....
			.........#
			..........
			..#.......
			.......#..
			..........
			.#..^.....
			........#.
			#.........
			......#...";*/
			string input = File.ReadAllText("input.txt");

			var grid = convertToGrid(input);
			walk(grid);

		}
		private static void walk(char[,] grid)
		{
			(int x, int y) direction = (-1, 0);

			while (true)
			{
				//check if next step is not a collision
				if (!collision(grid, direction))
				{
					var tmpGrid = grid;
					var guardPos = findGaurd(tmpGrid);
					(int x, int y) newPos;
					newPos.x = guardPos.x + direction.x;
					newPos.y = guardPos.y + direction.y;

					tmpGrid[guardPos.x, guardPos.y] = 'X';
					tmpGrid[newPos.x, newPos.y] = '^';
					//Console.WriteLine(newPos.x + " " + newPos.y);
					grid = tmpGrid;
					//Console.SetCursorPosition(0, 0);
					//printGrid(grid);
				}
				else
				{
					if (direction == (-1, 0))
					{
						direction = (0, 1);
						continue;
					}
					if (direction == (1, 0))
					{
						direction = (0, -1);
						continue;
					}
					if (direction == (0, 1))
					{
						direction = (1, 0);
						continue;
					}
					if (direction == (0, -1))
					{
						direction = (-1, 0);
						continue;
					}
				}
				//Thread.Sleep(100);

			}
		}
		private static bool collision(char[,] grid, (int x, int y) direction)
		{
			var guardPos = findGaurd(grid);
			(int x, int y) newPos;
			newPos.x = guardPos.x + direction.x;
			newPos.y = guardPos.y + direction.y;

			char nextStep = ' ';
			bool outside = true;

			if (newPos.x >= 0 && newPos.x <= grid.GetLength(0) - 1 && newPos.y >= 0 && newPos.y <= grid.GetLength(0) - 1)
			{
				outside = false;
			}
			if (outside)
			{
				// pause because next step is outside
				countSteps(grid);
				Console.ReadLine();
			}
			else
			{
				nextStep = grid[newPos.x, newPos.y];
			}
			//Collision found!
			if (nextStep == '#')
			{
				return true;
			}
			return false;

		}
		private static void countSteps(char[,] grid)
		{
			int count = 0;
			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					if (grid[i, j] == 'X')
					{
						count++;
					}
				}
			}
            Console.WriteLine(count);
		}
		private static (int x, int y) findGaurd(char[,] grid)
		{
			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					if (grid[i, j] == '^')
					{
						return (i, j);
					}
				}
			}
			return (-1, -1);
		}
		private static void printGrid(char[,] grid)
		{
			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(0); j++)
				{
					Console.Write(grid[i, j]);
				}
				Console.Write('\n');
			}
		}
		private static char[,] convertToGrid(string input)
		{
			var rows = input.Split('\n');
			char[,] grid = new char[rows.Length, rows[1].Length];
			for (int i = 0; i < rows.Length; i++)
			{
				for (int j = 0; j < rows[i].Length; j++)
				{
					grid[i, j] = rows[i][j];
				}
			}
			return grid;
		}
	}
}
