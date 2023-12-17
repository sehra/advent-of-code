namespace AdventOfCode.Year2015;

public class Day13(string[] input)
{
	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	private int Solve(bool add)
	{
		var table = Parse();

		if (add)
		{
			table["X"] = [];

			foreach (var (key, other) in table)
			{
				table["X"][key] = 0;
				other["X"] = 0;
			}
		}

		return table.Keys
			.Permutations()
			.Select(x => x.Append(x.First()))
			.Select(x => x.Window(2).Aggregate(0, (acc, y) => acc + table[y[0]][y[1]] + table[y[1]][y[0]]))
			.Max();
	}

	private Dictionary<string, Dictionary<string, int>> Parse()
	{
		var table = new Dictionary<string, Dictionary<string, int>>();

		foreach (var line in input)
		{
			var match = Regex.Match(line, @"^(\p{Lu}\w+).*(gain|lose)\D*(\d+).*(\p{Lu}\w+).$");
			var src = match.Groups[1].Value;
			var dst = match.Groups[4].Value;
			var neg = match.Groups[2].Value == "gain" ? 1 : -1;
			var num = match.Groups[3].ValueSpan.ToInt32();

			if (!table.TryGetValue(src, out var map))
			{
				map = table[src] = [];
			}

			map[dst] = neg * num;
		}

		return table;
	}
}
