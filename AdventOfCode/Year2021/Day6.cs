namespace AdventOfCode.Year2021;

public class Day6
{
	private readonly int[] _input;

	public Day6(string input)
	{
		_input = input.Split(',').Select(Int32.Parse).ToArray();
	}

	public long Part1(int days = 80)
	{
		return Simulate(_input, days).Sum();
	}

	public long Part2()
	{
		return Simulate(_input, 256).Sum();
	}

	private static long[] Simulate(int[] input, int days)
	{
		var curr = new long[9];

		foreach (var item in input)
		{
			curr[item]++;
		}

		for (int day = 0; day < days; day++)
		{
			var next = new long[9];

			for (int i = 1; i < curr.Length; i++)
			{
				next[i - 1] = curr[i];
			}

			next[6] = curr[0] + curr[7];
			next[8] = curr[0];

			curr = next;
		}

		return curr;
	}
}
