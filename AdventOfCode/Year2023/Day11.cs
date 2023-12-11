namespace AdventOfCode.Year2023;

public class Day11(string[] input)
{
	public long Part1() => Solve(2);

	public long Part2(int exp = 1_000_000) => Solve(exp);

	private long Solve(int exp)
	{
		var map = Parse(exp);
		var sum = 0L;

		for (int a = 0; a < map.Count; a++)
		{
			for (int b = a + 1; b < map.Count; b++)
			{
				sum += TaxiDist(map[a], map[b]);
			}
		}

		return sum;

		static long TaxiDist(Point a, Point b) =>
			Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y);
	}

	private readonly record struct Point(long X, long Y);

	private List<Point> Parse(int exp)
	{
		var map = new List<Point>();
		var xgap = new List<int>();
		var ygap = new List<int>();

		for (int y = 0; y < input.Length; y++)
		{
			if (input[y].All(c => c is '.'))
			{
				ygap.Add(y);
			}
		}

		for (int x = 0; x < input[0].Length; x++)
		{
			if (input.All(c => c[x] is '.'))
			{
				xgap.Add(x);
			}
		}

		for (int y = 0; y < input.Length; y++)
		{
			var yadd = ygap.Count(v => v < y) * (exp - 1);

			for (int x = 0; x < input[y].Length; x++)
			{
				if (input[y][x] is '#')
				{
					var xadd = xgap.Count(v => v < x) * (exp - 1);
					map.Add(new(x + xadd, y + yadd));
				}
			}
		}

		return map;
	}
}
