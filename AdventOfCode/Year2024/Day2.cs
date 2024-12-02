namespace AdventOfCode.Year2024;

public class Day2(string[] input)
{
	public int Part1()
	{
		return Parse().Count(IsSafe);
	}

	public int Part2()
	{
		return Parse().Count(report => Enumerable.Range(0, report.Length)
			.Any(skip => IsSafe([.. report[..skip], .. report[(skip + 1)..]])));
	}

	private static bool IsSafe(int[] report)
	{
		var increase = report[0] > report[1];

		return report.Window(2).All(pair =>
		{
			if (increase ? pair[0] < pair[1] : pair[0] > pair[1])
			{
				return false;
			}

			return Math.Abs(pair[0] - pair[1]) is 1 or 2 or 3;
		});
	}

	private IEnumerable<int[]> Parse() => input.Select(line => line.Split().ToInt32());
}
