using System.Collections.Frozen;

namespace AdventOfCode.Year2024;

public class Day5(string[] input)
{
	public int Part1()
	{
		var (rules, updates) = Parse();

		return updates
			.Where(u => IsValid(rules, u))
			.Sum(u => u[u.Length / 2]);
	}

	public int Part2()
	{
		var (rules, updates) = Parse();
		var comparer = new PageComparer(rules);
		var answer = 0;

		foreach (var update in updates.Where(u => !IsValid(rules, u)))
		{
			Array.Sort(update, comparer);
			answer += update[update.Length / 2];
		}

		return answer;
	}

	private class PageComparer(FrozenSet<(int, int)> rules) : IComparer<int>
	{
		public int Compare(int x, int y) => rules.Contains((y, x)) ? 1 : -1;
	}

	private static bool IsValid(FrozenSet<(int, int)> rules, int[] update)
	{
		for (int i = 0; i < update.Length; i++)
		{
			for (int j = i + 1; j < update.Length; j++)
			{
				if (rules.Contains((update[j], update[i])))
				{
					return false;
				}
			}
		}

		return true;
	}

	private (FrozenSet<(int, int)>, List<int[]>) Parse()
	{
		var rules = new List<(int, int)>();
		var updates = new List<int[]>();

		foreach (var line in input)
		{
			if (line.Contains('|'))
			{
				var rule = line.Split('|').ToInt32();
				rules.Add((rule[0], rule[1]));
			}
			else
			{
				updates.Add(line.Split(',').ToInt32());
			}
		}

		return (rules.ToFrozenSet(), updates);
	}
}
