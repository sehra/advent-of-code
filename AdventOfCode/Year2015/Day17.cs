namespace AdventOfCode.Year2015;

public class Day17(string[] input)
{
	public int Part1(int goal = 150)
	{
		var sizes = Parse();

		return Enumerable.Range(1, sizes.Length)
			.SelectMany(count => sizes.Combinations(count))
			.Count(buckets => buckets.Sum() == goal);
	}

	public int Part2(int goal = 150)
	{
		var sizes = Parse();

		return Enumerable.Range(1, sizes.Length)
			.SelectMany(count => sizes.Combinations(count))
			.Where(buckets => buckets.Sum() == goal)
			.Select(buckets => buckets.Count())
			.GroupBy(count => count)
			.OrderBy(group => group.Key)
			.First()
			.Count();
	}

	private int[] Parse() => input.ToInt32();
}
