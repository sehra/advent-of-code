namespace AdventOfCode.Year2015;

public class Day16(string[] input)
{
	private readonly Dictionary<string, int> _match = new()
	{
		["children"] = 3,
		["cats"] = 7,
		["samoyeds"] = 2,
		["pomeranians"] = 3,
		["akitas"] = 0,
		["vizslas"] = 0,
		["goldfish"] = 5,
		["trees"] = 3,
		["cars"] = 2,
		["perfumes"] = 1,
	};

	public int Part1() => Parse().First(aunt => IsMatch(aunt.Value, false)).Key;

	public int Part2() => Parse().First(aunt => IsMatch(aunt.Value, true)).Key;

	private bool IsMatch(Dictionary<string, int> aunt, bool part2)
	{
		foreach (var (key, expect) in _match)
		{
			if (part2 && key is "cats" or "trees")
			{
				if (aunt.TryGetValue(key, out var actual) && actual <= expect)
				{
					return false;
				}

				continue;
			}
			else if (part2 && key is "pomeranians" or "goldfish")
			{
				if (aunt.TryGetValue(key, out var actual) && actual >= expect)
				{
					return false;
				}
			}
			else
			{
				if (aunt.TryGetValue(key, out var actual) && actual != expect)
				{
					return false;
				}
			}
		}

		return true;
	}

	private Dictionary<int, Dictionary<string, int>> Parse() => input
		.Select(line => line.Split(':', 2, StringSplitOptions.TrimEntries))
		.Select(line => (Name: line[0], Props: line[1].Split(',', StringSplitOptions.TrimEntries)))
		.ToDictionary(
			line => line.Name.Split()[1].ToInt32(),
			line => line.Props
				.Select(prop => prop.Split(':', StringSplitOptions.TrimEntries))
				.ToDictionary(prop => prop[0], prop => prop[1].ToInt32()));
}
