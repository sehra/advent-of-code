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
			AddLine(grid, a, b);
		}

		return grid.Values.Count(v => v > 1);
	}

	private static void AddLine(Dictionary<Point, int> grid, Point a, Point b)
	{
		var xlen = Math.Abs(b.X - a.X);
		var ylen = Math.Abs(b.Y - a.Y);
		var xsign = Math.Sign(b.X - a.X);
		var ysign = Math.Sign(b.Y - a.Y);

		for (int i = 0; i <= Math.Max(xlen, ylen); i++)
		{
			var point = new Point(a.X + xsign * i, a.Y + ysign * i);
			grid.Upsert(point, v => v + 1, 1);
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
