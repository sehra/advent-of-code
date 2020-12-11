using System;
using System.Linq;

namespace AdventOfCode.Year2020
{
	public class Day11
	{
		private readonly char[,] _input;

		public Day11(string input)
		{
			var lines = input.ToLines();
			_input = new char[lines.Length, lines[0].Length];

			for (int row = 0; row < lines.Length; row++)
			{
				for (int col = 0; col < lines[row].Length; col++)
				{
					_input[row, col] = lines[row][col];
				}
			}
		}

		public int Part1()
		{
			return CountStable(_input, GetAdjacent, 4);

			static char?[] GetAdjacent(char[,] arr, int row, int col) => new[]
			{
				Get(arr, row - 1, col - 1), // nw
				Get(arr, row - 1, col), // n
				Get(arr, row - 1, col + 1), // ne
				Get(arr, row, col - 1), // w
				Get(arr, row, col + 1), // e
				Get(arr, row + 1, col - 1), // sw
				Get(arr, row + 1, col), // s
				Get(arr, row + 1, col + 1), // se
			};
		}

		public int Part2()
		{
			return CountStable(_input, GetAdjacent, 5);

			static char?[] GetAdjacent(char[,] arr, int row, int col) => new[]
			{
				GetVisible(arr, row, -1, col, -1), // nw
				GetVisible(arr, row, -1, col, 0), // n
				GetVisible(arr, row, -1, col, 1), // ne
				GetVisible(arr, row, 0, col, -1), // w
				GetVisible(arr, row, 0, col, 1), // e
				GetVisible(arr, row, 1, col, -1), // sw
				GetVisible(arr, row, 1, col, 0), // s
				GetVisible(arr, row, 1, col, 1), // se
			};

			static char? GetVisible(char[,] arr, int row, int rowStep, int col, int colStep)
			{
				(row, col) = Step(row, col);

				while (true)
				{
					var tile = Get(arr, row, col);

					if (tile is ('L' or '#'))
					{
						return tile;
					}
					else if (tile is '.')
					{
						(row, col) = Step(row, col);
					}
					else
					{
						return null;
					}
				}

				(int, int) Step(int row, int col) => (row + rowStep, col + colStep);
			}
		}

		private static int CountStable(char[,] curr, Func<char[,], int, int, char?[]> getAdjacent, int tolerance)
		{
			while (true)
			{
				var next = Next(curr, getAdjacent, tolerance);

				if (IsEqual(curr, next))
				{
					var count = 0;

					for (int row = 0; row < next.GetLength(0); row++)
					{
						for (int col = 0; col < next.GetLength(1); col++)
						{
							if (next[row, col] is '#')
							{
								count++;
							}
						}
					}

					return count;
				}

				curr = next;
			}
		}

		private static char[,] Next(char[,] curr, Func<char[,], int, int, char?[]> getAdjacent, int tolerance)
		{
			var next = new char[curr.GetLength(0), curr.GetLength(1)];

			for (int row = 0; row < curr.GetLength(0); row++)
			{
				for (int col = 0; col < curr.GetLength(1); col++)
				{
					var tile = Get(curr, row, col);
					var adjacent = getAdjacent(curr, row, col);

					if (tile is 'L' && adjacent.All(c => c is not '#'))
					{
						next[row, col] = '#';
					}
					else if (tile is '#' && adjacent.Count(c => c is '#') >= tolerance)
					{
						next[row, col] = 'L';
					}
					else
					{
						next[row, col] = curr[row, col];
					}
				}
			}

			return next;
		}

		private static char? Get(char[,] arr, int row, int col)
		{
			if (row < 0 || row >= arr.GetLength(0) ||
				col < 0 || col >= arr.GetLength(1))
			{
				return null;
			}

			return arr[row, col];
		}

		private static bool IsEqual(char[,] lhs, char[,] rhs)
		{
			for (int row = 0; row < lhs.GetLength(0); row++)
			{
				for (int col = 0; col < lhs.GetLength(1); col++)
				{
					if (lhs[row, col] != rhs[row, col])
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
