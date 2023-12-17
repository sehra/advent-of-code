namespace AdventOfCode.Year2015;

public class Day9(string[] input)
{
	public int Part1() => Solve().Min();

	public int Part2() => Solve().Max();

	private int[] Solve()
	{
		var map = Parse();

		return map.Keys
			.Permutations()
			.Select(path => path.Window(2).Aggregate(0, (dist, pair) => dist + map[pair[0]][pair[1]]))
			.ToArray();
	}

	private Dictionary<string, Dictionary<string, int>> Parse()
	{
		var map = new Dictionary<string, Dictionary<string, int>>();

		foreach (var line in input)
		{
			var match = Regex.Match(line, @"^(\w+) to (\w+) = (\d+)$");
			var src = match.Groups[1].Value;
			var dst = match.Groups[2].Value;
			var len = match.Groups[3].ValueSpan.ToInt32();

			if (!map.ContainsKey(src))
			{
				map[src] = [];
			}

			if (!map.ContainsKey(dst))
			{
				map[dst] = [];
			}

			map[src][dst] = len;
			map[dst][src] = len;
		}

		return map;
	}
}
