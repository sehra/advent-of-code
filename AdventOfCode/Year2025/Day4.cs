namespace AdventOfCode.Year2025;

using Vec = Vec2<int>;

public class Day4(string[] input)
{
	public int Part1()
	{
		var rolls = Parse();
		var count = 0;

		foreach (var roll in rolls)
		{
			if (Neighbors(roll).Count(rolls.Contains) < 4)
			{
				count++;
			}
		}

		return count;
	}

	public int Part2()
	{
		var rolls = Parse();
		var total = 0;

		while (true)
		{
			var count = 0;

			foreach (var roll in rolls)
			{
				if (Neighbors(roll).Count(rolls.Contains) < 4)
				{
					rolls.Remove(roll);
					count++;
				}
			}

			if (count is 0)
			{
				return total;
			}

			total += count;
		}
	}

	private static IEnumerable<Vec> Neighbors(Vec v)
	{
		for (int dx = -1; dx <= 1; dx++)
		{
			for (int dy = -1; dy <= 1; dy++)
			{
				if ((dx, dy) != (0, 0))
				{
					yield return v + (dx, dy);
				}
			}
		}
	}

	private HashSet<Vec> Parse() => [.. input
		.SelectMany((line, y) => line.Select((c, x) => (c, v: new Vec(x, y))))
		.Where(x => x.c is '@')
		.Select(x => x.v)];
}
