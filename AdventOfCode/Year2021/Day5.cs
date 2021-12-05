namespace AdventOfCode.Year2021;

public class Day5
{
	private readonly string[] _input;

	public Day5(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var grid = new Dictionary<Point, int>();

		foreach (var (a, b) in GetPoints())
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

		foreach (var (a, b) in GetPoints())
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

	private IEnumerable<(Point a, Point b)> GetPoints()
	{
		foreach (var line in _input)
		{
			var span = line.AsSpan();
			var space = span.IndexOf(' ');
			var a = Point.Parse(span[..space]);
			var b = Point.Parse(span[(space + 4)..]);

			yield return (a, b);
		}
	}

	private readonly record struct Point(int X, int Y)
	{
		public static Point Parse(ReadOnlySpan<char> span)
		{
			var comma = span.IndexOf(',');
			var x = span[..comma].ToInt32();
			var y = span[(comma + 1)..].ToInt32();

			return new(x, y);
		}
	}
}
