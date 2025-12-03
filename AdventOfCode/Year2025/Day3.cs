namespace AdventOfCode.Year2025;

public class Day3(string[] input)
{
	public long Part1() => Solve(2);

	public long Part2() => Solve(12);

	private long Solve(int count)
	{
		var total = 0L;

		foreach (var line in input)
		{
			var used = new List<(int Index, int Item)>() { (-1, 0) };

			for (int i = 0; i < count; i++)
			{
				var pick = line.Index()
					.SkipLast(count - i - 1)
					.Where(x => x.Index > used[^1].Index)
					.MaxBy(x => x.Item);
				used.Add(pick);
			}

			total += used.Skip(1).Aggregate(0L, (acc, x) => acc * 10 + x.Item - '0');
		}

		return total;
	}
}
