namespace AdventOfCode.Year2021;

public class Day5
{
	private readonly (Point A, Point B)[] _input;

	public Day5(string input)
	{
		_input = input.ToLines()
			.Select(line => line.Split(" -> "))
			.Select(line => (Point.Parse(line[0]), Point.Parse(line[1])))
			.ToArray();
	}

	public int Part1()
	{
		var grid = new Dictionary<Point, int>();

		foreach (var (a, b) in _input)
		{
			if (a.X == b.X || a.Y == b.Y)
			{
				AddLine(grid, a, b);
			}
		}

		return grid.Values.Count(v => v > 1);
	}

	public int Part2()
	{
		var grid = new Dictionary<Point, int>();

		foreach (var (a, b) in _input)
		{
			if (a.X == b.X || a.Y == b.Y)
			{
				AddLine(grid, a, b);
			}
			else
			{
				var (xmin, xmax, ymin) = a.X < b.X ? (a.X, b.X, a.Y) : (b.X, a.X, b.Y);
				var ydelta = a.Y < b.Y ? (ymin == a.Y ? 1 : -1) : (ymin == a.Y ? -1 : 1);

				for (int x = xmin, y = ymin; x <= xmax; x++, y += ydelta)
				{
					grid.Upsert(new(x, y), v => v + 1, 1);
				}
			}
		}

		return grid.Values.Count(v => v > 1);
	}

	private static void AddLine(Dictionary<Point, int> grid, Point a, Point b)
	{
		var (xmin, xmax) = a.X < b.X ? (a.X, b.X) : (b.X, a.X);
		var (ymin, ymax) = a.Y < b.Y ? (a.Y, b.Y) : (b.Y, a.Y);

		for (int x = xmin; x <= xmax; x++)
		{
			for (int y = ymin; y <= ymax; y++)
			{
				grid.Upsert(new(x, y), v => v + 1, 1);
			}
		}
	}

	private readonly record struct Point(int X, int Y)
	{
		public static Point Parse(string s)
		{
			var split = s.Split(',');

			return new(split[0].ToInt32(), split[1].ToInt32());
		}
	}
}
