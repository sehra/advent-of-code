namespace AdventOfCode.Year2017;

using Tower = Dictionary<string, (int Weight, HashSet<string> Above)>;

public class Day7(string[] input)
{
	public string Part1() => GetRoot(Parse());

	public int Part2()
	{
		var tower = Parse();

		return FindChange(GetRoot(tower));

		int FindChange(string node)
		{
			foreach (var above in tower[node].Above)
			{
				if (!IsBalanced(above))
				{
					return FindChange(above);
				}
			}

			var weights = tower[node]
				.Above
				.Select(n => (Node: n, Weight: GetWeight(n)))
				.GroupBy(n => n.Weight)
				.ToArray();

			var have = weights.Where(g => g.Count() is 1).Single();
			var want = weights.Where(g => g.Count() > 1).Single().Key;

			return tower[have.Single().Node].Weight + want - have.Key;
		}

		bool IsBalanced(string node) => tower[node]
			.Above
			.Select(GetWeight)
			.Group()
			.Count() is 1;

		int GetWeight(string node) => 
			tower[node].Weight + tower[node].Above.Sum(GetWeight);
	}

	private static string GetRoot(Tower tower)
	{
		var node = tower.First().Key;

		while (true)
		{
			var below = tower.FirstOrDefault(kv => kv.Value.Above.Contains(node));

			if (below.Key is null)
			{
				return node;
			}

			node = below.Key;
		}
	}

	private Tower Parse()
	{
		var tower = new Tower();
		var split = input
			.Select(line => line.Split("->", StringSplitOptions.TrimEntries))
			.Select(line => (Head: line[0].Split(), Tail: line.Length > 1 ? line[1] : null))
			.ToArray();

		foreach (var (head, _) in split)
		{
			tower.Add(head[0], (head[1][1..^1].ToInt32(), []));
		}

		foreach (var (head, tail) in split.Where(s => s.Tail is { }))
		{
			var above = tail.Split(',', StringSplitOptions.TrimEntries);

			foreach (var prog in above)
			{
				tower[head[0]].Above.Add(prog);
			}
		}

		return tower;
	}
}
