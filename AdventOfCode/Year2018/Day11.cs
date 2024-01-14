namespace AdventOfCode.Year2018;

public class Day11(string input)
{
	public string Part1()
	{
		var grid = Parse();

		var pbest = 0;
		var xbest = 0;
		var ybest = 0;

		for (int x = 3; x < grid.GetLength(0); x++)
		{
			for (int y = 3; y < grid.GetLength(1); y++)
			{
				var power = TotalPower(grid, x, y, 3);

				if (power > pbest)
				{
					pbest = power;
					xbest = x;
					ybest = y;
				}
			}
		}

		return $"{xbest - 3 + 1},{ybest - 3 + 1}";
	}

	public string Part2()
	{
		var grid = Parse();

		var pbest = 0;
		var xbest = 0;
		var ybest = 0;
		var sbest = 0;

		for (int s = 1; s <= 300; s++)
		{
			for (int x = s; x < grid.GetLength(0); x++)
			{
				for (int y = s; y < grid.GetLength(1); y++)
				{
					var power = TotalPower(grid, x, y, s);

					if (power > pbest)
					{
						pbest = power;
						xbest = x;
						ybest = y;
						sbest = s;
					}
				}
			}
		}

		return $"{xbest - sbest + 1},{ybest - sbest + 1},{sbest}";
	}

	private static int TotalPower(int[,] grid, int x, int y, int s) =>
		grid[x, y] + grid[x - s, y - s] - grid[x, y - s] - grid[x - s, y];

	private int[,] Parse()
	{
		// https://en.wikipedia.org/wiki/Summed-area_table

		var serial = input.ToInt32();
		var grid = new int[301, 301];

		for (int x = 1; x < grid.GetLength(0); x++)
		{
			for (int y = 1; y < grid.GetLength(1); y++)
			{
				var power = Power(x, y);
				power += grid[x, y - 1];
				power += grid[x - 1, y];
				power -= grid[x - 1, y - 1];
				grid[x, y] = power;
			}
		}

		return grid;

		int Power(int x, int y)
		{
			var rack = x + 10;
			var power = rack * y;
			power += serial;
			power *= rack;
			power /= 100;
			power %= 10;
			power -= 5;

			return power;
		}
	}
}
