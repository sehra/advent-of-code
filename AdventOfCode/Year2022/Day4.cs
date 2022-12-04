namespace AdventOfCode.Year2022;

public class Day4
{
	private readonly string[] _input;

	public Day4(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var count = 0;

		foreach (var (x, y) in Parse())
		{
			if ((x.A >= y.A && x.B <= y.B) ||
				(y.A >= x.A && y.B <= x.B))
			{
				count++;
			}
		}

		return count;
	}

	public int Part2()
	{
		var count = 0;

		foreach (var (x, y) in Parse())
		{
			if ((x.A >= y.A && x.A <= y.B) ||
				(x.B >= y.B && x.B <= y.B) ||
				(y.A >= x.A && y.A <= x.B) ||
				(y.B >= x.A && y.B <= x.B))
			{
				count++;
			}
		}

		return count;
	}

	private readonly record struct Pair(int A, int B)
	{
		public static Pair Parse(string str)
		{
			var split = str.Split('-');

			return new(split[0].ToInt32(), split[1].ToInt32());
		}
	}

	private (Pair X, Pair Y)[] Parse() => _input
		.Select(line => line.Split(','))
		.Select(split => (Pair.Parse(split[0]), Pair.Parse(split[1])))
		.ToArray();
}
