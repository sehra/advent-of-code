namespace AdventOfCode.Year2019;

public class Day10
{
	private readonly (int x, int y)[] _input;

	public Day10(string input)
	{
		_input = input
			.Split('\n')
			.Select(l => l.Trim())
			.SelectMany((l, y) => l.Select((c, x) => (x, y, c)).Where(p => p.c == '#'))
			.Select(p => (p.x, p.y))
			.ToArray();
	}

	public ((int x, int y), int) Part1()
	{
		return _input
			.Select(origin => (origin, count: _input
				.Where(point => point != origin)
				.GroupBy(point => Math.Atan2(point.y - origin.y, point.x - origin.x))
				.Count()
			))
			.OrderByDescending(result => result.count)
			.First();
	}

	public int Part2()
	{
		var (origin, _) = Part1();
		var sorted = _input
			.Where(point => point != origin)
			.Select(point => (point, angle: Math.Atan2(point.x - origin.x, point.y - origin.y)))
			.GroupBy(asteroid => asteroid.angle)
			.OrderByDescending(group => group.Key)
			.Select(group => group.OrderBy(asteroid => Distance(origin, asteroid.point)))
			.ToList();

		if (sorted.Count >= 200)
		{
			var (point, _) = sorted[199].First();
			return (point.x * 100) + point.y;
		}

		throw new Exception("left as an exercise to the reader");
	}

	private static double Distance((int x, int y) p1, (int x, int y) p2) =>
		Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
}
