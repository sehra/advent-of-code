namespace AdventOfCode.Year2015;

public class Day24(long[] input)
{
	public long Part1() => Solve(3);

	public long Part2() => Solve(4);

	private long Solve(int parts)
	{
		var weight = input.Sum() / parts;

		for (int i = 1; i < input.Length; i++)
		{
			var combos = input.Combinations(i)
				.Where(nums => nums.Sum() == weight)
				.ToArray();

			if (combos.Length != 0)
			{
				return combos.Min(nums => nums.Multiply());
			}
		}

		throw new Exception("not found");
	}
}
