namespace AdventOfCode.Year2023;

public class Day6(string[] input)
{
	public long Part1()
	{
		var times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..].ToInt64();
		var dists = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..].ToInt64();

		return times.Zip(dists).Select(x => Solve(x.First, x.Second)).Multiply();
	}

	public long Part2()
	{
		var time = input[0].Where(Char.IsDigit).ToString((sb, c) => sb.Append(c)).ToInt64();
		var dist = input[1].Where(Char.IsDigit).ToString((sb, c) => sb.Append(c)).ToInt64();

		return Solve(time, dist);
	}

	private static long Solve(long time, long dist)
	{
		var l = 0L;
		var h = time / 2;

		while (l + 1 < h)
		{
			var m = (l + h) / 2;
			(l, h) = m * (time - m) > dist ? (l, m) : (m, h);
		}

		return time - h * 2 + 1;
	}
}
