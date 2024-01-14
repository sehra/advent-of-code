namespace AdventOfCode.Year2018;

using Point = (int X, int Y, int Z, int W);

public class Day25(string[] input)
{
	public int Part1()
	{
		var points = Parse();
		var count = 0;

		while (points.Count > 0)
		{
			count++;
			var group = new List<Point>() { points[0] };
			points.RemoveAt(0);

			while (true)
			{
				var close = points
					.Where(a => group.Any(b => TaxiDist(a, b) <= 3))
					.ToArray();

				if (close.Length is 0)
				{
					break;
				}

				foreach (var point in close)
				{
					group.Add(point);
					points.Remove(point);
				}
			}
		}

		return count;

		static int TaxiDist(Point a, Point b) =>
			Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) +
			Math.Abs(a.Z - b.Z) + Math.Abs(a.W - b.W);
	}

	public string Part2()
	{
		return "get 49 stars";
	}

	private List<Point> Parse() => input
		.Select(line => line.Split(',').ToInt32())
		.Select(line => (line[0], line[1], line[2], line[3]))
		.ToList();
}
