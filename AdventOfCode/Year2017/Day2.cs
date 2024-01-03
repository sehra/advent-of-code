namespace AdventOfCode.Year2017;

public class Day2(string[] input)
{
	public int Part1()
	{
		return input
			.Select(line => line.Split().ToInt32())
			.Sum(line => line.Max() - line.Min());
	}

	public int Part2()
	{
		return input
			.Select(line => line.Split().ToInt32())
			.Select(line => line
				.Order()
				.Combinations(2)
				.Select(pair => Math.DivRem(pair.ElementAt(1), pair.ElementAt(0)))
				.Where(div => div.Remainder is 0)
				.Single()
			)
			.Sum(div => div.Quotient);
	}
}
