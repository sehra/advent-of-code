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
		var answer = 0;

		foreach (var update in updates.Where(u => !IsValid(rules, u)))
		{
			while (!IsValid(rules, update))
			{
				for (int i = 0; i < update.Length; i++)
				{
					for (int j = i + 1; j < update.Length; j++)
					{
						if (rules.Contains((update[j], update[i])))
						{
							(update[j], update[i]) = (update[i], update[j]);
						}
					}
				}
			}

			answer += update[update.Length / 2];
		}

		return answer;
	}

	private static bool IsValid(List<(int A, int B)> rules, int[] update)
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

	private (List<(int A, int B)>, List<int[]>) Parse()
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

		return (rules, updates);
	}
}
