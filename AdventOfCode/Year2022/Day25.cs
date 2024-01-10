namespace AdventOfCode.Year2022;

public class Day25(string[] input)
{
	public string Part1()
	{
		long total = 0;

		foreach (var line in input)
		{
			long value = 0;

			foreach (var c in line)
			{
				value *= 5;
				value += "=-012".IndexOf(c) - 2;
			}

			total += value;
		}

		var snafu = new Stack<char>();

		while (total > 0)
		{
			(total, var index) = Math.DivRem(total + 2, 5);
			snafu.Push("=-012"[(int)index]);
		}

		return new([.. snafu]);
	}

	public string Part2()
	{
		return "get 49 stars";
	}
}
