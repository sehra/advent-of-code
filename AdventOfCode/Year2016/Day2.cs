namespace AdventOfCode.Year2016;

public class Day2(string[] input)
{
	public string Part1()
	{
		return input
			.Scan(5, (key, line) => line.Aggregate(key, Step))
			.ToString((sb, key) => sb.Append(Hex(key)));

		static int Step(int key, char dir) => (key, dir) switch
		{
			(1 or 2 or 3, 'U') => key,
			(4 or 5 or 6, 'U') => key - 3,
			(7 or 8 or 9, 'U') => key - 3,
			(1 or 2 or 3, 'D') => key + 3,
			(4 or 5 or 6, 'D') => key + 3,
			(7 or 8 or 9, 'D') => key,
			(1 or 4 or 7, 'L') => key,
			(2 or 5 or 8, 'L') => key - 1,
			(3 or 6 or 9, 'L') => key - 1,
			(1 or 4 or 7, 'R') => key + 1,
			(2 or 5 or 8, 'R') => key + 1,
			(3 or 6 or 9, 'R') => key,
			_ => throw new Exception("key? dir?"),
		};
	}

	public string Part2()
	{
		return input
			.Scan(5, (key, line) => line.Aggregate(key, Step))
			.ToString((sb, key) => sb.Append(Hex(key)));

		static int Step(int key, char dir) => (key, dir) switch
		{
			(5 or 2 or 1 or 4 or 9, 'U') => key,
			(3, 'U') => 1,
			(6 or 7 or 8 or 10 or 11 or 12, 'U') => key - 4,
			(13, 'U') => 11,
			(5 or 10 or 13 or 12 or 9, 'D') => key,
			(11, 'D') => 13,
			(2 or 3 or 4 or 6 or 7 or 8, 'D') => key + 4,
			(1, 'D') => 3,
			(1 or 2 or 5 or 10 or 13, 'L') => key,
			(6 or 3 or 7 or 11 or 4 or 8 or 12 or 9, 'L') => key - 1,
			(1 or 4 or 9 or 12 or 13, 'R') => key,
			(8 or 3 or 7 or 11 or 2 or 6 or 10 or 5, 'R') => key + 1,
			_ => throw new Exception("key? dir?"),
		};
	}

	private static char Hex(int key) => "0123456789ABCDEF"[key];
}
