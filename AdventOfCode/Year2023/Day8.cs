namespace AdventOfCode.Year2023;

using Map = Dictionary<string, (string, string)>;

public class Day8(string[] input)
{
	public long Part1()
	{
		var (dirs, map) = Parse();

		return Steps(dirs, map, "AAA", pos => pos is "ZZZ");
	}

	public long Part2()
	{
		var (dirs, map) = Parse();

		return map.Keys
			.Where(pos => pos[^1] is 'A')
			.Select(pos => Steps(dirs, map, pos, pos => pos[^1] is 'Z'))
			.Aggregate(MathFunc.Lcm);
	}

	private static long Steps(string dirs, Map map, string pos, Func<string, bool> done)
	{
		foreach (var dir in dirs.Repeat().Index())
		{
			if (done(pos))
			{
				return dir.Key;
			}

			var (l, r) = map[pos];
			pos = dir.Value is 'L' ? l : r;
		}

		throw new Exception("not found");
	}

	private (string, Map) Parse()
	{
		var dirs = input[0];
		var map = input.Skip(1)
			.ToDictionary(line => line[0..3], line => (line[7..10], line[12..15]));

		return (dirs, map);
	}
}
