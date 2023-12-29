namespace AdventOfCode.Year2015;

public class Day18(string[] input)
{
	public int Part1(int steps = 100) => Solve(steps, false);

	public int Part2(int steps = 100) => Solve(steps, true);

	private int Solve(int steps, bool corners)
	{
		var grid = Parse();

		if (corners)
		{
			TurnOnCorners();
		}

		for (int step = 0; step < steps; step++)
		{

			var next = new bool[grid.GetLength(0), grid.GetLength(1)];

			for (int row = 0; row < grid.GetLength(0); row++)
			{
				for (int col = 0; col < grid.GetLength(1); col++)
				{
					if (grid[row, col])
					{
						next[row, col] = CountNeighbors(row, col) is 2 or 3;
					}
					else
					{
						next[row, col] = CountNeighbors(row, col) is 3;
					}
				}
			}

			grid = next;

			if (corners)
			{
				TurnOnCorners();
			}
		}

		return grid.AsEnumerable()
			.Count(g => g.Value);

		void TurnOnCorners()
		{
			grid[0, 0] = true;
			grid[grid.GetLength(0) - 1, 0] = true;
			grid[0, grid.GetLength(1) - 1] = true;
			grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1] = true;
		}

		int CountNeighbors(int row, int col)
		{
			var count = 0;

			foreach (var nbor in Neighbors(row, col))
			{
				if (0 <= nbor.Row && nbor.Row < grid.GetLength(0) &&
					0 <= nbor.Col && nbor.Col < grid.GetLength(1))
				{
					count += grid[nbor.Row, nbor.Col] ? 1 : 0;
				}
			}

			return count;

			static IEnumerable<(int Row, int Col)> Neighbors(int row, int col)
			{
				yield return (row + 1, col + 1);
				yield return (row + 1, col);
				yield return (row + 1, col - 1);
				yield return (row, col + 1);
				yield return (row, col - 1);
				yield return (row - 1, col + 1);
				yield return (row - 1, col);
				yield return (row - 1, col - 1);
			}
		}
	}

	private bool[,] Parse()
	{
		var grid = new bool[input.Length, input[0].Length];

		for (int row = 0; row < input.Length; row++)
		{
			for (int col = 0; col < input[row].Length; col++)
			{
				if (input[row][col] is '#')
				{
					grid[row, col] = true;
				}
			}
		}

		return grid;
	}
}
