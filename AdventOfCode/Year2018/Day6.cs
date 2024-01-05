namespace AdventOfCode.Year2018;

using Point = (int X, int Y);

public class Day6(string[] input)
{
	public int Part1()
	{
		var points = Parse();
		var xmax = points.Max(p => p.X) + 1;
		var ymax = points.Max(p => p.Y) + 1;
		var grid = new Point[xmax, ymax];

		for (int x = 0; x < xmax; x++)
		{
			for (int y = 0; y < ymax; y++)
			{
				var closest = points
					.MinByWithTies(p => TaxiDist(p, new(x, y)));

				if (closest.Count is 1)
				{
					grid[x, y] = closest[0];
				}
			}
		}

		for (int x = 0; x < xmax; x++)
		{
			RemoveAll(grid[x, 0]);
			RemoveAll(grid[x, ymax - 1]);
		}

		for (int y = 0; y < ymax; y++)
		{
			RemoveAll(grid[0, y]);
			RemoveAll(grid[xmax - 1, y]);
		}

		return grid.AsEnumerable()
			.Where(p => p.Value != default)
			.GroupBy(p => p.Value)
			.Max(g => g.Count());

		void RemoveAll(Point p)
		{
			if (p == default)
			{
				return;
			}

			for (int x = 0; x < xmax; x++)
			{
				for (int y = 0; y < ymax; y++)
				{
					if (grid[x, y] == p)
					{
						grid[x, y] = default;
					}
				}
			}
		}
	}

	public int Part2(int distance = 10_000)
	{
		var points = Parse();
		var xmax = points.Max(p => p.X) + 1;
		var ymax = points.Max(p => p.Y) + 1;
		var count = 0;

		for (int x = 0; x < xmax; x++)
		{
			for (int y = 0; y < ymax; y++)
			{
				if (points.Sum(p => TaxiDist(p, new(x, y))) < distance)
				{
					count++;
				}
			}
		}

		return count;
	}

	private static int TaxiDist(Point a, Point b) =>
		Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y);

	private List<Point> Parse() => input
		.Select(line => line.Split(',').ToInt32())
		.Select(line => (line[0], line[1]))
		.ToList();
}
